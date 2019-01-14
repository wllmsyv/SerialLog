namespace SerialLogger
{
    partial class SerialLogger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialLogger));
            this.aquire = new System.Windows.Forms.Button();
            this.communicationTraffic = new System.Windows.Forms.TextBox();
            this.availableConnections = new System.Windows.Forms.ComboBox();
            this.connect = new System.Windows.Forms.Button();
            this.command = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.noLog = new System.Windows.Forms.RadioButton();
            this.logCSV = new System.Windows.Forms.RadioButton();
            this.logAndCompress = new System.Windows.Forms.RadioButton();
            this.closeConnection = new System.Windows.Forms.Button();
            this.loggingGroup = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.baudRateCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.filePathTB = new System.Windows.Forms.TextBox();
            this.setFilePath = new System.Windows.Forms.Button();
            this.fileNameTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.loggingGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // aquire
            // 
            this.aquire.Location = new System.Drawing.Point(15, 19);
            this.aquire.Name = "aquire";
            this.aquire.Size = new System.Drawing.Size(75, 23);
            this.aquire.TabIndex = 0;
            this.aquire.Text = "Aquire";
            this.aquire.UseVisualStyleBackColor = true;
            this.aquire.Click += new System.EventHandler(this.aquire_Click);
            // 
            // communicationTraffic
            // 
            this.communicationTraffic.Location = new System.Drawing.Point(37, 38);
            this.communicationTraffic.MaxLength = 0;
            this.communicationTraffic.Multiline = true;
            this.communicationTraffic.Name = "communicationTraffic";
            this.communicationTraffic.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.communicationTraffic.Size = new System.Drawing.Size(700, 200);
            this.communicationTraffic.TabIndex = 1;
            // 
            // availableConnections
            // 
            this.availableConnections.Enabled = false;
            this.availableConnections.FormattingEnabled = true;
            this.availableConnections.Location = new System.Drawing.Point(37, 319);
            this.availableConnections.Name = "availableConnections";
            this.availableConnections.Size = new System.Drawing.Size(316, 21);
            this.availableConnections.TabIndex = 2;
            // 
            // connect
            // 
            this.connect.Enabled = false;
            this.connect.Location = new System.Drawing.Point(15, 45);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 3;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // command
            // 
            this.command.AcceptsReturn = true;
            this.command.Enabled = false;
            this.command.Location = new System.Drawing.Point(37, 265);
            this.command.Multiline = true;
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(316, 20);
            this.command.TabIndex = 4;
            this.command.TextChanged += new System.EventHandler(this.command_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Log Window";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Command";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connection";
            // 
            // noLog
            // 
            this.noLog.AutoSize = true;
            this.noLog.Checked = true;
            this.noLog.Location = new System.Drawing.Point(33, 28);
            this.noLog.Name = "noLog";
            this.noLog.Size = new System.Drawing.Size(60, 17);
            this.noLog.TabIndex = 8;
            this.noLog.TabStop = true;
            this.noLog.Text = "No Log";
            this.noLog.UseVisualStyleBackColor = true;
            this.noLog.CheckedChanged += new System.EventHandler(this.noLog_CheckedChanged);
            // 
            // logCSV
            // 
            this.logCSV.AutoSize = true;
            this.logCSV.Location = new System.Drawing.Point(33, 51);
            this.logCSV.Name = "logCSV";
            this.logCSV.Size = new System.Drawing.Size(67, 17);
            this.logCSV.TabIndex = 9;
            this.logCSV.Text = "Log CSV";
            this.logCSV.UseVisualStyleBackColor = true;
            this.logCSV.CheckedChanged += new System.EventHandler(this.logCSV_CheckedChanged);
            // 
            // logAndCompress
            // 
            this.logAndCompress.AutoSize = true;
            this.logAndCompress.Location = new System.Drawing.Point(33, 74);
            this.logAndCompress.Name = "logAndCompress";
            this.logAndCompress.Size = new System.Drawing.Size(113, 17);
            this.logAndCompress.TabIndex = 10;
            this.logAndCompress.Text = "Log and Compress";
            this.logAndCompress.UseVisualStyleBackColor = true;
            this.logAndCompress.Visible = false;
            this.logAndCompress.CheckedChanged += new System.EventHandler(this.logAndCompress_CheckedChanged);
            // 
            // closeConnection
            // 
            this.closeConnection.Enabled = false;
            this.closeConnection.Location = new System.Drawing.Point(15, 73);
            this.closeConnection.Name = "closeConnection";
            this.closeConnection.Size = new System.Drawing.Size(75, 23);
            this.closeConnection.TabIndex = 11;
            this.closeConnection.Text = "Close";
            this.closeConnection.UseVisualStyleBackColor = true;
            this.closeConnection.Click += new System.EventHandler(this.closeConnection_Click);
            // 
            // loggingGroup
            // 
            this.loggingGroup.Controls.Add(this.noLog);
            this.loggingGroup.Controls.Add(this.logCSV);
            this.loggingGroup.Controls.Add(this.logAndCompress);
            this.loggingGroup.Enabled = false;
            this.loggingGroup.Location = new System.Drawing.Point(579, 297);
            this.loggingGroup.Name = "loggingGroup";
            this.loggingGroup.Size = new System.Drawing.Size(158, 102);
            this.loggingGroup.TabIndex = 12;
            this.loggingGroup.TabStop = false;
            this.loggingGroup.Text = "Logging";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.aquire);
            this.groupBox2.Controls.Add(this.connect);
            this.groupBox2.Controls.Add(this.closeConnection);
            this.groupBox2.Location = new System.Drawing.Point(438, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 102);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Control";
            // 
            // baudRateCB
            // 
            this.baudRateCB.Enabled = false;
            this.baudRateCB.FormattingEnabled = true;
            this.baudRateCB.Location = new System.Drawing.Point(37, 367);
            this.baudRateCB.Name = "baudRateCB";
            this.baudRateCB.Size = new System.Drawing.Size(316, 21);
            this.baudRateCB.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Baud Rate";
            // 
            // filePathTB
            // 
            this.filePathTB.AcceptsReturn = true;
            this.filePathTB.Enabled = false;
            this.filePathTB.Location = new System.Drawing.Point(480, 242);
            this.filePathTB.Multiline = true;
            this.filePathTB.Name = "filePathTB";
            this.filePathTB.Size = new System.Drawing.Size(261, 20);
            this.filePathTB.TabIndex = 16;
            this.filePathTB.Text = "Choose File Location";
            // 
            // setFilePath
            // 
            this.setFilePath.Enabled = false;
            this.setFilePath.Location = new System.Drawing.Point(423, 242);
            this.setFilePath.Name = "setFilePath";
            this.setFilePath.Size = new System.Drawing.Size(51, 23);
            this.setFilePath.TabIndex = 18;
            this.setFilePath.Text = "...";
            this.setFilePath.UseVisualStyleBackColor = true;
            this.setFilePath.Click += new System.EventHandler(this.setFilePath_Click);
            // 
            // fileNameTB
            // 
            this.fileNameTB.AcceptsReturn = true;
            this.fileNameTB.Enabled = false;
            this.fileNameTB.Location = new System.Drawing.Point(480, 265);
            this.fileNameTB.Multiline = true;
            this.fileNameTB.Name = "fileNameTB";
            this.fileNameTB.Size = new System.Drawing.Size(261, 20);
            this.fileNameTB.TabIndex = 19;
            this.fileNameTB.TextChanged += new System.EventHandler(this.fileNameTB_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(420, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "File Name";
            // 
            // SerialLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 411);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.fileNameTB);
            this.Controls.Add(this.setFilePath);
            this.Controls.Add(this.filePathTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.baudRateCB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.loggingGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.command);
            this.Controls.Add(this.availableConnections);
            this.Controls.Add(this.communicationTraffic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SerialLogger";
            this.Text = "Serial Logger";
            this.Load += new System.EventHandler(this.SerialLogger_Load);
            this.loggingGroup.ResumeLayout(false);
            this.loggingGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button aquire;
        private System.Windows.Forms.TextBox communicationTraffic;
        private System.Windows.Forms.ComboBox availableConnections;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.TextBox command;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton noLog;
        private System.Windows.Forms.RadioButton logCSV;
        private System.Windows.Forms.RadioButton logAndCompress;
        private System.Windows.Forms.GroupBox loggingGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button closeConnection;
        private System.Windows.Forms.ComboBox baudRateCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filePathTB;
        private System.Windows.Forms.Button setFilePath;
        private System.Windows.Forms.TextBox fileNameTB;
        private System.Windows.Forms.Label label6;
    }
}

