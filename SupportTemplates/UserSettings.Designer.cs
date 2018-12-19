namespace SupportTemplates
{
    partial class UserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettings));
            this.defaultTempCb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.defaultHK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lastBackupTb = new System.Windows.Forms.TextBox();
            this.backupDateLbl = new System.Windows.Forms.Label();
            this.backupLocTb = new System.Windows.Forms.TextBox();
            this.backupLocationLbl = new System.Windows.Forms.Label();
            this.backupDaysLbl = new System.Windows.Forms.Label();
            this.backupFreqCb = new System.Windows.Forms.ComboBox();
            this.backupFreqLbl = new System.Windows.Forms.Label();
            this.backupYesLbl = new System.Windows.Forms.Label();
            this.bacupNoLbl = new System.Windows.Forms.Label();
            this.backupTkb = new System.Windows.Forms.TrackBar();
            this.autoBackupLbl = new System.Windows.Forms.Label();
            this.defaultTypeLbl = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backupTkb)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultTempCb
            // 
            this.defaultTempCb.FormattingEnabled = true;
            this.defaultTempCb.Location = new System.Drawing.Point(262, 8);
            this.defaultTempCb.Name = "defaultTempCb";
            this.defaultTempCb.Size = new System.Drawing.Size(121, 21);
            this.defaultTempCb.Sorted = true;
            this.defaultTempCb.TabIndex = 0;
            this.defaultTempCb.Click += new System.EventHandler(this.defaultTempCb_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.defaultHK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lastBackupTb);
            this.panel1.Controls.Add(this.backupDateLbl);
            this.panel1.Controls.Add(this.backupLocTb);
            this.panel1.Controls.Add(this.backupLocationLbl);
            this.panel1.Controls.Add(this.backupDaysLbl);
            this.panel1.Controls.Add(this.backupFreqCb);
            this.panel1.Controls.Add(this.backupFreqLbl);
            this.panel1.Controls.Add(this.backupYesLbl);
            this.panel1.Controls.Add(this.bacupNoLbl);
            this.panel1.Controls.Add(this.backupTkb);
            this.panel1.Controls.Add(this.autoBackupLbl);
            this.panel1.Controls.Add(this.defaultTypeLbl);
            this.panel1.Controls.Add(this.defaultTempCb);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 301);
            this.panel1.TabIndex = 1;
            // 
            // defaultHK
            // 
            this.defaultHK.Location = new System.Drawing.Point(236, 180);
            this.defaultHK.Name = "defaultHK";
            this.defaultHK.Size = new System.Drawing.Size(145, 20);
            this.defaultHK.TabIndex = 14;
            this.defaultHK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.defaultHK_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(14, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Default HotKey";
            // 
            // lastBackupTb
            // 
            this.lastBackupTb.Enabled = false;
            this.lastBackupTb.Location = new System.Drawing.Point(236, 145);
            this.lastBackupTb.Name = "lastBackupTb";
            this.lastBackupTb.Size = new System.Drawing.Size(145, 20);
            this.lastBackupTb.TabIndex = 12;
            // 
            // backupDateLbl
            // 
            this.backupDateLbl.AutoSize = true;
            this.backupDateLbl.Enabled = false;
            this.backupDateLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.backupDateLbl.Location = new System.Drawing.Point(36, 145);
            this.backupDateLbl.Name = "backupDateLbl";
            this.backupDateLbl.Size = new System.Drawing.Size(70, 13);
            this.backupDateLbl.TabIndex = 11;
            this.backupDateLbl.Text = "Last Backup:";
            // 
            // backupLocTb
            // 
            this.backupLocTb.Enabled = false;
            this.backupLocTb.Location = new System.Drawing.Point(93, 106);
            this.backupLocTb.Name = "backupLocTb";
            this.backupLocTb.Size = new System.Drawing.Size(288, 20);
            this.backupLocTb.TabIndex = 10;
            this.backupLocTb.Click += new System.EventHandler(this.backupLocTb_Click);
            // 
            // backupLocationLbl
            // 
            this.backupLocationLbl.AutoSize = true;
            this.backupLocationLbl.Enabled = false;
            this.backupLocationLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.backupLocationLbl.Location = new System.Drawing.Point(36, 109);
            this.backupLocationLbl.Name = "backupLocationLbl";
            this.backupLocationLbl.Size = new System.Drawing.Size(51, 13);
            this.backupLocationLbl.TabIndex = 9;
            this.backupLocationLbl.Text = "Location:";
            // 
            // backupDaysLbl
            // 
            this.backupDaysLbl.AutoSize = true;
            this.backupDaysLbl.Enabled = false;
            this.backupDaysLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.backupDaysLbl.Location = new System.Drawing.Point(350, 76);
            this.backupDaysLbl.Name = "backupDaysLbl";
            this.backupDaysLbl.Size = new System.Drawing.Size(31, 13);
            this.backupDaysLbl.TabIndex = 8;
            this.backupDaysLbl.Text = "Days";
            // 
            // backupFreqCb
            // 
            this.backupFreqCb.Enabled = false;
            this.backupFreqCb.FormattingEnabled = true;
            this.backupFreqCb.Location = new System.Drawing.Point(303, 73);
            this.backupFreqCb.Name = "backupFreqCb";
            this.backupFreqCb.Size = new System.Drawing.Size(41, 21);
            this.backupFreqCb.TabIndex = 7;
            // 
            // backupFreqLbl
            // 
            this.backupFreqLbl.AutoSize = true;
            this.backupFreqLbl.Enabled = false;
            this.backupFreqLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.backupFreqLbl.Location = new System.Drawing.Point(36, 76);
            this.backupFreqLbl.Name = "backupFreqLbl";
            this.backupFreqLbl.Size = new System.Drawing.Size(77, 13);
            this.backupFreqLbl.TabIndex = 6;
            this.backupFreqLbl.Text = "Backup Every:";
            // 
            // backupYesLbl
            // 
            this.backupYesLbl.AutoSize = true;
            this.backupYesLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.backupYesLbl.Location = new System.Drawing.Point(356, 41);
            this.backupYesLbl.Name = "backupYesLbl";
            this.backupYesLbl.Size = new System.Drawing.Size(25, 13);
            this.backupYesLbl.TabIndex = 5;
            this.backupYesLbl.Text = "Yes";
            // 
            // bacupNoLbl
            // 
            this.bacupNoLbl.AutoSize = true;
            this.bacupNoLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bacupNoLbl.Location = new System.Drawing.Point(259, 41);
            this.bacupNoLbl.Name = "bacupNoLbl";
            this.bacupNoLbl.Size = new System.Drawing.Size(21, 13);
            this.bacupNoLbl.TabIndex = 4;
            this.bacupNoLbl.Text = "No";
            // 
            // backupTkb
            // 
            this.backupTkb.LargeChange = 1;
            this.backupTkb.Location = new System.Drawing.Point(286, 41);
            this.backupTkb.Maximum = 1;
            this.backupTkb.Name = "backupTkb";
            this.backupTkb.Size = new System.Drawing.Size(64, 45);
            this.backupTkb.TabIndex = 3;
            this.backupTkb.TickStyle = System.Windows.Forms.TickStyle.None;
            this.backupTkb.Scroll += new System.EventHandler(this.backupTkb_Scroll);
            // 
            // autoBackupLbl
            // 
            this.autoBackupLbl.AutoSize = true;
            this.autoBackupLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.autoBackupLbl.Location = new System.Drawing.Point(14, 41);
            this.autoBackupLbl.Name = "autoBackupLbl";
            this.autoBackupLbl.Size = new System.Drawing.Size(75, 13);
            this.autoBackupLbl.TabIndex = 2;
            this.autoBackupLbl.Text = "Auto Backup?";
            // 
            // defaultTypeLbl
            // 
            this.defaultTypeLbl.AutoSize = true;
            this.defaultTypeLbl.ForeColor = System.Drawing.SystemColors.Highlight;
            this.defaultTypeLbl.Location = new System.Drawing.Point(14, 8);
            this.defaultTypeLbl.Name = "defaultTypeLbl";
            this.defaultTypeLbl.Size = new System.Drawing.Size(118, 13);
            this.defaultTypeLbl.TabIndex = 1;
            this.defaultTypeLbl.Text = "Default Template Type:";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.closeBtn.Location = new System.Drawing.Point(428, 273);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(107, 40);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "Close";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveBtn.Location = new System.Drawing.Point(428, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(107, 40);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(547, 324);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backupTkb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox defaultTempCb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label defaultTypeLbl;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label autoBackupLbl;
        private System.Windows.Forms.Label backupYesLbl;
        private System.Windows.Forms.Label bacupNoLbl;
        private System.Windows.Forms.TrackBar backupTkb;
        private System.Windows.Forms.TextBox backupLocTb;
        private System.Windows.Forms.Label backupLocationLbl;
        private System.Windows.Forms.Label backupDaysLbl;
        private System.Windows.Forms.ComboBox backupFreqCb;
        private System.Windows.Forms.Label backupFreqLbl;
        private System.Windows.Forms.TextBox lastBackupTb;
        private System.Windows.Forms.Label backupDateLbl;
        private System.Windows.Forms.TextBox defaultHK;
        private System.Windows.Forms.Label label1;
    }
}