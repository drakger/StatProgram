using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace StatProgramProject
{
    public partial class MainForm: Form
    {
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
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vars.exit = true;
            this.Close();
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vars.exit = true;
            this.Close();
        }
        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm HistoryForm = new HistoryForm();
            HistoryForm.Owner = this;
            vars.mainfh = this.Height;
            vars.mainfw = this.Width;
            vars.mainflocation = this.Location;
            if (this.WindowState == FormWindowState.Maximized)
            {
                vars.mainfmaxim = true;
            }
            else
            {
                vars.mainfmaxim = false;
            }
            this.Hide();
            HistoryForm.Show();
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
                                     lblDownSpeedText, lblNetStats, lblUpSpeedCount, lblUpSpeedText,lblUptime,lblUptimeText };
                    foreach (Label label in labelsOnForm)
                    {
                        label.Font = fontDialog1.Font;
                        label.ForeColor = fontDialog1.Color;
                        vars.labelfont = fontDialog1.Font;
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
    }
}
