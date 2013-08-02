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
        string programVersion = "0.03";
        GlobalKeyboardHook kHook;

        // Net Stats
        IPv4InterfaceStatistics interfaceStats = NetworkInterface.GetAllNetworkInterfaces()[0].GetIPv4Statistics();
        private NetworkInterface[] nicArr;
        private const double timerUpdate = 1000;
        private Timer netTimer;
        long bytesSentAtStartUp, bytesReceivedAtStartUp;
        bool startUp = true;
        bool reMaximized = false;
        protected string netUpSpeedType = "byte/s";
        protected string netDownSpeedType = "byte/s";
        protected int netUpSpeed, netDownSpeed, dataSent, dataReceived;
        protected long bytesSent, bytesReceived;
        protected string dataSentType = "byte";
        protected string dataReceivedType = "byte";

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
        private void InitializeNetworkInterface()
        {
            // Grab all local interfaces to this computer
            nicArr = NetworkInterface.GetAllNetworkInterfaces();
        }

        private void setNetDownSpeedType(string s)
        {
            netDownSpeedType = s;
        }

        private void setNetUpSpeedType(string s)
        {
            netUpSpeedType = s;
        }

        private string getNetDownSpeedType()
        {
            return netDownSpeedType;
        }

        private string getNetUpSpeedType()
        {
            return netUpSpeedType;
        }

        private void setNetDownSpeed(int n)
        {
            if (n > 1024)
            {
                if ((n / 1024) > 1024)
                {
                    if ((n / 1024 / 1024) > 1024)
                    {
                        netDownSpeed = n / 1024 / 1024 / 1024;
                        setNetDownSpeedType("Gb/s");
                        return;
                    }
                    netDownSpeed = n / 1024 / 1024;
                    setNetDownSpeedType("Mb/s");
                    return;
                }
                netDownSpeed = n / 1024;
                setNetDownSpeedType("kb/s");
                return;
            }
            netDownSpeed = n;
            setNetDownSpeedType("byte/s");
        }

        private void setNetUpSpeed(int n)
        {
            if (n > 1024)
            {
                if ((n / 1024) > 1024)
                {
                    if ((n / 1024 / 1024) > 1024)
                    {
                        netUpSpeed = n / 1024 / 1024 / 1024;
                        setNetUpSpeedType("Gb/s");
                        return;
                    }
                    netUpSpeed = n / 1024 / 1024;
                    setNetUpSpeedType("Mb/s");
                    return;
                }
                netUpSpeed = n / 1024;
                setNetUpSpeedType("kb/s");
                return;
            }
            netUpSpeed = n;
            setNetUpSpeedType("byte/s");
        }

        private int getNetDownSpeed()
        {
            return netDownSpeed;
        }

        private int getNetUpSpeed()
        {
            return netUpSpeed;
        }

        private void setDataSent(long n1, long n2)
        {
            bytesSent = (n1 - n2);
            if (bytesSent > (1024))
            {
                if (bytesSent > (1024 * 1024))
                {
                    if (bytesSent > (1024 * 1024 * 1024))
                        setDataSentType("Gb");
                    else
                        setDataSentType("Mb");
                }
                else
                    setDataSentType("kb");
            }
            if (getDataSentType() == "byte")
                dataSent = (int)bytesSent;
            else if (getDataSentType() == "kb")
                dataSent = (int)bytesSent / 1024;
            else if (getDataSentType() == "Mb")
                dataSent = (int)bytesSent / 1024 / 1024;
            else if (getDataSentType() == "Gb")
                dataSent = (int)bytesSent / 1024 / 1024 / 1024;
        }

        private void setDataReceived(long n1, long n2)
        {
            bytesReceived = (n1 - n2);
            if (bytesReceived > (1024))
            {
                if (bytesReceived > (1024 * 1024))
                {
                    if (bytesReceived > (1024 * 1024 * 1024))
                        setDataReceivedType("Gb");
                    else
                        setDataReceivedType("Mb");
                }
                else
                    setDataReceivedType("kb");
            }
            if (getDataReceivedType() == "byte")
                dataReceived = (int)bytesReceived;
            else if (getDataReceivedType() == "kb")
                dataReceived = (int)bytesReceived / 1024;
            else if (getDataReceivedType() == "Mb")
                dataReceived = (int)bytesReceived / 1024 / 1024;
            else if (getDataReceivedType() == "Gb")
                dataReceived = (int)bytesReceived / 1024 / 1024 / 1024;
        }

        private int getDataSent()
        {
            return dataSent;
        }

        private int getDataReceived()
        {
            return dataReceived;
        }

        private void setDataSentType(string s)
        {
            dataSentType = s;
        }

        private void setDataReceivedType(string s)
        {
            dataReceivedType = s;
        }

        private string getDataSentType()
        {
            return dataSentType;
        }

        private string getDataReceivedType()
        {
            return dataReceivedType;
        }

        private void InitializeTimer()
        {
            netTimer = new Timer();
            netTimer.Interval = (int)timerUpdate;
            netTimer.Tick += new EventHandler(timer_Tick);
            netTimer.Start();
        }
        public void updateNetStats()
        {
            if (!isMinimized())
            {
                // TO-DO: ADD CHOICES BETWEEN LOCAL INTERFACES http://www.m0interactive.com/archives/2008/02/06/how_to_calculate_network_bandwidth_speed_in_c_/
                // PERHAPS TO-DO: ADD BETTER TIMER http://www.m0interactive.com/archives/2006/12/21/high_resolution_timer_in_net_2_0.html
                // TO-DO: IF THE NUMBER REACHES A HIGH ENOUGH VALUE, CONVERT IT TO A BIGGER TYPE
                NetworkInterface nic = nicArr[0];
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

                // Get values of traffic at the program's startup
                if (startUp)
                {
                    bytesSentAtStartUp = interfaceStats.BytesSent;
                    bytesReceivedAtStartUp = interfaceStats.BytesReceived;
                    startUp = false;
                }

                // Calculate speed if there was already a change in traffic
                if (lblDataSentCount.Text != "0" && lblDataReceivedCount.Text != "0" && !reMaximized)
                {
                    int bytesSentSpeed = (int)(interfaceStats.BytesSent - bytesSentAtStartUp - bytesSent);
                    int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - bytesReceivedAtStartUp - bytesReceived);
                    setNetUpSpeed(bytesSentSpeed);
                    setNetDownSpeed(bytesReceivedSpeed);
                }
                    lblUpSpeedCount.Text = getNetUpSpeed().ToString() + " " + getNetUpSpeedType();
                    lblDownSpeedCount.Text = getNetDownSpeed().ToString() + " " + getNetDownSpeedType();

                // Display traffic that happened since the program was started
                setDataSent(interfaceStats.BytesSent, bytesSentAtStartUp);
                setDataReceived(interfaceStats.BytesReceived, bytesReceivedAtStartUp);
                lblDataSentCount.Text = getDataSent().ToString() + " " + getDataSentType();
                lblDataReceivedCount.Text = getDataReceived().ToString() + " " + getDataReceivedType();

                if (reMaximized) reMaximized = false;
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            updateNetStats();
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
                    row.Cells[1].Value = keycount;
                    foundkey = true;
                }
            }
            if (foundkey == false)
            {
                dataGridView1.Rows.Add();
                int index = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows[index].Cells[0].Value = ((char)e.KeyValue).ToString();
                dataGridView1.Rows[index].Cells[1].Value = 1;
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
