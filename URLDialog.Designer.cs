namespace DeepwokenChecklist
{
    partial class URLDialog
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
            this.URLBox = new System.Windows.Forms.TextBox();
            this.LoadFromUrl = new System.Windows.Forms.Button();
            this.CancelDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(13, 13);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(256, 20);
            this.URLBox.TabIndex = 0;
            // 
            // LoadFromUrl
            // 
            this.LoadFromUrl.Location = new System.Drawing.Point(13, 40);
            this.LoadFromUrl.Name = "LoadFromUrl";
            this.LoadFromUrl.Size = new System.Drawing.Size(75, 23);
            this.LoadFromUrl.TabIndex = 1;
            this.LoadFromUrl.Text = "Load";
            this.LoadFromUrl.UseVisualStyleBackColor = true;
            this.LoadFromUrl.Click += new System.EventHandler(this.LoadFromUrl_Click);
            // 
            // CancelDialog
            // 
            this.CancelDialog.Location = new System.Drawing.Point(95, 39);
            this.CancelDialog.Name = "CancelDialog";
            this.CancelDialog.Size = new System.Drawing.Size(75, 23);
            this.CancelDialog.TabIndex = 2;
            this.CancelDialog.Text = "Cancel";
            this.CancelDialog.UseVisualStyleBackColor = true;
            this.CancelDialog.Click += new System.EventHandler(this.CancelDialog_Click);
            // 
            // URLDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 83);
            this.Controls.Add(this.CancelDialog);
            this.Controls.Add(this.LoadFromUrl);
            this.Controls.Add(this.URLBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "URLDialog";
            this.Text = "Deepwoken Builder URL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox URLBox;
        private System.Windows.Forms.Button LoadFromUrl;
        private System.Windows.Forms.Button CancelDialog;
    }
}