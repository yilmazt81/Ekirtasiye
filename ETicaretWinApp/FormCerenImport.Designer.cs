namespace ETicaretWinApp
{
    partial class FormCerenImport
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
            this.nuUpDownLocked = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonGetProduct = new System.Windows.Forms.Button();
            this.buttonGetProductLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDownLocked)).BeginInit();
            this.SuspendLayout();
            // 
            // nuUpDownLocked
            // 
            this.nuUpDownLocked.Location = new System.Drawing.Point(120, 75);
            this.nuUpDownLocked.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuUpDownLocked.Name = "nuUpDownLocked";
            this.nuUpDownLocked.Size = new System.Drawing.Size(120, 20);
            this.nuUpDownLocked.TabIndex = 3;
            this.nuUpDownLocked.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Locked User";
            // 
            // buttonGetProduct
            // 
            this.buttonGetProduct.Location = new System.Drawing.Point(21, 120);
            this.buttonGetProduct.Name = "buttonGetProduct";
            this.buttonGetProduct.Size = new System.Drawing.Size(264, 23);
            this.buttonGetProduct.TabIndex = 1;
            this.buttonGetProduct.Text = "Ürünleri Import Et";
            this.buttonGetProduct.UseVisualStyleBackColor = true;
            this.buttonGetProduct.Click += new System.EventHandler(this.buttonGetProduct_Click);
            // 
            // buttonGetProductLink
            // 
            this.buttonGetProductLink.Location = new System.Drawing.Point(21, 17);
            this.buttonGetProductLink.Name = "buttonGetProductLink";
            this.buttonGetProductLink.Size = new System.Drawing.Size(264, 23);
            this.buttonGetProductLink.TabIndex = 0;
            this.buttonGetProductLink.Text = "Ürün Listesini Güncelle";
            this.buttonGetProductLink.UseVisualStyleBackColor = true;
            this.buttonGetProductLink.Click += new System.EventHandler(this.buttonGetProductLinks_Click);
            // 
            // FormCerenImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 190);
            this.Controls.Add(this.nuUpDownLocked);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonGetProduct);
            this.Controls.Add(this.buttonGetProductLink);
            this.Name = "FormCerenImport";
            this.Text = "FormCerenImport";
            this.Load += new System.EventHandler(this.FormCerenImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nuUpDownLocked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGetProductLink;
        private System.Windows.Forms.Button buttonGetProduct;
        private System.Windows.Forms.NumericUpDown nuUpDownLocked;
        private System.Windows.Forms.Label label2;
    }
}