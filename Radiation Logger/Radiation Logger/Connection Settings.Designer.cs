namespace Radiation_Logger
{
    partial class ConnectionSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionSettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.StopBitComboBox = new System.Windows.Forms.ComboBox();
            this.TestConnectionButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.GetAvailablePortsButton = new System.Windows.Forms.Button();
            this.ParityComboBox = new System.Windows.Forms.ComboBox();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.SpeedComboBox = new System.Windows.Forms.ComboBox();
            this.DataBitsComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ConnectionTestTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stop bit:";
            // 
            // StopBitComboBox
            // 
            this.StopBitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopBitComboBox.FormattingEnabled = true;
            this.StopBitComboBox.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.StopBitComboBox.Location = new System.Drawing.Point(90, 45);
            this.StopBitComboBox.Name = "StopBitComboBox";
            this.StopBitComboBox.Size = new System.Drawing.Size(121, 21);
            this.StopBitComboBox.TabIndex = 1;
            // 
            // TestConnectionButton
            // 
            this.TestConnectionButton.Location = new System.Drawing.Point(239, 106);
            this.TestConnectionButton.Name = "TestConnectionButton";
            this.TestConnectionButton.Size = new System.Drawing.Size(114, 21);
            this.TestConnectionButton.TabIndex = 2;
            this.TestConnectionButton.Text = "Test connection";
            this.TestConnectionButton.UseVisualStyleBackColor = true;
            this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data bits:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Port:";
            // 
            // PortComboBox
            // 
            this.PortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(90, 12);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(121, 21);
            this.PortComboBox.TabIndex = 8;
            // 
            // GetAvailablePortsButton
            // 
            this.GetAvailablePortsButton.Location = new System.Drawing.Point(239, 12);
            this.GetAvailablePortsButton.Name = "GetAvailablePortsButton";
            this.GetAvailablePortsButton.Size = new System.Drawing.Size(114, 21);
            this.GetAvailablePortsButton.TabIndex = 9;
            this.GetAvailablePortsButton.Text = "Get available ports";
            this.GetAvailablePortsButton.UseVisualStyleBackColor = true;
            this.GetAvailablePortsButton.Click += new System.EventHandler(this.GetAvailablePortsButton_Click);
            // 
            // ParityComboBox
            // 
            this.ParityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ParityComboBox.FormattingEnabled = true;
            this.ParityComboBox.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.ParityComboBox.Location = new System.Drawing.Point(90, 74);
            this.ParityComboBox.Name = "ParityComboBox";
            this.ParityComboBox.Size = new System.Drawing.Size(121, 21);
            this.ParityComboBox.TabIndex = 10;
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.Enabled = false;
            this.SaveSettingsButton.Location = new System.Drawing.Point(239, 133);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(114, 21);
            this.SaveSettingsButton.TabIndex = 11;
            this.SaveSettingsButton.Text = "Save and Close";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // SpeedComboBox
            // 
            this.SpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpeedComboBox.FormattingEnabled = true;
            this.SpeedComboBox.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200"});
            this.SpeedComboBox.Location = new System.Drawing.Point(90, 106);
            this.SpeedComboBox.Name = "SpeedComboBox";
            this.SpeedComboBox.Size = new System.Drawing.Size(121, 21);
            this.SpeedComboBox.TabIndex = 12;
            // 
            // DataBitsComboBox
            // 
            this.DataBitsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DataBitsComboBox.FormattingEnabled = true;
            this.DataBitsComboBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.DataBitsComboBox.Location = new System.Drawing.Point(90, 133);
            this.DataBitsComboBox.Name = "DataBitsComboBox";
            this.DataBitsComboBox.Size = new System.Drawing.Size(121, 21);
            this.DataBitsComboBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Test connection to ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "be able to save!";
            // 
            // ConnectionTestTimer
            // 
            this.ConnectionTestTimer.Tick += new System.EventHandler(this.ConnectionTestTimer_Tick);
            // 
            // ConnectionSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 169);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DataBitsComboBox);
            this.Controls.Add(this.SpeedComboBox);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.ParityComboBox);
            this.Controls.Add(this.GetAvailablePortsButton);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TestConnectionButton);
            this.Controls.Add(this.StopBitComboBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connection Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox StopBitComboBox;
        private System.Windows.Forms.Button TestConnectionButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.Button GetAvailablePortsButton;
        private System.Windows.Forms.ComboBox ParityComboBox;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.ComboBox SpeedComboBox;
        private System.Windows.Forms.ComboBox DataBitsComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer ConnectionTestTimer;
    }
}

