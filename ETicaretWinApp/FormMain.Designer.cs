namespace ETicaretWinApp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            ProductCategory productCategory7 = new ProductCategory();
            ProductCategory productCategory8 = new ProductCategory();
            ProductCategory productCategory9 = new ProductCategory();
            this.gridControlProduct = new DevExpress.XtraGrid.GridControl();
            this.cMenuStripProductList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemProductImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMuhasebeImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemKadiogluImport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImportCeren = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDerya = new System.Windows.Forms.ToolStripMenuItem();
            this.MenıItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUpdateGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUpdateMainC = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSub = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubSubU = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemUpdateSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGetInfoFromWeb = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemProductProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNewProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemIndexCatalog = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShareInstagram = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemIdeaSoftExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemHepsiBurada = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportN11 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportTrendYol = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportCicekSepeti = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreateUpdateExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportN11Magazam = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportSingleCicekSepeti = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLabel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMainCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRootProductStockCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarketPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyAbbr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStockAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWebExportStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStokCode = new System.Windows.Forms.TextBox();
            this.uProductFilterCombo1 = new ETicaretWinApp.Controls.UProductFilterCombo();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelRecordCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.uCategoryView1 = new ETicaretWinApp.Controls.UCategoryView();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.MenuItemShopEntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemN11Entegration = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTrendyol = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShopSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTedarikciPasswords = new System.Windows.Forms.ToolStripMenuItem();
            this.sContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProduct)).BeginInit();
            this.cMenuStripProductList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sContainer1)).BeginInit();
            this.sContainer1.Panel1.SuspendLayout();
            this.sContainer1.Panel2.SuspendLayout();
            this.sContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlProduct
            // 
            this.gridControlProduct.ContextMenuStrip = this.cMenuStripProductList;
            this.gridControlProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProduct.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridControlProduct.Location = new System.Drawing.Point(0, 0);
            this.gridControlProduct.MainView = this.gridView1;
            this.gridControlProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridControlProduct.Name = "gridControlProduct";
            this.gridControlProduct.Size = new System.Drawing.Size(1491, 161);
            this.gridControlProduct.TabIndex = 0;
            this.gridControlProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // cMenuStripProductList
            // 
            this.cMenuStripProductList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cMenuStripProductList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemProductImport,
            this.MenıItemExportExcel,
            this.MenuItemUpdateGroup,
            this.MenuItemGetInfoFromWeb,
            this.MenuItemProductProperty,
            this.MenuItemNewProduct,
            this.MenuItemIndexCatalog,
            this.MenuItemShareInstagram,
            this.MenuItemExport,
            this.MenuItemExportSingle});
            this.cMenuStripProductList.Name = "cMenuStripProductList";
            this.cMenuStripProductList.Size = new System.Drawing.Size(266, 244);
            // 
            // MenuItemProductImport
            // 
            this.MenuItemProductImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMuhasebeImport,
            this.MenuItemKadiogluImport,
            this.MenuItemImportCeren,
            this.MenuItemImportPDF,
            this.MenuItemImportExcel,
            this.MenuItemDerya});
            this.MenuItemProductImport.Name = "MenuItemProductImport";
            this.MenuItemProductImport.Size = new System.Drawing.Size(265, 24);
            this.MenuItemProductImport.Text = "Ürün İmport";
            // 
            // MenuItemMuhasebeImport
            // 
            this.MenuItemMuhasebeImport.Name = "MenuItemMuhasebeImport";
            this.MenuItemMuhasebeImport.Size = new System.Drawing.Size(218, 26);
            this.MenuItemMuhasebeImport.Text = "Muhasebe Çıktısı";
            this.MenuItemMuhasebeImport.Click += new System.EventHandler(this.MenuItemMuhasebeImport_Click);
            // 
            // MenuItemKadiogluImport
            // 
            this.MenuItemKadiogluImport.Name = "MenuItemKadiogluImport";
            this.MenuItemKadiogluImport.Size = new System.Drawing.Size(218, 26);
            this.MenuItemKadiogluImport.Text = "Kadioglu Import";
            this.MenuItemKadiogluImport.Click += new System.EventHandler(this.MenuItemKadiogluImport_Click);
            // 
            // MenuItemImportCeren
            // 
            this.MenuItemImportCeren.Name = "MenuItemImportCeren";
            this.MenuItemImportCeren.Size = new System.Drawing.Size(218, 26);
            this.MenuItemImportCeren.Text = "Ceren";
            this.MenuItemImportCeren.Click += new System.EventHandler(this.MenuItemImportCeren_Click);
            // 
            // MenuItemImportPDF
            // 
            this.MenuItemImportPDF.Name = "MenuItemImportPDF";
            this.MenuItemImportPDF.Size = new System.Drawing.Size(218, 26);
            this.MenuItemImportPDF.Text = "Pdf Katalog Import";
            this.MenuItemImportPDF.Click += new System.EventHandler(this.MenuItemImportPDF_Click);
            // 
            // MenuItemImportExcel
            // 
            this.MenuItemImportExcel.Name = "MenuItemImportExcel";
            this.MenuItemImportExcel.Size = new System.Drawing.Size(218, 26);
            this.MenuItemImportExcel.Text = "Excel Import";
            this.MenuItemImportExcel.Click += new System.EventHandler(this.MenuItemImportExcel_Click);
            // 
            // MenuItemDerya
            // 
            this.MenuItemDerya.Name = "MenuItemDerya";
            this.MenuItemDerya.Size = new System.Drawing.Size(218, 26);
            this.MenuItemDerya.Text = "Derya";
            this.MenuItemDerya.Click += new System.EventHandler(this.MenuItemDerya_Click);
            // 
            // MenıItemExportExcel
            // 
            this.MenıItemExportExcel.Name = "MenıItemExportExcel";
            this.MenıItemExportExcel.Size = new System.Drawing.Size(265, 24);
            this.MenıItemExportExcel.Text = "Excel\'e Çıkar";
            this.MenıItemExportExcel.Click += new System.EventHandler(this.MenıItemExportExcel_Click);
            // 
            // MenuItemUpdateGroup
            // 
            this.MenuItemUpdateGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemUpdateMainC,
            this.MenuItemSub,
            this.MenuItemSubSubU,
            this.MenuItemUpdateSelected});
            this.MenuItemUpdateGroup.Name = "MenuItemUpdateGroup";
            this.MenuItemUpdateGroup.Size = new System.Drawing.Size(265, 24);
            this.MenuItemUpdateGroup.Text = "Group Update";
            this.MenuItemUpdateGroup.Click += new System.EventHandler(this.MenuItemUpdateGroup_Click);
            // 
            // MenuItemUpdateMainC
            // 
            this.MenuItemUpdateMainC.Name = "MenuItemUpdateMainC";
            this.MenuItemUpdateMainC.Size = new System.Drawing.Size(191, 26);
            this.MenuItemUpdateMainC.Text = "Ana";
            this.MenuItemUpdateMainC.Click += new System.EventHandler(this.MenuItemUpdateMainC_Click);
            // 
            // MenuItemSub
            // 
            this.MenuItemSub.Name = "MenuItemSub";
            this.MenuItemSub.Size = new System.Drawing.Size(191, 26);
            this.MenuItemSub.Text = "Alt";
            this.MenuItemSub.Click += new System.EventHandler(this.MenuItemSub_Click);
            // 
            // MenuItemSubSubU
            // 
            this.MenuItemSubSubU.Name = "MenuItemSubSubU";
            this.MenuItemSubSubU.Size = new System.Drawing.Size(191, 26);
            this.MenuItemSubSubU.Text = "En Alt";
            this.MenuItemSubSubU.Click += new System.EventHandler(this.MenuItemSubSubU_Click);
            // 
            // MenuItemUpdateSelected
            // 
            this.MenuItemUpdateSelected.Name = "MenuItemUpdateSelected";
            this.MenuItemUpdateSelected.Size = new System.Drawing.Size(191, 26);
            this.MenuItemUpdateSelected.Text = "Seçilen Ürünler";
            this.MenuItemUpdateSelected.Click += new System.EventHandler(this.MenuItemUpdateSelected_Click);
            // 
            // MenuItemGetInfoFromWeb
            // 
            this.MenuItemGetInfoFromWeb.Name = "MenuItemGetInfoFromWeb";
            this.MenuItemGetInfoFromWeb.Size = new System.Drawing.Size(265, 24);
            this.MenuItemGetInfoFromWeb.Text = "Eksik Bilgileri Webden Topla";
            this.MenuItemGetInfoFromWeb.Click += new System.EventHandler(this.MenuItemGetInfoFromWeb_Click);
            // 
            // MenuItemProductProperty
            // 
            this.MenuItemProductProperty.Name = "MenuItemProductProperty";
            this.MenuItemProductProperty.Size = new System.Drawing.Size(265, 24);
            this.MenuItemProductProperty.Text = "Ürün Özellikleri";
            this.MenuItemProductProperty.Click += new System.EventHandler(this.MenuItemProductProperty_Click);
            // 
            // MenuItemNewProduct
            // 
            this.MenuItemNewProduct.Name = "MenuItemNewProduct";
            this.MenuItemNewProduct.Size = new System.Drawing.Size(265, 24);
            this.MenuItemNewProduct.Text = "Yeni Ürün";
            this.MenuItemNewProduct.Click += new System.EventHandler(this.MenuItemNewProduct_Click);
            // 
            // MenuItemIndexCatalog
            // 
            this.MenuItemIndexCatalog.Name = "MenuItemIndexCatalog";
            this.MenuItemIndexCatalog.Size = new System.Drawing.Size(265, 24);
            this.MenuItemIndexCatalog.Text = "Catalog indexle";
            this.MenuItemIndexCatalog.Click += new System.EventHandler(this.MenuItemIndexCatalog_Click);
            // 
            // MenuItemShareInstagram
            // 
            this.MenuItemShareInstagram.Name = "MenuItemShareInstagram";
            this.MenuItemShareInstagram.Size = new System.Drawing.Size(265, 24);
            this.MenuItemShareInstagram.Text = "Intagramda Paylaş";
            this.MenuItemShareInstagram.Click += new System.EventHandler(this.MenuItemShareInstagram_Click);
            // 
            // MenuItemExport
            // 
            this.MenuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemIdeaSoftExport,
            this.MenuItemHepsiBurada,
            this.MenuItemExportN11,
            this.MenuItemExportTrendYol,
            this.MenuItemExportCicekSepeti,
            this.MenuItemCreateUpdateExport,
            this.MenuItemExportN11Magazam});
            this.MenuItemExport.Name = "MenuItemExport";
            this.MenuItemExport.Size = new System.Drawing.Size(265, 24);
            this.MenuItemExport.Text = "Export";
            // 
            // MenuItemIdeaSoftExport
            // 
            this.MenuItemIdeaSoftExport.Name = "MenuItemIdeaSoftExport";
            this.MenuItemIdeaSoftExport.Size = new System.Drawing.Size(239, 26);
            this.MenuItemIdeaSoftExport.Text = "IdeaSoft Export";
            this.MenuItemIdeaSoftExport.Click += new System.EventHandler(this.MenuItemIdeaExport_Click);
            // 
            // MenuItemHepsiBurada
            // 
            this.MenuItemHepsiBurada.Name = "MenuItemHepsiBurada";
            this.MenuItemHepsiBurada.Size = new System.Drawing.Size(239, 26);
            this.MenuItemHepsiBurada.Text = "HepsiBurada Export";
            this.MenuItemHepsiBurada.Click += new System.EventHandler(this.MenuItemHepsiBurada_Click);
            // 
            // MenuItemExportN11
            // 
            this.MenuItemExportN11.Name = "MenuItemExportN11";
            this.MenuItemExportN11.Size = new System.Drawing.Size(239, 26);
            this.MenuItemExportN11.Text = "N11 Export";
            this.MenuItemExportN11.Click += new System.EventHandler(this.MenuItemExportN11_Click);
            // 
            // MenuItemExportTrendYol
            // 
            this.MenuItemExportTrendYol.Name = "MenuItemExportTrendYol";
            this.MenuItemExportTrendYol.Size = new System.Drawing.Size(239, 26);
            this.MenuItemExportTrendYol.Text = "Export Trendyol";
            this.MenuItemExportTrendYol.Click += new System.EventHandler(this.MenuItemExportTrendYol_Click);
            // 
            // MenuItemExportCicekSepeti
            // 
            this.MenuItemExportCicekSepeti.Name = "MenuItemExportCicekSepeti";
            this.MenuItemExportCicekSepeti.Size = new System.Drawing.Size(239, 26);
            this.MenuItemExportCicekSepeti.Text = "Çiçek Sepeti";
            this.MenuItemExportCicekSepeti.Click += new System.EventHandler(this.MenuItemExportCicekSepeti_Click);
            // 
            // MenuItemCreateUpdateExport
            // 
            this.MenuItemCreateUpdateExport.Name = "MenuItemCreateUpdateExport";
            this.MenuItemCreateUpdateExport.Size = new System.Drawing.Size(239, 26);
            this.MenuItemCreateUpdateExport.Text = "Update Export U Cikar";
            this.MenuItemCreateUpdateExport.Click += new System.EventHandler(this.MenuItemCreateUpdateExport_Click);
            // 
            // MenuItemExportN11Magazam
            // 
            this.MenuItemExportN11Magazam.Name = "MenuItemExportN11Magazam";
            this.MenuItemExportN11Magazam.Size = new System.Drawing.Size(239, 26);
            this.MenuItemExportN11Magazam.Text = "N11 Mağazam";
            this.MenuItemExportN11Magazam.Click += new System.EventHandler(this.MenuItemExportN11Magazam_Click);
            // 
            // MenuItemExportSingle
            // 
            this.MenuItemExportSingle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExportSingleCicekSepeti});
            this.MenuItemExportSingle.Name = "MenuItemExportSingle";
            this.MenuItemExportSingle.Size = new System.Drawing.Size(265, 24);
            this.MenuItemExportSingle.Text = "Tekil Ürün Export";
            // 
            // MenuItemExportSingleCicekSepeti
            // 
            this.MenuItemExportSingleCicekSepeti.Name = "MenuItemExportSingleCicekSepeti";
            this.MenuItemExportSingleCicekSepeti.Size = new System.Drawing.Size(169, 26);
            this.MenuItemExportSingleCicekSepeti.Text = "ÇiçekSepeti";
            this.MenuItemExportSingleCicekSepeti.Click += new System.EventHandler(this.MenuItemExportSingleCicekSepeti_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStockCode,
            this.colLabel,
            this.colStatus,
            this.colBrand,
            this.colMainCategory,
            this.colMainCategoryId,
            this.colCategory,
            this.colCategoryId,
            this.colSubCategory,
            this.colSubCategoryId,
            this.colRootProductStockCode,
            this.colMarketPrice,
            this.gridColumn1,
            this.colPrice1,
            this.colCurrencyAbbr,
            this.colStockAmount,
            this.colProductSource,
            this.colWebExportStatus});
            this.gridView1.GridControl = this.gridControlProduct;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 30;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            this.colId.Width = 30;
            // 
            // colStockCode
            // 
            this.colStockCode.Caption = "Stok Kodu";
            this.colStockCode.FieldName = "StockCode";
            this.colStockCode.MinWidth = 100;
            this.colStockCode.Name = "colStockCode";
            this.colStockCode.OptionsColumn.AllowEdit = false;
            this.colStockCode.Visible = true;
            this.colStockCode.VisibleIndex = 1;
            this.colStockCode.Width = 100;
            // 
            // colLabel
            // 
            this.colLabel.Caption = "Ürün Adı";
            this.colLabel.FieldName = "Label";
            this.colLabel.MinWidth = 200;
            this.colLabel.Name = "colLabel";
            this.colLabel.Visible = true;
            this.colLabel.VisibleIndex = 2;
            this.colLabel.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Durum";
            this.colStatus.FieldName = "Status";
            this.colStatus.MinWidth = 50;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            this.colStatus.Width = 50;
            // 
            // colBrand
            // 
            this.colBrand.Caption = "Marka";
            this.colBrand.FieldName = "Brand";
            this.colBrand.MinWidth = 80;
            this.colBrand.Name = "colBrand";
            this.colBrand.Visible = true;
            this.colBrand.VisibleIndex = 4;
            this.colBrand.Width = 80;
            // 
            // colMainCategory
            // 
            this.colMainCategory.Caption = "Ana Grup";
            this.colMainCategory.FieldName = "MainCategory";
            this.colMainCategory.MinWidth = 100;
            this.colMainCategory.Name = "colMainCategory";
            this.colMainCategory.OptionsColumn.AllowEdit = false;
            this.colMainCategory.Visible = true;
            this.colMainCategory.VisibleIndex = 5;
            this.colMainCategory.Width = 100;
            // 
            // colMainCategoryId
            // 
            this.colMainCategoryId.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colMainCategoryId.AppearanceCell.Options.UseBackColor = true;
            this.colMainCategoryId.Caption = "Ana Grup Web Görünüm";
            this.colMainCategoryId.FieldName = "Web_MainCategory";
            this.colMainCategoryId.MinWidth = 100;
            this.colMainCategoryId.Name = "colMainCategoryId";
            this.colMainCategoryId.OptionsColumn.AllowEdit = false;
            this.colMainCategoryId.Visible = true;
            this.colMainCategoryId.VisibleIndex = 6;
            this.colMainCategoryId.Width = 100;
            // 
            // colCategory
            // 
            this.colCategory.Caption = "Grup";
            this.colCategory.FieldName = "Category";
            this.colCategory.MinWidth = 100;
            this.colCategory.Name = "colCategory";
            this.colCategory.OptionsColumn.AllowEdit = false;
            this.colCategory.Visible = true;
            this.colCategory.VisibleIndex = 7;
            this.colCategory.Width = 100;
            // 
            // colCategoryId
            // 
            this.colCategoryId.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colCategoryId.AppearanceCell.Options.UseBackColor = true;
            this.colCategoryId.Caption = "Group Web Görünüm";
            this.colCategoryId.FieldName = "Web_Category";
            this.colCategoryId.MinWidth = 100;
            this.colCategoryId.Name = "colCategoryId";
            this.colCategoryId.OptionsColumn.AllowEdit = false;
            this.colCategoryId.Visible = true;
            this.colCategoryId.VisibleIndex = 8;
            this.colCategoryId.Width = 100;
            // 
            // colSubCategory
            // 
            this.colSubCategory.Caption = "Alt Group";
            this.colSubCategory.FieldName = "SubCategory";
            this.colSubCategory.MinWidth = 100;
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.OptionsColumn.AllowEdit = false;
            this.colSubCategory.Visible = true;
            this.colSubCategory.VisibleIndex = 9;
            this.colSubCategory.Width = 100;
            // 
            // colSubCategoryId
            // 
            this.colSubCategoryId.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.colSubCategoryId.AppearanceCell.Options.UseBackColor = true;
            this.colSubCategoryId.CustomizationCaption = "Alt Group Web Görünüm";
            this.colSubCategoryId.FieldName = "Web_SubCategory";
            this.colSubCategoryId.MinWidth = 100;
            this.colSubCategoryId.Name = "colSubCategoryId";
            this.colSubCategoryId.OptionsColumn.AllowEdit = false;
            this.colSubCategoryId.Visible = true;
            this.colSubCategoryId.VisibleIndex = 10;
            this.colSubCategoryId.Width = 100;
            // 
            // colRootProductStockCode
            // 
            this.colRootProductStockCode.CustomizationCaption = "Ana Stok Kodu";
            this.colRootProductStockCode.FieldName = "RootProductStockCode";
            this.colRootProductStockCode.MinWidth = 100;
            this.colRootProductStockCode.Name = "colRootProductStockCode";
            this.colRootProductStockCode.OptionsColumn.AllowEdit = false;
            this.colRootProductStockCode.Visible = true;
            this.colRootProductStockCode.VisibleIndex = 11;
            this.colRootProductStockCode.Width = 100;
            // 
            // colMarketPrice
            // 
            this.colMarketPrice.CustomizationCaption = "Maliyet Kdv Dahil";
            this.colMarketPrice.FieldName = "MarketPrice";
            this.colMarketPrice.MinWidth = 100;
            this.colMarketPrice.Name = "colMarketPrice";
            this.colMarketPrice.Visible = true;
            this.colMarketPrice.VisibleIndex = 12;
            this.colMarketPrice.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "İnternet Fiyatı";
            this.gridColumn1.FieldName = "WebPrice";
            this.gridColumn1.MinWidth = 100;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 13;
            this.gridColumn1.Width = 100;
            // 
            // colPrice1
            // 
            this.colPrice1.Caption = "Fiyat 1";
            this.colPrice1.FieldName = "Price1";
            this.colPrice1.MinWidth = 100;
            this.colPrice1.Name = "colPrice1";
            this.colPrice1.Visible = true;
            this.colPrice1.VisibleIndex = 14;
            this.colPrice1.Width = 100;
            // 
            // colCurrencyAbbr
            // 
            this.colCurrencyAbbr.Caption = "Para Birimi";
            this.colCurrencyAbbr.FieldName = "CurrencyAbbr";
            this.colCurrencyAbbr.MinWidth = 80;
            this.colCurrencyAbbr.Name = "colCurrencyAbbr";
            this.colCurrencyAbbr.OptionsColumn.AllowEdit = false;
            this.colCurrencyAbbr.Visible = true;
            this.colCurrencyAbbr.VisibleIndex = 15;
            this.colCurrencyAbbr.Width = 80;
            // 
            // colStockAmount
            // 
            this.colStockAmount.Caption = "Stok";
            this.colStockAmount.FieldName = "StockAmount";
            this.colStockAmount.MinWidth = 80;
            this.colStockAmount.Name = "colStockAmount";
            this.colStockAmount.Visible = true;
            this.colStockAmount.VisibleIndex = 16;
            this.colStockAmount.Width = 80;
            // 
            // colProductSource
            // 
            this.colProductSource.CustomizationCaption = "Kaynak";
            this.colProductSource.FieldName = "ProductSource";
            this.colProductSource.Name = "colProductSource";
            this.colProductSource.OptionsColumn.AllowEdit = false;
            this.colProductSource.Visible = true;
            this.colProductSource.VisibleIndex = 17;
            this.colProductSource.Width = 20;
            // 
            // colWebExportStatus
            // 
            this.colWebExportStatus.Caption = "Export Durumu";
            this.colWebExportStatus.FieldName = "WebExportStatus";
            this.colWebExportStatus.Name = "colWebExportStatus";
            this.colWebExportStatus.OptionsColumn.AllowEdit = false;
            this.colWebExportStatus.Visible = true;
            this.colWebExportStatus.VisibleIndex = 18;
            this.colWebExportStatus.Width = 100;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Image = ((System.Drawing.Image)(resources.GetObject("buttonFilter.Image")));
            this.buttonFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFilter.Location = new System.Drawing.Point(1015, 307);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(219, 30);
            this.buttonFilter.TabIndex = 2;
            this.buttonFilter.Text = "Listele";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(562, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Stok Kodu/Adı/Barkod";
            // 
            // textBoxStokCode
            // 
            this.textBoxStokCode.Location = new System.Drawing.Point(733, 307);
            this.textBoxStokCode.Name = "textBoxStokCode";
            this.textBoxStokCode.Size = new System.Drawing.Size(275, 27);
            this.textBoxStokCode.TabIndex = 15;
            // 
            // uProductFilterCombo1
            // 
            this.uProductFilterCombo1.ExportHB = "";
            this.uProductFilterCombo1.ExportIdea = "";
            this.uProductFilterCombo1.ExportN11 = "";
            this.uProductFilterCombo1.Location = new System.Drawing.Point(546, 15);
            this.uProductFilterCombo1.Margin = new System.Windows.Forms.Padding(4);
            this.uProductFilterCombo1.Name = "uProductFilterCombo1";
            this.uProductFilterCombo1.PriceFilter = "";
            this.uProductFilterCombo1.PriceFilterType = "";
            this.uProductFilterCombo1.Size = new System.Drawing.Size(990, 273);
            this.uProductFilterCombo1.StokCodeList = ((System.Collections.Generic.List<string>)(resources.GetObject("uProductFilterCombo1.StokCodeList")));
            this.uProductFilterCombo1.TabIndex = 16;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRecordCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 594);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1491, 26);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRecordCount
            // 
            this.toolStripStatusLabelRecordCount.Name = "toolStripStatusLabelRecordCount";
            this.toolStripStatusLabelRecordCount.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabelRecordCount.Text = "toolStripStatusLabel1";
            // 
            // uCategoryView1
            // 
            this.uCategoryView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            productCategory7.CategoryName = "Tümü";
            productCategory7.CategoryUrl = null;
            productCategory7.CicekSepetiCategoryId = 0;
            productCategory7.CicekSepetiCategoryName = null;
            productCategory7.HepsiBuradaCategoryId = 0;
            productCategory7.HepsiBuradaCategoryName = null;
            productCategory7.Id = 0;
            productCategory7.N11CategoryId = 0;
            productCategory7.N11CategoryName = null;
            productCategory7.N11ExportTemplateId = 0;
            productCategory7.N11ExportTemplateName = null;
            productCategory7.TargetCategory = false;
            productCategory7.TrendyolCategoryId = 0;
            productCategory7.TrendyolCategoryName = null;
            productCategory7.UpId = 0;
            this.uCategoryView1.Category = productCategory7;
            this.uCategoryView1.Location = new System.Drawing.Point(12, 10);
            productCategory8.CategoryName = "Tümü";
            productCategory8.CategoryUrl = null;
            productCategory8.CicekSepetiCategoryId = 0;
            productCategory8.CicekSepetiCategoryName = null;
            productCategory8.HepsiBuradaCategoryId = 0;
            productCategory8.HepsiBuradaCategoryName = null;
            productCategory8.Id = 0;
            productCategory8.N11CategoryId = 0;
            productCategory8.N11CategoryName = null;
            productCategory8.N11ExportTemplateId = 0;
            productCategory8.N11ExportTemplateName = null;
            productCategory8.TargetCategory = false;
            productCategory8.TrendyolCategoryId = 0;
            productCategory8.TrendyolCategoryName = null;
            productCategory8.UpId = 0;
            this.uCategoryView1.MainCategory = productCategory8;
            this.uCategoryView1.Margin = new System.Windows.Forms.Padding(4);
            this.uCategoryView1.Name = "uCategoryView1";
            this.uCategoryView1.Size = new System.Drawing.Size(528, 383);
            productCategory9.CategoryName = "Tümü";
            productCategory9.CategoryUrl = null;
            productCategory9.CicekSepetiCategoryId = 0;
            productCategory9.CicekSepetiCategoryName = null;
            productCategory9.HepsiBuradaCategoryId = 0;
            productCategory9.HepsiBuradaCategoryName = null;
            productCategory9.Id = 0;
            productCategory9.N11CategoryId = 0;
            productCategory9.N11CategoryName = null;
            productCategory9.N11ExportTemplateId = 0;
            productCategory9.N11ExportTemplateName = null;
            productCategory9.TargetCategory = false;
            productCategory9.TrendyolCategoryId = 0;
            productCategory9.TrendyolCategoryName = null;
            productCategory9.UpId = 0;
            this.uCategoryView1.SubCategory = productCategory9;
            this.uCategoryView1.TabIndex = 18;
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemShopEntegration,
            this.MenuItemSetting});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1491, 28);
            this.menuStripMain.TabIndex = 19;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // MenuItemShopEntegration
            // 
            this.MenuItemShopEntegration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemN11Entegration,
            this.MenuItemTrendyol});
            this.MenuItemShopEntegration.Name = "MenuItemShopEntegration";
            this.MenuItemShopEntegration.Size = new System.Drawing.Size(86, 24);
            this.MenuItemShopEntegration.Text = "Pazar Yeri";
            // 
            // MenuItemN11Entegration
            // 
            this.MenuItemN11Entegration.Name = "MenuItemN11Entegration";
            this.MenuItemN11Entegration.Size = new System.Drawing.Size(149, 26);
            this.MenuItemN11Entegration.Text = "N11";
            this.MenuItemN11Entegration.Click += new System.EventHandler(this.MenuItemN11Entegration_Click);
            // 
            // MenuItemTrendyol
            // 
            this.MenuItemTrendyol.Name = "MenuItemTrendyol";
            this.MenuItemTrendyol.Size = new System.Drawing.Size(149, 26);
            this.MenuItemTrendyol.Text = "Trendyol";
            this.MenuItemTrendyol.Click += new System.EventHandler(this.MenuItemTrendyol_Click);
            // 
            // MenuItemSetting
            // 
            this.MenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemShopSetting,
            this.MenuItemTedarikciPasswords});
            this.MenuItemSetting.Name = "MenuItemSetting";
            this.MenuItemSetting.Size = new System.Drawing.Size(70, 24);
            this.MenuItemSetting.Text = "Ayarlar";
            // 
            // MenuItemShopSetting
            // 
            this.MenuItemShopSetting.Name = "MenuItemShopSetting";
            this.MenuItemShopSetting.Size = new System.Drawing.Size(206, 26);
            this.MenuItemShopSetting.Text = "Pazaryeri Şifreleri";
            this.MenuItemShopSetting.Click += new System.EventHandler(this.MenuItemShopSetting_Click);
            // 
            // MenuItemTedarikciPasswords
            // 
            this.MenuItemTedarikciPasswords.Name = "MenuItemTedarikciPasswords";
            this.MenuItemTedarikciPasswords.Size = new System.Drawing.Size(206, 26);
            this.MenuItemTedarikciPasswords.Text = "Tedarikçi Şifreleri";
            this.MenuItemTedarikciPasswords.Click += new System.EventHandler(this.MenuItemTedarikciPasswords_Click);
            // 
            // sContainer1
            // 
            this.sContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sContainer1.Location = new System.Drawing.Point(0, 28);
            this.sContainer1.Name = "sContainer1";
            this.sContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sContainer1.Panel1
            // 
            this.sContainer1.Panel1.Controls.Add(this.buttonFilter);
            this.sContainer1.Panel1.Controls.Add(this.textBoxStokCode);
            this.sContainer1.Panel1.Controls.Add(this.uCategoryView1);
            this.sContainer1.Panel1.Controls.Add(this.label2);
            this.sContainer1.Panel1.Controls.Add(this.uProductFilterCombo1);
            // 
            // sContainer1.Panel2
            // 
            this.sContainer1.Panel2.Controls.Add(this.gridControlProduct);
            this.sContainer1.Size = new System.Drawing.Size(1491, 566);
            this.sContainer1.SplitterDistance = 401;
            this.sContainer1.TabIndex = 20;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 620);
            this.Controls.Add(this.sContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Yönetimi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProduct)).EndInit();
            this.cMenuStripProductList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.sContainer1.Panel1.ResumeLayout(false);
            this.sContainer1.Panel1.PerformLayout();
            this.sContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sContainer1)).EndInit();
            this.sContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cMenuStripProductList;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProductImport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMuhasebeImport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemKadiogluImport;
        private System.Windows.Forms.Button buttonFilter;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLabel;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBrand;
        private DevExpress.XtraGrid.Columns.GridColumn colMainCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colMainCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colSubCategoryId;
        private DevExpress.XtraGrid.Columns.GridColumn colRootProductStockCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMarketPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice1;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyAbbr;
        private DevExpress.XtraGrid.Columns.GridColumn colStockAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colProductSource;
        private DevExpress.XtraGrid.Columns.GridColumn colWebExportStatus;
        private System.Windows.Forms.ToolStripMenuItem MenıItemExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUpdateGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUpdateMainC;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSub;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubSubU;
       // private Controls.UCategoryView uCategoryView1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemUpdateSelected;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGetInfoFromWeb;
        private System.Windows.Forms.ToolStripMenuItem MenuItemProductProperty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStokCode;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImportCeren;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private ETicaretWinApp.Controls.UProductFilterCombo uProductFilterCombo1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRecordCount;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNewProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImportPDF;
        private System.Windows.Forms.ToolStripMenuItem MenuItemIndexCatalog;
        private Controls.UCategoryView uCategoryView1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShareInstagram;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemHepsiBurada;
        private System.Windows.Forms.ToolStripMenuItem MenuItemIdeaSoftExport;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShopSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShopEntegration;
        private System.Windows.Forms.ToolStripMenuItem MenuItemN11Entegration;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportN11;
        private System.Windows.Forms.SplitContainer sContainer1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTrendyol;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreateUpdateExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImportExcel;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportTrendYol;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTedarikciPasswords;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDerya;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportCicekSepeti;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportSingle;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportSingleCicekSepeti;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportN11Magazam;
    }
}

