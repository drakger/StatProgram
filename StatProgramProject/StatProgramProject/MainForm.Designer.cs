namespace StatProgramProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblKeyPressText = new System.Windows.Forms.Label();
            this.lblKeyPressCount = new System.Windows.Forms.Label();
            this.lblKeyboardStats = new System.Windows.Forms.Label();
            this.lblLeftClickText = new System.Windows.Forms.Label();
            this.lblLeftClickCount = new System.Windows.Forms.Label();
            this.lblMouseStats = new System.Windows.Forms.Label();
            this.lblRightClickText = new System.Windows.Forms.Label();
            this.lblRightClickCount = new System.Windows.Forms.Label();
            this.lblMiddleClickText = new System.Windows.Forms.Label();
            this.lblMiddleClickCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUptime = new System.Windows.Forms.Label();
            this.lblUptimeText = new System.Windows.Forms.Label();
            this.lblUpSpeedCount = new System.Windows.Forms.Label();
            this.lblDownSpeedCount = new System.Windows.Forms.Label();
            this.lblDataReceivedCount = new System.Windows.Forms.Label();
            this.lblDataSentCount = new System.Windows.Forms.Label();
            this.lblUpSpeedText = new System.Windows.Forms.Label();
            this.lblDownSpeedText = new System.Windows.Forms.Label();
            this.lblDataReceivedText = new System.Windows.Forms.Label();
            this.lblDataSentText = new System.Windows.Forms.Label();
            this.lblNetStats = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.KeyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picNetAvailable = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetAvailable)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "StatsProgram";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.Black;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(75, 48);
            // 
            // statsToolStripMenuItem
            // 
            this.statsToolStripMenuItem.Name = "statsToolStripMenuItem";
            this.statsToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.statsToolStripMenuItem.Text = "Stats";
            this.statsToolStripMenuItem.Click += new System.EventHandler(this.statsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(74, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.backgroundToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.historyToolStripMenuItem.Text = "History";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changelogToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowVerticalFonts = false;
            this.fontDialog1.Color = System.Drawing.SystemColors.ControlText;
            this.fontDialog1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fontDialog1.FontMustExist = true;
            this.fontDialog1.ShowColor = true;
            // 
            // lblKeyPressText
            // 
            this.lblKeyPressText.AutoSize = true;
            this.lblKeyPressText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeyPressText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyPressText.Location = new System.Drawing.Point(355, 64);
            this.lblKeyPressText.Name = "lblKeyPressText";
            this.lblKeyPressText.Size = new System.Drawing.Size(182, 36);
            this.lblKeyPressText.TabIndex = 7;
            this.lblKeyPressText.Text = "Key presses:";
            this.lblKeyPressText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblKeyPressCount
            // 
            this.lblKeyPressCount.AutoSize = true;
            this.lblKeyPressCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeyPressCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyPressCount.Location = new System.Drawing.Point(543, 64);
            this.lblKeyPressCount.Name = "lblKeyPressCount";
            this.lblKeyPressCount.Size = new System.Drawing.Size(115, 36);
            this.lblKeyPressCount.TabIndex = 2;
            this.lblKeyPressCount.Text = "0";
            this.lblKeyPressCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeyboardStats
            // 
            this.lblKeyboardStats.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblKeyboardStats, 2);
            this.lblKeyboardStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKeyboardStats.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyboardStats.Location = new System.Drawing.Point(355, 0);
            this.lblKeyboardStats.Name = "lblKeyboardStats";
            this.lblKeyboardStats.Size = new System.Drawing.Size(303, 64);
            this.lblKeyboardStats.TabIndex = 4;
            this.lblKeyboardStats.Text = "Keyboard statistics";
            this.lblKeyboardStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeftClickText
            // 
            this.lblLeftClickText.AutoSize = true;
            this.lblLeftClickText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeftClickText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftClickText.Location = new System.Drawing.Point(3, 64);
            this.lblLeftClickText.Name = "lblLeftClickText";
            this.lblLeftClickText.Size = new System.Drawing.Size(202, 36);
            this.lblLeftClickText.TabIndex = 6;
            this.lblLeftClickText.Text = "Left clicks:";
            this.lblLeftClickText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLeftClickCount
            // 
            this.lblLeftClickCount.AutoSize = true;
            this.lblLeftClickCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeftClickCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftClickCount.Location = new System.Drawing.Point(211, 64);
            this.lblLeftClickCount.Name = "lblLeftClickCount";
            this.lblLeftClickCount.Size = new System.Drawing.Size(70, 36);
            this.lblLeftClickCount.TabIndex = 1;
            this.lblLeftClickCount.Text = "0";
            this.lblLeftClickCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMouseStats
            // 
            this.lblMouseStats.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblMouseStats, 2);
            this.lblMouseStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseStats.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseStats.Location = new System.Drawing.Point(3, 0);
            this.lblMouseStats.Name = "lblMouseStats";
            this.lblMouseStats.Size = new System.Drawing.Size(278, 64);
            this.lblMouseStats.TabIndex = 3;
            this.lblMouseStats.Text = "Mouse statistics";
            this.lblMouseStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRightClickText
            // 
            this.lblRightClickText.AutoSize = true;
            this.lblRightClickText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRightClickText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightClickText.Location = new System.Drawing.Point(3, 100);
            this.lblRightClickText.Name = "lblRightClickText";
            this.lblRightClickText.Size = new System.Drawing.Size(202, 36);
            this.lblRightClickText.TabIndex = 7;
            this.lblRightClickText.Text = "Right clicks:";
            this.lblRightClickText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRightClickCount
            // 
            this.lblRightClickCount.AutoSize = true;
            this.lblRightClickCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRightClickCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightClickCount.Location = new System.Drawing.Point(211, 100);
            this.lblRightClickCount.Name = "lblRightClickCount";
            this.lblRightClickCount.Size = new System.Drawing.Size(70, 36);
            this.lblRightClickCount.TabIndex = 8;
            this.lblRightClickCount.Text = "0";
            this.lblRightClickCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMiddleClickText
            // 
            this.lblMiddleClickText.AutoSize = true;
            this.lblMiddleClickText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleClickText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleClickText.Location = new System.Drawing.Point(3, 136);
            this.lblMiddleClickText.Name = "lblMiddleClickText";
            this.lblMiddleClickText.Size = new System.Drawing.Size(202, 36);
            this.lblMiddleClickText.TabIndex = 9;
            this.lblMiddleClickText.Text = "Middle clicks:";
            this.lblMiddleClickText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMiddleClickCount
            // 
            this.lblMiddleClickCount.AutoSize = true;
            this.lblMiddleClickCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMiddleClickCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleClickCount.Location = new System.Drawing.Point(211, 136);
            this.lblMiddleClickCount.Name = "lblMiddleClickCount";
            this.lblMiddleClickCount.Size = new System.Drawing.Size(70, 36);
            this.lblMiddleClickCount.TabIndex = 10;
            this.lblMiddleClickCount.Text = "0";
            this.lblMiddleClickCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.43478F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.15942F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.95262F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.53623F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.82609F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.913043F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblUptime, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblUptimeText, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyPressText, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUpSpeedCount, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblDownSpeedCount, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblDataReceivedCount, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDataSentCount, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblUpSpeedText, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblDownSpeedText, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblDataReceivedText, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDataSentText, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblNetStats, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblMiddleClickCount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMiddleClickText, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblRightClickCount, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblRightClickText, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMouseStats, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLeftClickCount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLeftClickText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyboardStats, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblKeyPressCount, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.picNetAvailable, 2, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(690, 461);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblUptime, 2);
            this.lblUptime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUptime.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUptime.Location = new System.Drawing.Point(355, 309);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(303, 36);
            this.lblUptime.TabIndex = 22;
            this.lblUptime.Text = "0s";
            this.lblUptime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUptimeText
            // 
            this.lblUptimeText.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblUptimeText, 2);
            this.lblUptimeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUptimeText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUptimeText.Location = new System.Drawing.Point(355, 245);
            this.lblUptimeText.Name = "lblUptimeText";
            this.lblUptimeText.Size = new System.Drawing.Size(303, 64);
            this.lblUptimeText.TabIndex = 21;
            this.lblUptimeText.Text = "Program uptime:";
            this.lblUptimeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpSpeedCount
            // 
            this.lblUpSpeedCount.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblUpSpeedCount, 2);
            this.lblUpSpeedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpSpeedCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpSpeedCount.Location = new System.Drawing.Point(211, 417);
            this.lblUpSpeedCount.Name = "lblUpSpeedCount";
            this.lblUpSpeedCount.Size = new System.Drawing.Size(138, 44);
            this.lblUpSpeedCount.TabIndex = 19;
            this.lblUpSpeedCount.Text = "0 byte/s";
            this.lblUpSpeedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDownSpeedCount
            // 
            this.lblDownSpeedCount.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDownSpeedCount, 2);
            this.lblDownSpeedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDownSpeedCount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownSpeedCount.Location = new System.Drawing.Point(211, 381);
            this.lblDownSpeedCount.Name = "lblDownSpeedCount";
            this.lblDownSpeedCount.Size = new System.Drawing.Size(138, 36);
            this.lblDownSpeedCount.TabIndex = 18;
            this.lblDownSpeedCount.Text = "0 byte/s";
            this.lblDownSpeedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataReceivedCount
            // 
            this.lblDataReceivedCount.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDataReceivedCount, 2);
            this.lblDataReceivedCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataReceivedCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataReceivedCount.Location = new System.Drawing.Point(211, 309);
            this.lblDataReceivedCount.Name = "lblDataReceivedCount";
            this.lblDataReceivedCount.Size = new System.Drawing.Size(138, 36);
            this.lblDataReceivedCount.TabIndex = 17;
            this.lblDataReceivedCount.Text = "0 byte";
            this.lblDataReceivedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataSentCount
            // 
            this.lblDataSentCount.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblDataSentCount, 2);
            this.lblDataSentCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataSentCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSentCount.Location = new System.Drawing.Point(211, 345);
            this.lblDataSentCount.Name = "lblDataSentCount";
            this.lblDataSentCount.Size = new System.Drawing.Size(138, 36);
            this.lblDataSentCount.TabIndex = 16;
            this.lblDataSentCount.Text = "0 byte";
            this.lblDataSentCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpSpeedText
            // 
            this.lblUpSpeedText.AutoSize = true;
            this.lblUpSpeedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUpSpeedText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpSpeedText.Location = new System.Drawing.Point(3, 417);
            this.lblUpSpeedText.Name = "lblUpSpeedText";
            this.lblUpSpeedText.Size = new System.Drawing.Size(202, 44);
            this.lblUpSpeedText.TabIndex = 15;
            this.lblUpSpeedText.Text = "Upload speed:";
            this.lblUpSpeedText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUpSpeedText.UseMnemonic = false;
            // 
            // lblDownSpeedText
            // 
            this.lblDownSpeedText.AutoSize = true;
            this.lblDownSpeedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDownSpeedText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownSpeedText.Location = new System.Drawing.Point(3, 381);
            this.lblDownSpeedText.Name = "lblDownSpeedText";
            this.lblDownSpeedText.Size = new System.Drawing.Size(202, 36);
            this.lblDownSpeedText.TabIndex = 14;
            this.lblDownSpeedText.Text = "Download speed:";
            this.lblDownSpeedText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDownSpeedText.UseMnemonic = false;
            // 
            // lblDataReceivedText
            // 
            this.lblDataReceivedText.AutoSize = true;
            this.lblDataReceivedText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataReceivedText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataReceivedText.Location = new System.Drawing.Point(3, 309);
            this.lblDataReceivedText.Name = "lblDataReceivedText";
            this.lblDataReceivedText.Size = new System.Drawing.Size(202, 36);
            this.lblDataReceivedText.TabIndex = 13;
            this.lblDataReceivedText.Text = "Data received:";
            this.lblDataReceivedText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDataReceivedText.UseMnemonic = false;
            // 
            // lblDataSentText
            // 
            this.lblDataSentText.AutoSize = true;
            this.lblDataSentText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataSentText.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataSentText.Location = new System.Drawing.Point(3, 345);
            this.lblDataSentText.Name = "lblDataSentText";
            this.lblDataSentText.Size = new System.Drawing.Size(202, 36);
            this.lblDataSentText.TabIndex = 12;
            this.lblDataSentText.Text = "Data sent:";
            this.lblDataSentText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDataSentText.UseMnemonic = false;
            // 
            // lblNetStats
            // 
            this.lblNetStats.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblNetStats, 2);
            this.lblNetStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetStats.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetStats.Location = new System.Drawing.Point(3, 245);
            this.lblNetStats.Name = "lblNetStats";
            this.lblNetStats.Size = new System.Drawing.Size(278, 64);
            this.lblNetStats.TabIndex = 11;
            this.lblNetStats.Text = "Internet statistics";
            this.lblNetStats.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Lime;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyColumn,
            this.PressesColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Lime;
            this.dataGridView1.Location = new System.Drawing.Point(355, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 3);
            this.dataGridView1.Size = new System.Drawing.Size(303, 139);
            this.dataGridView1.TabIndex = 20;
            // 
            // KeyColumn
            // 
            this.KeyColumn.HeaderText = "Key";
            this.KeyColumn.Name = "KeyColumn";
            this.KeyColumn.ReadOnly = true;
            // 
            // PressesColumn
            // 
            this.PressesColumn.HeaderText = "Presses";
            this.PressesColumn.Name = "PressesColumn";
            this.PressesColumn.ReadOnly = true;
            // 
            // picNetAvailable
            // 
            this.picNetAvailable.BackColor = System.Drawing.Color.Transparent;
            this.picNetAvailable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNetAvailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNetAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picNetAvailable.ImageLocation = "";
            this.picNetAvailable.Location = new System.Drawing.Point(287, 248);
            this.picNetAvailable.Name = "picNetAvailable";
            this.picNetAvailable.Size = new System.Drawing.Size(62, 58);
            this.picNetAvailable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNetAvailable.TabIndex = 25;
            this.picNetAvailable.TabStop = false;
            this.picNetAvailable.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.picNetAvailable_LoadCompleted);
            this.picNetAvailable.Click += new System.EventHandler(this.picNetAvailable_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(702, 500);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Lime;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "StatProgram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNetAvailable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblKeyPressText;
        private System.Windows.Forms.Label lblKeyPressCount;
        private System.Windows.Forms.Label lblKeyboardStats;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMiddleClickCount;
        private System.Windows.Forms.Label lblMiddleClickText;
        private System.Windows.Forms.Label lblRightClickCount;
        private System.Windows.Forms.Label lblRightClickText;
        private System.Windows.Forms.Label lblMouseStats;
        private System.Windows.Forms.Label lblLeftClickCount;
        private System.Windows.Forms.Label lblLeftClickText;
        private System.Windows.Forms.Label lblUpSpeedCount;
        private System.Windows.Forms.Label lblDownSpeedCount;
        private System.Windows.Forms.Label lblDataReceivedCount;
        private System.Windows.Forms.Label lblDataSentCount;
        private System.Windows.Forms.Label lblUpSpeedText;
        private System.Windows.Forms.Label lblDownSpeedText;
        private System.Windows.Forms.Label lblDataReceivedText;
        private System.Windows.Forms.Label lblDataSentText;
        private System.Windows.Forms.Label lblNetStats;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem statsToolStripMenuItem;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblUptimeText;
        private System.Windows.Forms.PictureBox picNetAvailable;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PressesColumn;
    }
}

