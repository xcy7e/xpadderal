namespace XPadderal
{
    partial class ProfileOverlayForm
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
            this.lbl_profileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_profileName
            // 
            this.lbl_profileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_profileName.Font = new System.Drawing.Font("Exo", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_profileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_profileName.Location = new System.Drawing.Point(9, 6);
            this.lbl_profileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_profileName.Name = "lbl_profileName";
            this.lbl_profileName.Size = new System.Drawing.Size(246, 73);
            this.lbl_profileName.TabIndex = 0;
            this.lbl_profileName.Text = "VLC";
            this.lbl_profileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProfileOverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(264, 78);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_profileName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfileOverlayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ProfileOverlayForm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ProfileOverlayForm_Load);
            this.Click += new System.EventHandler(this.ProfileOverlayForm_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_profileName;
    }
}