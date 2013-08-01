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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        string programVersion = "0.01";
        GlobalKeyboardHook kHook;

        public Form1()
        {
            InitializeComponent();
            kHook = new GlobalKeyboardHook();
            kHook.KeyUp += new KeyEventHandler(gHook_KeyUp);
            kHook.hook();
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                kHook.HookedKeys.Add(key);
            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Mouse);
        }
        private void Mouse(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState)
            {
                Updatestats();
            }
        }
        public void Updatestats()
        {
            label1.Text = Convert.ToString(vars.lclick);
            label8.Text = Convert.ToString(vars.rclick);
            label10.Text = Convert.ToString(vars.mclick);
            label2.Text = Convert.ToString(vars.keys);
        }
        public void gHook_KeyUp(object sender, KeyEventArgs e)
        {
            vars.keys++;
            Updatestats();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
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
                    Updatestats();
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

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("StatProgram" + "\n" + "Version: 0.0", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void changelogToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Changelog.txt");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developers: " + "\n" + "Sajage & Drakger" + "\n" + "v"
              + programVersion, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = fontDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    label1.Font = fontDialog1.Font;
                    label1.ForeColor = fontDialog1.Color;
                    label2.Font = fontDialog1.Font;
                    label2.ForeColor = fontDialog1.Color;
                    label3.Font = fontDialog1.Font;
                    label3.ForeColor = fontDialog1.Color;
                    label4.Font = fontDialog1.Font;
                    label4.ForeColor = fontDialog1.Color;
                    label5.Font = fontDialog1.Font;
                    label5.ForeColor = fontDialog1.Color;
                    label6.Font = fontDialog1.Font;
                    label6.ForeColor = fontDialog1.Color;
                    label7.Font = fontDialog1.Font;
                    label7.ForeColor = fontDialog1.Color;
                    label8.Font = fontDialog1.Font;
                    label8.ForeColor = fontDialog1.Color;
                    label9.Font = fontDialog1.Font;
                    label9.ForeColor = fontDialog1.Color;
                    label10.Font = fontDialog1.Font;
                    label10.ForeColor = fontDialog1.Color;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Font! Choose different font.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
