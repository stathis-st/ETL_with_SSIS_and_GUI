namespace SkyBridgeProject
{
    partial class Intro
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
            this.txtZipFilePath = new System.Windows.Forms.TextBox();
            this.lblZipFilePath = new System.Windows.Forms.Label();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnUnzip = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtZipFilePath
            // 
            this.txtZipFilePath.Location = new System.Drawing.Point(11, 28);
            this.txtZipFilePath.Name = "txtZipFilePath";
            this.txtZipFilePath.Size = new System.Drawing.Size(179, 20);
            this.txtZipFilePath.TabIndex = 0;
            // 
            // lblZipFilePath
            // 
            this.lblZipFilePath.AutoSize = true;
            this.lblZipFilePath.Location = new System.Drawing.Point(12, 9);
            this.lblZipFilePath.Name = "lblZipFilePath";
            this.lblZipFilePath.Size = new System.Drawing.Size(94, 13);
            this.lblZipFilePath.TabIndex = 1;
            this.lblZipFilePath.Text = "Path of the zip file:";
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new System.Drawing.Point(11, 57);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(72, 17);
            this.chkPassword.TabIndex = 2;
            this.chkPassword.Text = "Password";
            this.chkPassword.UseVisualStyleBackColor = true;
            this.chkPassword.CheckedChanged += new System.EventHandler(this.chkPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(90, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnUnzip
            // 
            this.btnUnzip.Location = new System.Drawing.Point(11, 81);
            this.btnUnzip.Name = "btnUnzip";
            this.btnUnzip.Size = new System.Drawing.Size(178, 23);
            this.btnUnzip.TabIndex = 4;
            this.btnUnzip.Text = "Unzip";
            this.btnUnzip.UseVisualStyleBackColor = true;
            this.btnUnzip.Click += new System.EventHandler(this.btnUnzip_Click);
            // 
            // Intro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 111);
            this.Controls.Add(this.btnUnzip);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkPassword);
            this.Controls.Add(this.lblZipFilePath);
            this.Controls.Add(this.txtZipFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Intro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sky Bridge";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtZipFilePath;
        private System.Windows.Forms.Label lblZipFilePath;
        private System.Windows.Forms.CheckBox chkPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnUnzip;
    }
}

