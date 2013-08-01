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
            lblLeftClickCount.Text = Convert.ToString(vars.lclick);
            lblRightClickCount.Text = Convert.ToString(vars.rclick);
            lblMiddleClickCount.Text = Convert.ToString(vars.mclick);
            lblKeyPressCount.Text = Convert.ToString(vars.keys);
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
                                     lblKeyPressText, lblRightClickText, lblRightClickCount, lblMiddleClickText, lblMiddleClickCount };
                    foreach (Label label in labelsOnForm)
                    {   
                        label.Font = fontDialog1.Font;
                        label.ForeColor = fontDialog1.Color;
                    }      
                    menuStrip1.ForeColor = fontDialog1.Color;
                    ToolStripMenuItem[] ToolStripMenuItemsOnForm = { exitToolStripMenuItem1, changelogToolStripMenuItem, fontToolStripMenuItem, backgroundToolStripMenuItem,
                                     settingsToolStripMenuItem, aboutToolStripMenuItem, };
                    foreach (ToolStripMenuItem ToolStripMenuItem in ToolStripMenuItemsOnForm)
                    {
                        ToolStripMenuItem.ForeColor = fontDialog1.Color;
                    }  
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
                    ToolStripMenuItem[] ToolStripMenuItemsOnForm = { exitToolStripMenuItem1, changelogToolStripMenuItem, fontToolStripMenuItem, backgroundToolStripMenuItem,
                                     settingsToolStripMenuItem, aboutToolStripMenuItem, };
                    foreach (ToolStripMenuItem ToolStripMenuItem in ToolStripMenuItemsOnForm)
                    {
                        ToolStripMenuItem.BackColor = colorDialog1.Color;
                    }  
                }
            }
             catch (Exception)
             {
                 MessageBox.Show("Invalid color! Choose different color.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

             }
        }
    }
}
