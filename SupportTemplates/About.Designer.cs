namespace SupportTemplates
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HelpLink_lbl = new System.Windows.Forms.LinkLabel();
            this.donationLbl = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.versionCheck_btn = new System.Windows.Forms.Button();
            this.Download_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(66, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Support Templates";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(118, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "version";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(93, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 82);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // HelpLink_lbl
            // 
            this.HelpLink_lbl.AutoSize = true;
            this.HelpLink_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpLink_lbl.Location = new System.Drawing.Point(82, 106);
            this.HelpLink_lbl.Name = "HelpLink_lbl";
            this.HelpLink_lbl.Size = new System.Drawing.Size(122, 13);
            this.HelpLink_lbl.TabIndex = 5;
            this.HelpLink_lbl.TabStop = true;
            this.HelpLink_lbl.Text = "Help Documentation";
            this.HelpLink_lbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HelpLink_lbl_LinkClicked);
            // 
            // donationLbl
            // 
            this.donationLbl.AutoSize = true;
            this.donationLbl.Location = new System.Drawing.Point(90, 307);
            this.donationLbl.Name = "donationLbl";
            this.donationLbl.Size = new System.Drawing.Size(114, 13);
            this.donationLbl.TabIndex = 6;
            this.donationLbl.TabStop = true;
            this.donationLbl.Text = "Donations (PayPal.me)";
            this.donationLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.donationLbl_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(90, 77);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(106, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "View Version Info";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // versionCheck_btn
            // 
            this.versionCheck_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.versionCheck_btn.FlatAppearance.BorderSize = 0;
            this.versionCheck_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.versionCheck_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.versionCheck_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.versionCheck_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionCheck_btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.versionCheck_btn.Image = ((System.Drawing.Image)(resources.GetObject("versionCheck_btn.Image")));
            this.versionCheck_btn.Location = new System.Drawing.Point(12, 135);
            this.versionCheck_btn.Name = "versionCheck_btn";
            this.versionCheck_btn.Size = new System.Drawing.Size(135, 61);
            this.versionCheck_btn.TabIndex = 9;
            this.versionCheck_btn.Text = "Check for new version";
            this.versionCheck_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.versionCheck_btn.UseVisualStyleBackColor = false;
            this.versionCheck_btn.Click += new System.EventHandler(this.versionCheck_btn_Click);
            this.versionCheck_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.versionCheck_btn_MouseDown);
            this.versionCheck_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.versionCheck_btn_MouseUp);
            // 
            // Download_btn
            // 
            this.Download_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Download_btn.FlatAppearance.BorderSize = 0;
            this.Download_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.Download_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.Download_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Download_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Download_btn.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Download_btn.Image = ((System.Drawing.Image)(resources.GetObject("Download_btn.Image")));
            this.Download_btn.Location = new System.Drawing.Point(153, 134);
            this.Download_btn.Name = "Download_btn";
            this.Download_btn.Size = new System.Drawing.Size(121, 62);
            this.Download_btn.TabIndex = 10;
            this.Download_btn.Text = "Download Page";
            this.Download_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Download_btn.UseVisualStyleBackColor = false;
            this.Download_btn.Click += new System.EventHandler(this.Download_btn_Click);
            this.Download_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Download_btn_MouseDown);
            this.Download_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Download_btn_MouseUp);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(286, 342);
            this.Controls.Add(this.Download_btn);
            this.Controls.Add(this.versionCheck_btn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.donationLbl);
            this.Controls.Add(this.HelpLink_lbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel HelpLink_lbl;
        private System.Windows.Forms.LinkLabel donationLbl;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button versionCheck_btn;
        private System.Windows.Forms.Button Download_btn;
    }
}