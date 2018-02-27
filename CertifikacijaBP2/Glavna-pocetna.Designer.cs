namespace CertifikacijaBP2
{
    partial class Glavna_pocetna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Glavna_pocetna));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.testovibtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(269, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(157, 117);
            this.button2.TabIndex = 1;
            this.button2.Text = "Certifikati";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(78, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 117);
            this.button1.TabIndex = 0;
            this.button1.Text = "Polaznici";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(269, 221);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 117);
            this.button3.TabIndex = 3;
            this.button3.Text = "Rezultati";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // testovibtn
            // 
            this.testovibtn.Image = ((System.Drawing.Image)(resources.GetObject("testovibtn.Image")));
            this.testovibtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.testovibtn.Location = new System.Drawing.Point(78, 221);
            this.testovibtn.Name = "testovibtn";
            this.testovibtn.Size = new System.Drawing.Size(157, 117);
            this.testovibtn.TabIndex = 2;
            this.testovibtn.Text = "Testovi";
            this.testovibtn.UseVisualStyleBackColor = true;
            this.testovibtn.Click += new System.EventHandler(this.testovibtn_Click);
            // 
            // Glavna_pocetna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 413);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.testovibtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Glavna_pocetna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Certifikacija";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button testovibtn;
    }
}