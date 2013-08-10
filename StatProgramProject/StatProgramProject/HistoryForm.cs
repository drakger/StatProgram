using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StatProgramProject
{
    public partial class HistoryForm : Form
    {
        bool closebool;
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closebool == false)
            {
                this.Owner.Show();
            }
        }

        private void HistoryForm_Shown(object sender, EventArgs e)
        {
            ToolStripMenuItem[] ToolStripMenuItemsOnForm = { exitToolStripMenuItem };
            foreach (ToolStripMenuItem ToolStripMenuItem in ToolStripMenuItemsOnForm)
            {
                ToolStripMenuItem.ForeColor = MainForm.vars.forecolor;
                ToolStripMenuItem.BackColor = MainForm.vars.backcolor;
            }

            Label[] labelsOnForm = { label1 };
            foreach (Label label in labelsOnForm)
            {
                if (MainForm.vars.labelfont != null)
                {
                    label.Font = MainForm.vars.labelfont;
                }
                label.ForeColor = MainForm.vars.forecolor;
            }


            menuStrip1.BackColor = MainForm.vars.backcolor;
            menuStrip1.ForeColor = MainForm.vars.forecolor;
            this.BackColor = MainForm.vars.backcolor;
            this.ForeColor = MainForm.vars.forecolor;
            this.Width = MainForm.vars.mainfw;
            this.Height = MainForm.vars.mainfh;
            this.Location = MainForm.vars.mainflocation;
            if (MainForm.vars.mainfmaxim == true)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void HistoryForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                closebool = true;
                this.Close();
            }
        }
    }
}
