﻿using System;
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
                if (lblBytesSentCount.Text != "0" && lblBytesReceivedCount.Text != "0" && !reMaximized)
                {
                    int bytesSentSpeed = (int)(interfaceStats.BytesSent - bytesSentAtStartUp - double.Parse(lblBytesSentCount.Text)) / 1024;
                    int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - bytesReceivedAtStartUp - double.Parse(lblBytesReceivedCount.Text)) / 1024;
                    lblUpSpeedCount.Text = bytesSentSpeed.ToString() + " kb/s";
                    lblDownSpeedCount.Text = bytesReceivedSpeed.ToString() + " kb/s";
                }

                // Display traffic that happened since the program was started
                lblBytesSentCount.Text = (interfaceStats.BytesSent - bytesSentAtStartUp).ToString();
                lblBytesReceivedCount.Text = (interfaceStats.BytesReceived - bytesReceivedAtStartUp).ToString();

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
            vars.keys++;
            updateStats();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (isMinimized())
            {
                reMaximized = true;
                lblDownSpeedCount.Text = "0";
                lblUpSpeedCount.Text = "0";
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
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vars.exit = true;
            this.Close();
        }

        public static class vars
        {
            public static int rclick;
            public static int lclick;
            public static int mclick;
            public static int keys;
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
                                     lblBytesReceivedCount, lblBytesReceivedText, lblBytesSentCount, lblBytesSentText, lblDownSpeedCount,
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
    }
}
