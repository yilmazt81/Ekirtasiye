namespace ETicaretWinApp
{
    partial class FormProductWebBrowser
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
            this.webBrowserProduct = new System.Windows.Forms.WebBrowser();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowserProduct
            // 
            this.webBrowserProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserProduct.Location = new System.Drawing.Point(13, 57);
            this.webBrowserProduct.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserProduct.Name = "webBrowserProduct";
            this.webBrowserProduct.Size = new System.Drawing.Size(917, 621);
            this.webBrowserProduct.TabIndex = 0;
            this.webBrowserProduct.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(84, 18);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(552, 20);
            this.textBoxProductName.TabIndex = 1;
            this.textBoxProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProductName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ürün Adı";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(652, 14);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Başla";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormProductWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 690);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.webBrowserProduct);
            this.Name = "FormProductWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Web Tarayıcı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserProduct;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
    }
}