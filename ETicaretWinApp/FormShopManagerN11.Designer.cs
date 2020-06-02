namespace ETicaretWinApp
{
    partial class FormShopManagerN11
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProductManager = new System.Windows.Forms.TabPage();
            this.buttonDisableProduct = new System.Windows.Forms.Button();
            this.buttonUpdateProductPrice = new System.Windows.Forms.Button();
            this.buttonCheckStok = new System.Windows.Forms.Button();
            this.comboBoxPageItemCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPageNumber = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControlProducts = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonOpenProduct = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageProductManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageProductManager);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1381, 572);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageProductManager
            // 
            this.tabPageProductManager.Controls.Add(this.buttonOpenProduct);
            this.tabPageProductManager.Controls.Add(this.buttonDisableProduct);
            this.tabPageProductManager.Controls.Add(this.buttonUpdateProductPrice);
            this.tabPageProductManager.Controls.Add(this.buttonCheckStok);
            this.tabPageProductManager.Controls.Add(this.comboBoxPageItemCount);
            this.tabPageProductManager.Controls.Add(this.label2);
            this.tabPageProductManager.Controls.Add(this.comboBoxPageNumber);
            this.tabPageProductManager.Controls.Add(this.label1);
            this.tabPageProductManager.Controls.Add(this.gridControlProducts);
            this.tabPageProductManager.Location = new System.Drawing.Point(4, 24);
            this.tabPageProductManager.Name = "tabPageProductManager";
            this.tabPageProductManager.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProductManager.Size = new System.Drawing.Size(1373, 544);
            this.tabPageProductManager.TabIndex = 0;
            this.tabPageProductManager.Text = "Ürün Yönetimi";
            this.tabPageProductManager.UseVisualStyleBackColor = true;
            // 
            // buttonDisableProduct
            // 
            this.buttonDisableProduct.Location = new System.Drawing.Point(641, 11);
            this.buttonDisableProduct.Name = "buttonDisableProduct";
            this.buttonDisableProduct.Size = new System.Drawing.Size(229, 37);
            this.buttonDisableProduct.TabIndex = 7;
            this.buttonDisableProduct.Text = "Ürünleri Satışa Kapat";
            this.buttonDisableProduct.UseVisualStyleBackColor = true;
            this.buttonDisableProduct.Click += new System.EventHandler(this.buttonDisableProduct_Click);
            // 
            // buttonUpdateProductPrice
            // 
            this.buttonUpdateProductPrice.Location = new System.Drawing.Point(888, 11);
            this.buttonUpdateProductPrice.Name = "buttonUpdateProductPrice";
            this.buttonUpdateProductPrice.Size = new System.Drawing.Size(229, 37);
            this.buttonUpdateProductPrice.TabIndex = 6;
            this.buttonUpdateProductPrice.Text = "Fiyat Güncellemesi";
            this.buttonUpdateProductPrice.UseVisualStyleBackColor = true;
            this.buttonUpdateProductPrice.Click += new System.EventHandler(this.buttonUpdateProductPrice_Click);
            // 
            // buttonCheckStok
            // 
            this.buttonCheckStok.Location = new System.Drawing.Point(1134, 11);
            this.buttonCheckStok.Name = "buttonCheckStok";
            this.buttonCheckStok.Size = new System.Drawing.Size(229, 37);
            this.buttonCheckStok.TabIndex = 5;
            this.buttonCheckStok.Text = "Stok Kontrolü Yap";
            this.buttonCheckStok.UseVisualStyleBackColor = true;
            this.buttonCheckStok.Click += new System.EventHandler(this.buttonCheckStok_Click);
            // 
            // comboBoxPageItemCount
            // 
            this.comboBoxPageItemCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPageItemCount.FormattingEnabled = true;
            this.comboBoxPageItemCount.Items.AddRange(new object[] {
            "20",
            "50",
            "100"});
            this.comboBoxPageItemCount.Location = new System.Drawing.Point(382, 21);
            this.comboBoxPageItemCount.Name = "comboBoxPageItemCount";
            this.comboBoxPageItemCount.Size = new System.Drawing.Size(155, 23);
            this.comboBoxPageItemCount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sayfa Ürün Sayısı";
            // 
            // comboBoxPageNumber
            // 
            this.comboBoxPageNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPageNumber.FormattingEnabled = true;
            this.comboBoxPageNumber.Location = new System.Drawing.Point(97, 20);
            this.comboBoxPageNumber.Name = "comboBoxPageNumber";
            this.comboBoxPageNumber.Size = new System.Drawing.Size(155, 23);
            this.comboBoxPageNumber.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sayfa Sayısı";
            // 
            // gridControlProducts
            // 
            this.gridControlProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlProducts.Location = new System.Drawing.Point(11, 120);
            this.gridControlProducts.MainView = this.gridView1;
            this.gridControlProducts.Name = "gridControlProducts";
            this.gridControlProducts.Size = new System.Drawing.Size(1352, 413);
            this.gridControlProducts.TabIndex = 0;
            this.gridControlProducts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlProducts;
            this.gridView1.Name = "gridView1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1373, 544);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonOpenProduct
            // 
            this.buttonOpenProduct.Location = new System.Drawing.Point(641, 67);
            this.buttonOpenProduct.Name = "buttonOpenProduct";
            this.buttonOpenProduct.Size = new System.Drawing.Size(229, 37);
            this.buttonOpenProduct.TabIndex = 8;
            this.buttonOpenProduct.Text = "Ürünleri Satışa Aç";
            this.buttonOpenProduct.UseVisualStyleBackColor = true;
            this.buttonOpenProduct.Click += new System.EventHandler(this.buttonOpenProduct_Click);
            // 
            // FormShopManagerN11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 624);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "FormShopManagerN11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "N11 Yönetim";
            this.tabControl1.ResumeLayout(false);
            this.tabPageProductManager.ResumeLayout(false);
            this.tabPageProductManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProductManager;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl gridControlProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPageNumber;
        private System.Windows.Forms.ComboBox comboBoxPageItemCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCheckStok;
        private System.Windows.Forms.Button buttonUpdateProductPrice;
        private System.Windows.Forms.Button buttonDisableProduct;
        private System.Windows.Forms.Button buttonOpenProduct;
    }
}