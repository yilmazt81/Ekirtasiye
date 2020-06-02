namespace EKirtasiyeWebReader
{
    partial class Form1
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
            this.buttonProductCategory = new System.Windows.Forms.Button();
            this.buttonGetProduct = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonProductCategory
            // 
            this.buttonProductCategory.Location = new System.Drawing.Point(34, 45);
            this.buttonProductCategory.Name = "buttonProductCategory";
            this.buttonProductCategory.Size = new System.Drawing.Size(152, 45);
            this.buttonProductCategory.TabIndex = 0;
            this.buttonProductCategory.Text = "Ürün Category";
            this.buttonProductCategory.UseVisualStyleBackColor = true;
            this.buttonProductCategory.Click += new System.EventHandler(this.buttonProductCategory_Click);
            // 
            // buttonGetProduct
            // 
            this.buttonGetProduct.Location = new System.Drawing.Point(257, 45);
            this.buttonGetProduct.Name = "buttonGetProduct";
            this.buttonGetProduct.Size = new System.Drawing.Size(152, 45);
            this.buttonGetProduct.TabIndex = 1;
            this.buttonGetProduct.Text = "Category Ürün Getir";
            this.buttonGetProduct.UseVisualStyleBackColor = true;
            this.buttonGetProduct.Click += new System.EventHandler(this.buttonGetProduct_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(450, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ürün Getir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 193);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGetProduct);
            this.Controls.Add(this.buttonProductCategory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonProductCategory;
        private System.Windows.Forms.Button buttonGetProduct;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

