namespace ETicaretWinApp
{
    partial class FormTrendyolExport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrendyolExport));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.MenuStripProduct = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBulkExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPriceUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeb_MainCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeb_Category = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeb_SubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRootProductStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWebPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarketPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWebExportStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastEdited = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLastEditedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN11ProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExportN11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.MenuStripProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.MenuStripProduct;
            this.gridControl1.Location = new System.Drawing.Point(175, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(783, 391);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // MenuStripProduct
            // 
            this.MenuStripProduct.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemEdit,
            this.MenuItemBulkExport,
            this.MenuItemPriceUpdate});
            this.MenuStripProduct.Name = "MenuStripProduct";
            this.MenuStripProduct.Size = new System.Drawing.Size(149, 70);
            // 
            // MenuItemEdit
            // 
            this.MenuItemEdit.Name = "MenuItemEdit";
            this.MenuItemEdit.Size = new System.Drawing.Size(148, 22);
            this.MenuItemEdit.Text = "Özellikler";
            // 
            // MenuItemBulkExport
            // 
            this.MenuItemBulkExport.Name = "MenuItemBulkExport";
            this.MenuItemBulkExport.Size = new System.Drawing.Size(148, 22);
            this.MenuItemBulkExport.Text = "Toplu Export";
            this.MenuItemBulkExport.Click += new System.EventHandler(this.MenuItemBulkExport_Click);
            // 
            // MenuItemPriceUpdate
            // 
            this.MenuItemPriceUpdate.Name = "MenuItemPriceUpdate";
            this.MenuItemPriceUpdate.Size = new System.Drawing.Size(148, 22);
            this.MenuItemPriceUpdate.Text = "Fiyat Güncelle";
            this.MenuItemPriceUpdate.Click += new System.EventHandler(this.MenuItemPriceUpdate_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStockCode,
            this.colLabel,
            this.colStatus,
            this.colBrand,
            this.colWeb_MainCategory,
            this.colWeb_Category,
            this.colWeb_SubCategory,
            this.colRootProductStockCode,
            this.colWebPrice,
            this.colMarketPrice,
            this.colCurrencyAbbr,
            this.colProductSource,
            this.colBarcode,
            this.colWebExportStatus,
            this.colLastEdited,
            this.colLastEditedDate,
            this.colN11ProductId,
            this.colExportN11});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colStockCode
            // 
            this.colStockCode.FieldName = "StockCode";
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 1;
            // 
            // colLabel
            // 
            this.colLabel.FieldName = "Label";
            this.colLabel.Name = "colLabel";
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 2;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            // 
            // colBrand
            // 
            this.colBrand.FieldName = "Brand";
            this.colBrand.Name = "colBrand";
            this.colBrand.Visible = true;
            this.colBrand.VisibleIndex = 4;
            // 
            // colWeb_MainCategory
            // 
            this.colWeb_MainCategory.FieldName = "Web_MainCategory";
            this.colWeb_MainCategory.Name = "colWeb_MainCategory";
            this.colWeb_MainCategory.Visible = true;
            this.colWeb_MainCategory.VisibleIndex = 5;
            // 
            // colWeb_Category
            // 
            this.colWeb_Category.FieldName = "Web_Category";
            this.colWeb_Category.Name = "colWeb_Category";
            this.colWeb_Category.Visible = true;
            this.colWeb_Category.VisibleIndex = 6;
            // 
            // colWeb_SubCategory
            // 
            this.colWeb_SubCategory.FieldName = "Web_SubCategory";
            this.colWeb_SubCategory.Name = "colWeb_SubCategory";
            this.colWeb_SubCategory.Visible = true;
            this.colWeb_SubCategory.VisibleIndex = 7;
            // 
            // colRootProductStockCode
            // 
            this.colRootProductStockCode.FieldName = "RootProductStockCode";
            this.colRootProductStockCode.Name = "colRootProductStockCode";
            this.colRootProductStockCode.Visible = true;
            this.colRootProductStockCode.VisibleIndex = 8;
            // 
            // colWebPrice
            // 
            this.colWebPrice.FieldName = "WebPrice";
            this.colWebPrice.Name = "colWebPrice";
            this.colWebPrice.Visible = true;
            this.colWebPrice.VisibleIndex = 9;
            // 
            // colMarketPrice
            // 
            this.colMarketPrice.FieldName = "MarketPrice";
            this.colMarketPrice.Name = "colMarketPrice";
            this.colMarketPrice.Visible = true;
            this.colMarketPrice.VisibleIndex = 10;
            // 
            // colCurrencyAbbr
            // 
            this.colCurrencyAbbr.FieldName = "CurrencyAbbr";
            this.colCurrencyAbbr.Name = "colCurrencyAbbr";
            this.colCurrencyAbbr.Visible = true;
            this.colCurrencyAbbr.VisibleIndex = 11;
            // 
            // colProductSource
            // 
            this.colProductSource.FieldName = "ProductSource";
            this.colProductSource.Name = "colProductSource";
            this.colProductSource.Visible = true;
            this.colProductSource.VisibleIndex = 12;
            // 
            // colBarcode
            // 
            this.colBarcode.FieldName = "Barcode";
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.Visible = true;
            this.colBarcode.VisibleIndex = 13;
            // 
            // colWebExportStatus
            // 
            this.colWebExportStatus.FieldName = "WebExportStatus";
            this.colWebExportStatus.Name = "colWebExportStatus";
            this.colWebExportStatus.Visible = true;
            this.colWebExportStatus.VisibleIndex = 14;
            // 
            // colLastEdited
            // 
            this.colLastEdited.FieldName = "LastEdited";
            this.colLastEdited.Name = "colLastEdited";
            this.colLastEdited.Visible = true;
            this.colLastEdited.VisibleIndex = 15;
            // 
            // colLastEditedDate
            // 
            this.colLastEditedDate.FieldName = "LastEditedDate";
            this.colLastEditedDate.Name = "colLastEditedDate";
            this.colLastEditedDate.Visible = true;
            this.colLastEditedDate.VisibleIndex = 16;
            // 
            // colN11ProductId
            // 
            this.colN11ProductId.FieldName = "N11ProductId";
            this.colN11ProductId.Name = "colN11ProductId";
            this.colN11ProductId.Visible = true;
            this.colN11ProductId.VisibleIndex = 17;
            // 
            // colExportN11
            // 
            this.colExportN11.FieldName = "ExportN11";
            this.colExportN11.Name = "colExportN11";
            this.colExportN11.Visible = true;
            this.colExportN11.VisibleIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTrendyolExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormTrendyolExport";
            this.Text = "FormTrendyolExport";
            this.Load += new System.EventHandler(this.FormTrendyolExport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.MenuStripProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colWeb_MainCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colWeb_Category;
        private DevExpress.XtraGrid.Columns.GridColumn colWeb_SubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colRootProductStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colWebPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMarketPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colProductSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBarcode;
        private DevExpress.XtraGrid.Columns.GridColumn colWebExportStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colLastEdited;
        private DevExpress.XtraGrid.Columns.GridColumn colLastEditedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colN11ProductId;
        private DevExpress.XtraGrid.Columns.GridColumn colExportN11;
        private System.Windows.Forms.ContextMenuStrip MenuStripProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBulkExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPriceUpdate;
        private System.Windows.Forms.Button button1;
    }
}