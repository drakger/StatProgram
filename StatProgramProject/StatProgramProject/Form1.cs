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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
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

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
                System.Diagnostics.Process.Start("Changelog.txt");
        }

        private void developersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developers:" + "\n" + "Sajage&Drakger", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
