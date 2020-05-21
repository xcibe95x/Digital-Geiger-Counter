namespace Radiation_Logger
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFromCurrentLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graphFromlogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailSupportradiohobbystorecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentRadiationLevelLabel = new System.Windows.Forms.Label();
            this.startLogButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.conversionFactorSaveButton = new System.Windows.Forms.Button();
            this.conversionFactorLabel = new System.Windows.Forms.TextBox();
            this.SaveLogToFileCheckbox = new System.Windows.Forms.CheckBox();
            this.SaveLogToFileTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AlertThresholdSaveButton = new System.Windows.Forms.Button();
            this.AlertThresholdLabel = new System.Windows.Forms.TextBox();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenContextMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitContextMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.GraphFromFileOpenfiledialog = new System.Windows.Forms.OpenFileDialog();
            this.FlashTimer = new System.Windows.Forms.Timer(this.components);
            this.FlashingStopTimer = new System.Windows.Forms.Timer(this.components);
            this.PortTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.trayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.graphsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(565, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.settingsToolStripMenuItem.Text = "Se&ttings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // graphsToolStripMenuItem
            // 
            this.graphsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graphFromCurrentLogToolStripMenuItem,
            this.graphFromlogFileToolStripMenuItem,
            this.logsFolderToolStripMenuItem});
            this.graphsToolStripMenuItem.Name = "graphsToolStripMenuItem";
            this.graphsToolStripMenuItem.Size = new System.Drawing.Size(72, 25);
            this.graphsToolStripMenuItem.Text = "&Graphs";
            // 
            // graphFromCurrentLogToolStripMenuItem
            // 
            this.graphFromCurrentLogToolStripMenuItem.Name = "graphFromCurrentLogToolStripMenuItem";
            this.graphFromCurrentLogToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.graphFromCurrentLogToolStripMenuItem.Text = "Graph from &current log";
            this.graphFromCurrentLogToolStripMenuItem.Click += new System.EventHandler(this.graphFromCurrentLogToolStripMenuItem_Click);
            // 
            // graphFromlogFileToolStripMenuItem
            // 
            this.graphFromlogFileToolStripMenuItem.Name = "graphFromlogFileToolStripMenuItem";
            this.graphFromlogFileToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.graphFromlogFileToolStripMenuItem.Text = "Graph from &log file";
            this.graphFromlogFileToolStripMenuItem.Click += new System.EventHandler(this.graphFromlogFileToolStripMenuItem_Click);
            // 
            // logsFolderToolStripMenuItem
            // 
            this.logsFolderToolStripMenuItem.Name = "logsFolderToolStripMenuItem";
            this.logsFolderToolStripMenuItem.Size = new System.Drawing.Size(241, 26);
            this.logsFolderToolStripMenuItem.Text = "Logs F&older";
            this.logsFolderToolStripMenuItem.Click += new System.EventHandler(this.logsFolderToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emailSupportradiohobbystorecomToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(54, 25);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // emailSupportradiohobbystorecomToolStripMenuItem
            // 
            this.emailSupportradiohobbystorecomToolStripMenuItem.Name = "emailSupportradiohobbystorecomToolStripMenuItem";
            this.emailSupportradiohobbystorecomToolStripMenuItem.Size = new System.Drawing.Size(339, 26);
            this.emailSupportradiohobbystorecomToolStripMenuItem.Text = "E&mail support@radiohobbystore.com";
            this.emailSupportradiohobbystorecomToolStripMenuItem.Click += new System.EventHandler(this.emailSupportradiohobbystorecomToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(339, 26);
            this.aboutToolStripMenuItem1.Text = "&About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(12, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(541, 184);
            this.listBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.currentRadiationLevelLabel);
            this.groupBox1.Location = new System.Drawing.Point(22, 239);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 75);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Radiation Level";
            // 
            // currentRadiationLevelLabel
            // 
            this.currentRadiationLevelLabel.AutoSize = true;
            this.currentRadiationLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.currentRadiationLevelLabel.Location = new System.Drawing.Point(13, 22);
            this.currentRadiationLevelLabel.Name = "currentRadiationLevelLabel";
            this.currentRadiationLevelLabel.Size = new System.Drawing.Size(206, 37);
            this.currentRadiationLevelLabel.TabIndex = 0;
            this.currentRadiationLevelLabel.Text = "0.0000 uSv/h";
            // 
            // startLogButton
            // 
            this.startLogButton.AutoSize = true;
            this.startLogButton.Location = new System.Drawing.Point(457, 239);
            this.startLogButton.Name = "startLogButton";
            this.startLogButton.Size = new System.Drawing.Size(96, 52);
            this.startLogButton.TabIndex = 3;
            this.startLogButton.Text = "Start Log";
            this.startLogButton.UseVisualStyleBackColor = true;
            this.startLogButton.Click += new System.EventHandler(this.startLogButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.conversionFactorSaveButton);
            this.groupBox2.Controls.Add(this.conversionFactorLabel);
            this.groupBox2.Location = new System.Drawing.Point(280, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 43);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conversion Factor";
            // 
            // conversionFactorSaveButton
            // 
            this.conversionFactorSaveButton.Location = new System.Drawing.Point(114, 16);
            this.conversionFactorSaveButton.Name = "conversionFactorSaveButton";
            this.conversionFactorSaveButton.Size = new System.Drawing.Size(44, 20);
            this.conversionFactorSaveButton.TabIndex = 1;
            this.conversionFactorSaveButton.Text = "Save";
            this.conversionFactorSaveButton.UseVisualStyleBackColor = true;
            this.conversionFactorSaveButton.Click += new System.EventHandler(this.conversionFactorSaveButton_Click);
            // 
            // conversionFactorLabel
            // 
            this.conversionFactorLabel.Location = new System.Drawing.Point(7, 16);
            this.conversionFactorLabel.Name = "conversionFactorLabel";
            this.conversionFactorLabel.Size = new System.Drawing.Size(100, 20);
            this.conversionFactorLabel.TabIndex = 0;
            // 
            // SaveLogToFileCheckbox
            // 
            this.SaveLogToFileCheckbox.AutoSize = true;
            this.SaveLogToFileCheckbox.Location = new System.Drawing.Point(457, 299);
            this.SaveLogToFileCheckbox.Name = "SaveLogToFileCheckbox";
            this.SaveLogToFileCheckbox.Size = new System.Drawing.Size(96, 17);
            this.SaveLogToFileCheckbox.TabIndex = 5;
            this.SaveLogToFileCheckbox.Text = "Save log to file";
            this.SaveLogToFileCheckbox.UseVisualStyleBackColor = true;
            // 
            // SaveLogToFileTooltip
            // 
            this.SaveLogToFileTooltip.AutomaticDelay = 300;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AlertThresholdSaveButton);
            this.groupBox3.Controls.Add(this.AlertThresholdLabel);
            this.groupBox3.Location = new System.Drawing.Point(280, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 43);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alert Threshold";
            // 
            // AlertThresholdSaveButton
            // 
            this.AlertThresholdSaveButton.Location = new System.Drawing.Point(114, 16);
            this.AlertThresholdSaveButton.Name = "AlertThresholdSaveButton";
            this.AlertThresholdSaveButton.Size = new System.Drawing.Size(44, 20);
            this.AlertThresholdSaveButton.TabIndex = 1;
            this.AlertThresholdSaveButton.Text = "Save";
            this.AlertThresholdSaveButton.UseVisualStyleBackColor = true;
            this.AlertThresholdSaveButton.Click += new System.EventHandler(this.AlertThresholdSaveButton_Click);
            // 
            // AlertThresholdLabel
            // 
            this.AlertThresholdLabel.Location = new System.Drawing.Point(8, 16);
            this.AlertThresholdLabel.Name = "AlertThresholdLabel";
            this.AlertThresholdLabel.Size = new System.Drawing.Size(100, 20);
            this.AlertThresholdLabel.TabIndex = 0;
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.TrayIcon.BalloonTipText = "Radiation Alert";
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "Radiation Logger";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            this.TrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseClick);
            this.TrayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_DoubleClick);
            // 
            // trayMenuStrip
            // 
            this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenContextMenuItem1,
            this.ExitContextMenuItem1});
            this.trayMenuStrip.Name = "trayMenuStrip";
            this.trayMenuStrip.Size = new System.Drawing.Size(131, 64);
            // 
            // OpenContextMenuItem1
            // 
            this.OpenContextMenuItem1.Name = "OpenContextMenuItem1";
            this.OpenContextMenuItem1.Size = new System.Drawing.Size(130, 30);
            this.OpenContextMenuItem1.Text = "Open";
            this.OpenContextMenuItem1.Click += new System.EventHandler(this.OpenContextMenuItem1_Click);
            // 
            // ExitContextMenuItem1
            // 
            this.ExitContextMenuItem1.Name = "ExitContextMenuItem1";
            this.ExitContextMenuItem1.Size = new System.Drawing.Size(130, 30);
            this.ExitContextMenuItem1.Text = "Exit";
            this.ExitContextMenuItem1.Click += new System.EventHandler(this.ExitContextMenuItem1_Click);
            // 
            // GraphFromFileOpenfiledialog
            // 
            this.GraphFromFileOpenfiledialog.Filter = "CSV Files|*.csv";
            // 
            // FlashTimer
            // 
            this.FlashTimer.Interval = 300;
            this.FlashTimer.Tick += new System.EventHandler(this.FlashTimer_Tick);
            // 
            // FlashingStopTimer
            // 
            this.FlashingStopTimer.Interval = 2000;
            this.FlashingStopTimer.Tick += new System.EventHandler(this.FlashingStopTimer_Tick);
            // 
            // PortTimeoutTimer
            // 
            this.PortTimeoutTimer.Interval = 20000;
            this.PortTimeoutTimer.Tick += new System.EventHandler(this.PortTimeoutTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 325);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.SaveLogToFileCheckbox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.startLogButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Radiation Logger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.trayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label currentRadiationLevelLabel;
        private System.Windows.Forms.Button startLogButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button conversionFactorSaveButton;
        private System.Windows.Forms.TextBox conversionFactorLabel;
        private System.Windows.Forms.CheckBox SaveLogToFileCheckbox;
        private System.Windows.Forms.ToolTip SaveLogToFileTooltip;
        private System.Windows.Forms.ToolStripMenuItem graphsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFromCurrentLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graphFromlogFileToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button AlertThresholdSaveButton;
        private System.Windows.Forms.TextBox AlertThresholdLabel;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem emailSupportradiohobbystorecomToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog GraphFromFileOpenfiledialog;
        private System.Windows.Forms.ToolStripMenuItem OpenContextMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitContextMenuItem1;
        private System.Windows.Forms.Timer FlashTimer;
        private System.Windows.Forms.Timer FlashingStopTimer;
        private System.Windows.Forms.Timer PortTimeoutTimer;
        private System.Windows.Forms.ToolStripMenuItem logsFolderToolStripMenuItem;
    }
}