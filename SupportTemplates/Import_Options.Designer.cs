namespace SupportTemplates
{
    partial class Import_Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import_Options));
            this.label1 = new System.Windows.Forms.Label();
            this.Overwrite_btn = new System.Windows.Forms.Button();
            this.Insert_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Which type of import do you want to perform?";
            // 
            // Overwrite_btn
            // 
            this.Overwrite_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Overwrite_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Overwrite_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Overwrite_btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Overwrite_btn.Location = new System.Drawing.Point(12, 62);
            this.Overwrite_btn.Name = "Overwrite_btn";
            this.Overwrite_btn.Size = new System.Drawing.Size(98, 38);
            this.Overwrite_btn.TabIndex = 1;
            this.Overwrite_btn.Text = "Overwrite";
            this.toolTip1.SetToolTip(this.Overwrite_btn, "Overwrite the existing template list with the imported file.");
            this.Overwrite_btn.UseVisualStyleBackColor = false;
            this.Overwrite_btn.Click += new System.EventHandler(this.Overwrite_btn_Click);
            // 
            // Insert_btn
            // 
            this.Insert_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Insert_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Insert_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Insert_btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Insert_btn.Location = new System.Drawing.Point(132, 62);
            this.Insert_btn.Name = "Insert_btn";
            this.Insert_btn.Size = new System.Drawing.Size(98, 38);
            this.Insert_btn.TabIndex = 2;
            this.Insert_btn.Text = "Insert";
            this.toolTip1.SetToolTip(this.Insert_btn, "Insert the items from the imported file into the current file.");
            this.Insert_btn.UseVisualStyleBackColor = false;
            this.Insert_btn.Click += new System.EventHandler(this.Insert_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.Cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancel_btn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Cancel_btn.Location = new System.Drawing.Point(255, 62);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(98, 38);
            this.Cancel_btn.TabIndex = 3;
            this.Cancel_btn.Text = "Cancel";
            this.toolTip1.SetToolTip(this.Cancel_btn, "Close this window.");
            this.Cancel_btn.UseVisualStyleBackColor = false;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // Import_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_btn;
            this.ClientSize = new System.Drawing.Size(365, 112);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Insert_btn);
            this.Controls.Add(this.Overwrite_btn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Import_Options";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Overwrite_btn;
        private System.Windows.Forms.Button Insert_btn;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}