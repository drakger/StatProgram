using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string programVersion = "0.05";
        GlobalKeyboardHook kHook;

        // Uptime

        private const double UPTIME_TIMER_UPDATE = 1000;
        private Timer uptimeTimer;
        long totalSeconds = 0;
        int weeks = 0, days = 0, hours = 0, minutes = 0, seconds = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeNetworkInterface();
            InitializeTimer();
            kHook = new GlobalKeyboardHook();
            kHook.KeyUp += new KeyEventHandler(gHook_KeyUp);
            kHook.hook();
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                kHook.HookedKeys.Add(key);
            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Mouse);
            vars.backcolor = Color.Black;
            vars.forecolor = Color.Lime;
            menucolor();
        }
        private void Mouse(object sender, EventArgs e)
        {
            updateStats();
        }
        public void menucolor()
        {
            ToolStripMenuItem[] ToolStripMenuItemsOnForm = { exitToolStripMenuItem1, changelogToolStripMenuItem, fontToolStripMenuItem,
                                                                       backgroundToolStripMenuItem, settingsToolStripMenuItem, aboutToolStripMenuItem };
            foreach (ToolStripMenuItem ToolStripMenuItem in ToolStripMenuItemsOnForm)
            {
                ToolStripMenuItem.ForeColor = vars.forecolor;
                ToolStripMenuItem.BackColor = vars.backcolor;
            }
            menuStrip1.BackColor = vars.backcolor;
            menuStrip1.ForeColor = vars.forecolor;
            dataGridView1.BackgroundColor = vars.backcolor;
            dataGridView1.ForeColor = vars.forecolor;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = vars.backcolor;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = vars.forecolor;
            dataGridView1.DefaultCellStyle.BackColor = vars.backcolor;
            dataGridView1.DefaultCellStyle.ForeColor = vars.forecolor;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = vars.backcolor;
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = vars.forecolor;
            dataGridView1.RowHeadersDefaultCellStyle.BackColor = vars.backcolor;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = vars.forecolor;
            dataGridView1.GridColor = vars.forecolor;
            contextMenuStrip1.ForeColor = vars.forecolor;
            contextMenuStrip1.BackColor = vars.backcolor;
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());
        }
        public void updateStats()
        {
            if (FormWindowState.Minimized != WindowState)
            {
                lblLeftClickCount.Text = Convert.ToString(vars.lclick);
                lblRightClickCount.Text = Convert.ToString(vars.rclick);
                lblMiddleClickCount.Text = Convert.ToString(vars.mclick);
                lblKeyPressCount.Text = Convert.ToString(vars.keys);
            }
        }
       
      

        private void InitializeTimer()
        {
            netTimer = new Timer();
            netTimer.Interval = (int)NET_TIMER_UPDATE;
            netTimer.Tick += new EventHandler(netTimer_Tick);
            netTimer.Start();

            uptimeTimer = new Timer();
            uptimeTimer.Interval = (int)UPTIME_TIMER_UPDATE;
            uptimeTimer.Tick += new EventHandler(uptimeTimer_Tick);
            uptimeTimer.Start();
        }
        
        void netTimer_Tick(object sender, EventArgs e)
        {
            updateNetStats();
        }

        void uptimeTimer_Tick(object sender, EventArgs e)
        {
            updateUptime();
        }

        public long getUptime()
        {
            return totalSeconds;
        }

        private void setUptime(long i)
        {
            totalSeconds = i;
        }

        public void updateUptime()
        {
            totalSeconds++;
            seconds++;
            if (seconds == 60)
            {
                seconds -= 60;
                minutes++;
                if (minutes == 60)
                {
                    minutes -= 60;
                    hours++;
                    if (hours == 24)
                    {
                        hours -= 24;
                        days++;
                        if (days == 7)
                        {
                            days -= 7;
                            weeks++;
                        }
                    }
                }
            }
            if (weeks > 0)
                lblUptime.Text = weeks.ToString() + "w " + days.ToString() + "d " + hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
            else if (days > 0)
                lblUptime.Text = days.ToString() + "d " + hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
            else if (hours > 0)
                lblUptime.Text = hours.ToString() + "h " + minutes.ToString() + "m " + seconds.ToString() + "s";
            else if (minutes > 0)
                lblUptime.Text = minutes.ToString() + "m " + seconds.ToString() + "s";
            else
                lblUptime.Text = seconds.ToString() + "s";
        }

        public bool isMinimized()
        {
            return FormWindowState.Minimized == WindowState;
        }
        public void gHook_KeyUp(object sender, KeyEventArgs e)
        {
            bool foundkey;
            foundkey = false;
            vars.keys++;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (Convert.ToString(row.Cells[0].Value) == ((char)e.KeyValue).ToString())
                {
                    uint keycount = Convert.ToUInt32(row.Cells[1].Value);
                    keycount++;
                    row.Cells[1].Value = keycount.ToString();
                    foundkey = true;
                }
            }
            if (foundkey == false)
            {
                dataGridView1.Rows.Add();
                int index = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[index].Cells[0].Value = ((char)e.KeyValue).ToString();
                dataGridView1.Rows[index].Cells[1].Value = "1";
            }
            updateStats();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (isMinimized())
            {
                reMaximized = true;
                lblDownSpeedCount.Text = "0" + getNetDownSpeedType();
                lblUpSpeedCount.Text = "0" + getNetUpSpeedType();
                Hide();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e) //taskbar icon
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon1, null);
            }
            if (e.Button == MouseButtons.Left)
            {
                showform1();
            }
        }

        public void showform1()
        {
            this.Show();
            this.Focus();
            this.TopMost = true;
            this.TopMost = false;
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                updateStats();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vars.exit = true;
            this.Close();
        }

        public static class vars
        {
            public static uint rclick;
            public static uint lclick;
            public static uint mclick;
            public static uint keys;
            public static bool exit;
            public static Color backcolor;
            public static Color forecolor;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vars.exit == false)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vars.exit = true;
            this.Close();
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Changelog.txt");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developers: " + "\n" + "Sajage & Drakger" + "\n\n" + "v"
              + programVersion, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = fontDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Label[] labelsOnForm = { lblLeftClickCount, lblKeyPressCount, lblMouseStats, lblKeyboardStats, lblLeftClickText,
                                     lblKeyPressText, lblRightClickText, lblRightClickCount, lblMiddleClickText, lblMiddleClickCount,
                                     lblDataReceivedCount, lblDataReceivedText, lblDataSentCount, lblDataSentText, lblDownSpeedCount,
                                     lblDownSpeedText, lblNetStats, lblUpSpeedCount, lblUpSpeedText };
                    foreach (Label label in labelsOnForm)
                    {   
                        label.Font = fontDialog1.Font;
                        label.ForeColor = fontDialog1.Color;
                    }      
                    menuStrip1.ForeColor = fontDialog1.Color;
                    vars.forecolor = fontDialog1.Color;
                    menucolor();  
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Font! Choose different font.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {
                DialogResult result = colorDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.BackColor = colorDialog1.Color;
                    menuStrip1.BackColor = colorDialog1.Color;
                    vars.backcolor = colorDialog1.Color;
                    menucolor();
                }
            }
             catch (Exception)
             {
                 MessageBox.Show("Invalid color! Choose different color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
        }
        public class TestColorTable : ProfessionalColorTable
        {
            public override Color MenuBorder  //added for changing the menu border
            {
                get { return vars.forecolor; }
            }
        }

        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showform1();
        }
    }
}
