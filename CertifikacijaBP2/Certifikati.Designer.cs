namespace CertifikacijaBP2
{
    partial class Certifikati
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
            this.odustanibtn = new System.Windows.Forms.Button();
            this.printDocument2 = new System.Drawing.Printing.PrintDocument();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // odustanibtn
            // 
            this.odustanibtn.Location = new System.Drawing.Point(184, 72);
            this.odustanibtn.Name = "odustanibtn";
            this.odustanibtn.Size = new System.Drawing.Size(75, 23);
            this.odustanibtn.TabIndex = 2;
            this.odustanibtn.Text = "Odustani";
            this.odustanibtn.UseVisualStyleBackColor = true;
            this.odustanibtn.Click += new System.EventHandler(this.odustanibtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ispiši certifikat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Certifikati
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 140);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.odustanibtn);
            this.Name = "Certifikati";
            this.Text = "Certifikati";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button odustanibtn;
        private System.Drawing.Printing.PrintDocument printDocument2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog2;
    }
}