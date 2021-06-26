namespace BuildfilePRO
{
    partial class FileSelectWindow
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
            this.fileText = new System.Windows.Forms.TextBox();
            this.fileSelect = new System.Windows.Forms.Button();
            this.advanceWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileText
            // 
            this.fileText.Location = new System.Drawing.Point(13, 13);
            this.fileText.Name = "fileText";
            this.fileText.ReadOnly = true;
            this.fileText.Size = new System.Drawing.Size(233, 20);
            this.fileText.TabIndex = 0;
            // 
            // fileSelect
            // 
            this.fileSelect.Location = new System.Drawing.Point(252, 13);
            this.fileSelect.Name = "fileSelect";
            this.fileSelect.Size = new System.Drawing.Size(75, 20);
            this.fileSelect.TabIndex = 1;
            this.fileSelect.Text = "Browse";
            this.fileSelect.UseVisualStyleBackColor = true;
            this.fileSelect.Click += new System.EventHandler(this.fileSelect_Click);
            // 
            // advanceWindow
            // 
            this.advanceWindow.Enabled = false;
            this.advanceWindow.Location = new System.Drawing.Point(252, 39);
            this.advanceWindow.Name = "advanceWindow";
            this.advanceWindow.Size = new System.Drawing.Size(75, 20);
            this.advanceWindow.TabIndex = 2;
            this.advanceWindow.Text = "Go";
            this.advanceWindow.UseVisualStyleBackColor = true;
            this.advanceWindow.Click += new System.EventHandler(this.advanceWindow_Click);
            // 
            // FileSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 69);
            this.Controls.Add(this.advanceWindow);
            this.Controls.Add(this.fileSelect);
            this.Controls.Add(this.fileText);
            this.Name = "FileSelectWindow";
            this.Text = "Open Buildfile Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fileText;
        private System.Windows.Forms.Button fileSelect;
        private System.Windows.Forms.Button advanceWindow;
    }
}

