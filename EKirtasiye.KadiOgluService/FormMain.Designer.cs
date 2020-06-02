namespace EKirtasiye.KadiOgluService
{
    partial class FormMain
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(154, 71);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(97, 28);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Çalýþtýr";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.AutoSize = true;
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(149, 26);
            this.helloWorldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(226, 26);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Kadý Oðlu Web Servis";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 174);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Eksik Image Tamamla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(608, 26);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1129, 616);
            this.webBrowser1.TabIndex = 5;
 
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1749, 654);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.helloWorldLabel);
            this.Controls.Add(this.buttonStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}

