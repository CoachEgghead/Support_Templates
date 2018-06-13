namespace SupportTemplates
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TemplateText_tb = new System.Windows.Forms.TextBox();
            this.Copy_btn = new System.Windows.Forms.Button();
            this.NewTemplateName_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Save_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.About_btn = new System.Windows.Forms.Button();
            this.Reset_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Export_btn = new System.Windows.Forms.Button();
            this.Import_btn = new System.Windows.Forms.Button();
            this.Rename_btn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fontSizelbl = new System.Windows.Forms.Label();
            this.fontSizeval = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Margin = new System.Windows.Forms.Padding(0);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(225, 349);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // TemplateText_tb
            // 
            this.TemplateText_tb.AcceptsReturn = true;
            this.TemplateText_tb.AcceptsTab = true;
            this.TemplateText_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplateText_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemplateText_tb.Location = new System.Drawing.Point(0, 0);
            this.TemplateText_tb.Margin = new System.Windows.Forms.Padding(0);
            this.TemplateText_tb.Multiline = true;
            this.TemplateText_tb.Name = "TemplateText_tb";
            this.TemplateText_tb.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TemplateText_tb.Size = new System.Drawing.Size(582, 412);
            this.TemplateText_tb.TabIndex = 1;
            // 
            // Copy_btn
            // 
            this.Copy_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Copy_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Copy_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Copy_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Copy_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Copy_btn.Location = new System.Drawing.Point(835, 37);
            this.Copy_btn.Name = "Copy_btn";
            this.Copy_btn.Size = new System.Drawing.Size(82, 55);
            this.Copy_btn.TabIndex = 98;
            this.Copy_btn.Text = "Copy To Clipboard";
            this.toolTip1.SetToolTip(this.Copy_btn, "Copy textbox to your clipboard.");
            this.Copy_btn.UseVisualStyleBackColor = false;
            this.Copy_btn.Click += new System.EventHandler(this.Copy_btn_Click);
            // 
            // NewTemplateName_tb
            // 
            this.NewTemplateName_tb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTemplateName_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewTemplateName_tb.Location = new System.Drawing.Point(0, 391);
            this.NewTemplateName_tb.MaxLength = 100;
            this.NewTemplateName_tb.MinimumSize = new System.Drawing.Size(225, 20);
            this.NewTemplateName_tb.Name = "NewTemplateName_tb";
            this.NewTemplateName_tb.Size = new System.Drawing.Size(225, 21);
            this.NewTemplateName_tb.TabIndex = 2;
            this.toolTip1.SetToolTip(this.NewTemplateName_tb, "Enter a new template name here.");
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(-3, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "New Template Name:";
            // 
            // Save_btn
            // 
            this.Save_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Save_btn.Location = new System.Drawing.Point(143, 364);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(82, 23);
            this.Save_btn.TabIndex = 3;
            this.Save_btn.Text = "Save";
            this.toolTip1.SetToolTip(this.Save_btn, "Save your template.");
            this.Save_btn.UseVisualStyleBackColor = false;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delete_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Delete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Delete_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Delete_btn.Location = new System.Drawing.Point(835, 236);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(82, 23);
            this.Delete_btn.TabIndex = 99;
            this.Delete_btn.Text = "Delete";
            this.toolTip1.SetToolTip(this.Delete_btn, "*** CAUTION ***\r\nThis will delete the selected template.\r\nThere is no way to rest" +
        "ore a deleted template.");
            this.Delete_btn.UseVisualStyleBackColor = false;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // About_btn
            // 
            this.About_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.About_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.About_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.About_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.About_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.About_btn.Location = new System.Drawing.Point(835, 376);
            this.About_btn.Name = "About_btn";
            this.About_btn.Size = new System.Drawing.Size(82, 23);
            this.About_btn.TabIndex = 95;
            this.About_btn.Text = "About";
            this.toolTip1.SetToolTip(this.About_btn, "Display information about this application.");
            this.About_btn.UseVisualStyleBackColor = false;
            this.About_btn.Click += new System.EventHandler(this.About_btn_Click);
            // 
            // Reset_btn
            // 
            this.Reset_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Reset_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Reset_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Reset_btn.Location = new System.Drawing.Point(835, 315);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(82, 40);
            this.Reset_btn.TabIndex = 96;
            this.Reset_btn.Text = "Reset To Default";
            this.toolTip1.SetToolTip(this.Reset_btn, "*** CAUTION ***\r\nResets the application to the default set of templates.\r\nThis wi" +
        "ll erase any saved templates.");
            this.Reset_btn.UseVisualStyleBackColor = false;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Clear_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Clear_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Clear_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Clear_btn.Location = new System.Drawing.Point(835, 98);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Size = new System.Drawing.Size(82, 36);
            this.Clear_btn.TabIndex = 97;
            this.Clear_btn.Text = "Clear / New";
            this.toolTip1.SetToolTip(this.Clear_btn, "Clears the box to the left that displays the template text.");
            this.Clear_btn.UseVisualStyleBackColor = false;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // Export_btn
            // 
            this.Export_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Export_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Export_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Export_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Export_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Export_btn.Location = new System.Drawing.Point(835, 157);
            this.Export_btn.Name = "Export_btn";
            this.Export_btn.Size = new System.Drawing.Size(82, 23);
            this.Export_btn.TabIndex = 100;
            this.Export_btn.Text = "Export";
            this.toolTip1.SetToolTip(this.Export_btn, "Export/Backup your templates to a drive.");
            this.Export_btn.UseVisualStyleBackColor = false;
            this.Export_btn.Click += new System.EventHandler(this.Export_btn_Click);
            // 
            // Import_btn
            // 
            this.Import_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Import_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Import_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Import_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Import_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Import_btn.Location = new System.Drawing.Point(835, 186);
            this.Import_btn.Name = "Import_btn";
            this.Import_btn.Size = new System.Drawing.Size(82, 23);
            this.Import_btn.TabIndex = 101;
            this.Import_btn.Text = "Import";
            this.toolTip1.SetToolTip(this.Import_btn, "Import another template file.  This will create a backup of your existing templat" +
        "es to the desktop.");
            this.Import_btn.UseVisualStyleBackColor = false;
            this.Import_btn.Click += new System.EventHandler(this.Import_btn_Click);
            // 
            // Rename_btn
            // 
            this.Rename_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rename_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Rename_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Rename_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rename_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Rename_btn.Location = new System.Drawing.Point(835, 265);
            this.Rename_btn.Name = "Rename_btn";
            this.Rename_btn.Size = new System.Drawing.Size(82, 23);
            this.Rename_btn.TabIndex = 102;
            this.Rename_btn.Text = "Rename";
            this.toolTip1.SetToolTip(this.Rename_btn, "Rename a template.");
            this.Rename_btn.UseVisualStyleBackColor = false;
            this.Rename_btn.Click += new System.EventHandler(this.Rename_btn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 23);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.comboBox1, "Select a type of item to display.");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // refresh_btn
            // 
            this.refresh_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.refresh_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refresh_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.refresh_btn.Location = new System.Drawing.Point(241, 9);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(75, 23);
            this.refresh_btn.TabIndex = 105;
            this.refresh_btn.Text = "Refresh";
            this.toolTip1.SetToolTip(this.refresh_btn, "Refresh the list of items based on the selected type.");
            this.refresh_btn.UseVisualStyleBackColor = false;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.checkBox1.Location = new System.Drawing.Point(323, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(100, 17);
            this.checkBox1.TabIndex = 106;
            this.checkBox1.Text = "Auto-Refresh";
            this.toolTip1.SetToolTip(this.checkBox1, "When checked the list of items will auto-refresh when you select a different type" +
        ". \r\nUncheck when changing the type of an existing item.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.LargeChange = 3;
            this.trackBar1.Location = new System.Drawing.Point(835, 427);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Minimum = 8;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(82, 45);
            this.trackBar1.TabIndex = 107;
            this.toolTip1.SetToolTip(this.trackBar1, "Change the font size of the main text box.");
            this.trackBar1.Value = 8;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Location = new System.Drawing.Point(9, 37);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.NewTemplateName_tb);
            this.splitContainer1.Panel1.Controls.Add(this.Save_btn);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.splitContainer1.Panel1MinSize = 225;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.splitContainer1.Panel2.Controls.Add(this.TemplateText_tb);
            this.splitContainer1.Panel2MinSize = 225;
            this.splitContainer1.Size = new System.Drawing.Size(812, 412);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 104;
            // 
            // fontSizelbl
            // 
            this.fontSizelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizelbl.AutoSize = true;
            this.fontSizelbl.Location = new System.Drawing.Point(835, 410);
            this.fontSizelbl.Name = "fontSizelbl";
            this.fontSizelbl.Size = new System.Drawing.Size(57, 13);
            this.fontSizelbl.TabIndex = 108;
            this.fontSizelbl.Text = "Font Size: ";
            // 
            // fontSizeval
            // 
            this.fontSizeval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fontSizeval.AutoSize = true;
            this.fontSizeval.Location = new System.Drawing.Point(892, 410);
            this.fontSizeval.Name = "fontSizeval";
            this.fontSizeval.Size = new System.Drawing.Size(0, 13);
            this.fontSizeval.TabIndex = 109;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(929, 461);
            this.Controls.Add(this.fontSizeval);
            this.Controls.Add(this.fontSizelbl);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Rename_btn);
            this.Controls.Add(this.Import_btn);
            this.Controls.Add(this.Export_btn);
            this.Controls.Add(this.Clear_btn);
            this.Controls.Add(this.Reset_btn);
            this.Controls.Add(this.About_btn);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Copy_btn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(945, 500);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Support Templates";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TemplateText_tb;
        private System.Windows.Forms.Button Copy_btn;
        private System.Windows.Forms.TextBox NewTemplateName_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Button Delete_btn;
        private System.Windows.Forms.Button About_btn;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Export_btn;
        private System.Windows.Forms.Button Import_btn;
        private System.Windows.Forms.Button Rename_btn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label fontSizelbl;
        private System.Windows.Forms.Label fontSizeval;
    }
}

