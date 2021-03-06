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
using System.Data.OleDb;

namespace StatProgramProject
{
    public partial class MainForm : Form
    {
        string programVersion = "0.05";
        GlobalKeyboardHook kHook;
        //For  font resize
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize, dataGridColumnHeadersinitialFontSize, dataGridDefaultCellinitalFontSize;

        public MainForm()
        {
            Application.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            InitializeComponent();
            InitializeNetworkInterface();
            InitializeTimer();
            netavailable();
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
            // Sets the initial size of the variables for font resize
            initialWidth = Width;
            initialHeight = Height;
            initialFontSize = lblMouseStats.Font.Size;
            dataGridColumnHeadersinitialFontSize = dataGridView1.ColumnHeadersDefaultCellStyle.Font.Size;
            dataGridDefaultCellinitalFontSize = dataGridView1.DefaultCellStyle.Font.Size;
            lblMouseStats.Resize += LabelFont_Resize;
        }

        private void LabelFont_Resize(object sender, EventArgs e)
        {
            SuspendLayout();
            // Get the proportionality of the resize
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            Label[] labelsOnForm = { lblLeftClickCount, lblKeyPressCount, lblMouseStats, lblKeyboardStats, lblLeftClickText,
                                     lblKeyPressText, lblRightClickText, lblRightClickCount, lblMiddleClickText, lblMiddleClickCount,
                                     lblDataReceivedCount, lblDataReceivedText, lblDataSentCount, lblDataSentText, lblDownSpeedCount,
                                     lblDownSpeedText, lblNetStats, lblUpSpeedCount, lblUpSpeedText,lblUptime,lblUptimeText };
            foreach (Label label in labelsOnForm)
            {

                // Calculate the current font size
                label.Font = new Font(label.Font.FontFamily, (initialFontSize-2)  *
                    (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                    label.Font.Style);
            }
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, dataGridColumnHeadersinitialFontSize  *
                    (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font.Style);
            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, dataGridDefaultCellinitalFontSize *
                    (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                   dataGridView1.DefaultCellStyle.Font.Style);
            ResumeLayout();
        }

        private void Mouse(object sender, EventArgs e)
        {
            updateStats();
        }
        
        public void updateStats()
        {
            if (FormWindowState.Minimized != WindowState)
            {
                lblLeftClickCount.Text = Convert.ToString(vars.lclick);
                lblRightClickCount.Text = Convert.ToString(vars.rclick);
                lblMiddleClickCount.Text = Convert.ToString(vars.mclick);
                lblKeyPressCount.Text = Convert.ToString(vars.keys);
                Label[] statlabels = { lblLeftClickCount, lblRightClickCount, lblMiddleClickCount, lblKeyPressCount };
                foreach (Label label in statlabels)
                {
                    while (label.Width < System.Windows.Forms.TextRenderer.MeasureText(label.Text,
                        new Font(label.Font.FontFamily, label.Font.Size, label.Font.Style)).Width)
                    {
                        label.Font = new Font(label.Font.FontFamily, label.Font.Size - 0.5f, label.Font.Style);
                    }
                }
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

            netcheckTimer = new Timer();
            netcheckTimer.Interval = (int)NETCHECK_TIMER_UPDATE;
            netcheckTimer.Tick += new EventHandler(netcheckTimer_Tick);
            netcheckTimer.Start();

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
                    int keycount = Convert.ToInt32(row.Cells[1].Value);
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
        public static class vars
        {
            public static double rclick;
            public static double lclick;
            public static double mclick;
            public static double keys;
            public static bool exit;
            public static Color backcolor;
            public static Color forecolor;
            public static bool netpictureh;
            public static Font labelfont;
            public static bool mainfmaxim;
            public static int mainfh;
            public static int mainfw;
            public static Point mainflocation;
            public static bool pingcomplete;
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

        private void picNetAvailable_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                if (vars.netpictureh == false)
                {
                    vars.netpictureh = true;
                    MessageBox.Show("Some files were not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void picNetAvailable_Click(object sender, EventArgs e)
        {
            netavailable();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection oleConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=save.mdb"); //Connect to database
            OleDbCommand oleCommand = new OleDbCommand("UPDATE save SET Statnumber=@statnumber WHERE Stat=@statname", oleConnection); //SQL command
            oleCommand.Parameters.AddWithValue("statnumber", vars.lclick);
            oleCommand.Parameters.AddWithValue("statname", "lclicks");
            oleConnection.Open();
            OleDbDataReader oleDataReader = oleCommand.ExecuteReader();
            oleDataReader.Close();
            oleCommand.Parameters.Clear();
            oleCommand.Parameters.AddWithValue("statnumber", vars.rclick);
            oleCommand.Parameters.AddWithValue("statname", "rclicks");
            oleDataReader = oleCommand.ExecuteReader();
            oleDataReader.Close();
            oleCommand.Parameters.Clear();
            oleCommand.Parameters.AddWithValue("statnumber", vars.mclick);
            oleCommand.Parameters.AddWithValue("statname", "mclicks");
            oleDataReader = oleCommand.ExecuteReader();
            oleDataReader.Close();
            oleCommand.Parameters.Clear();
            oleCommand.Parameters.AddWithValue("statnumber", vars.keys);
            oleCommand.Parameters.AddWithValue("statname", "kpresses");
            oleDataReader = oleCommand.ExecuteReader();
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OleDbConnection oleConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=save.mdb");
            OleDbCommand oleCommand = new OleDbCommand("SELECT * FROM save WHERE Stat=@statname", oleConnection);
            oleCommand.Parameters.AddWithValue("statname", "lclicks");
            oleConnection.Open();
            OleDbDataReader oleDataReader = oleCommand.ExecuteReader();
            while (oleDataReader.Read())
            {
                vars.lclick = oleDataReader.GetDouble(1);
            }
            oleDataReader.Close();
            oleCommand.Parameters.Clear();
            oleCommand.Parameters.AddWithValue("statname", "rclicks");
            oleDataReader = oleCommand.ExecuteReader();
            while (oleDataReader.Read())
            {
                vars.rclick = oleDataReader.GetDouble(1);
            }
            oleDataReader.Close();
            oleCommand.Parameters.Clear();
            oleCommand.Parameters.AddWithValue("statname", "mclicks");
            oleDataReader = oleCommand.ExecuteReader();
            while (oleDataReader.Read())
            {
                vars.mclick = oleDataReader.GetDouble(1);
            }
            oleDataReader.Close();
            oleCommand.Parameters.Clear();
            oleCommand.Parameters.AddWithValue("statname", "kpresses");
            oleDataReader = oleCommand.ExecuteReader();
            while (oleDataReader.Read())
            {
                vars.keys = oleDataReader.GetDouble(1);
            }
            updateStats();

        }
    }
}
