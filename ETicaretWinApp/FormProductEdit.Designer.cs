namespace ETicaretWinApp
{
    partial class FormProductEdit
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
            ProductCategory productCategory1 = new ProductCategory();
            ProductCategory productCategory2 = new ProductCategory();
            ProductCategory productCategory3 = new ProductCategory();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.htmlTextboxDescription = new GvS.Controls.HtmlTextbox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAndClose = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveNext = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemShareInstagram = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExportN11 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGalery = new System.Windows.Forms.Panel();
            this.webBrowserProduct = new System.Windows.Forms.WebBrowser();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGoogleUrl = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStokCode = new System.Windows.Forms.TextBox();
            this.textBoxProductSource = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxMarketPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMimPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxWebPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxBrand = new System.Windows.Forms.ComboBox();
            this.labelPictureSource = new System.Windows.Forms.Label();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.buttonGetSelectedProduct = new System.Windows.Forms.Button();
            this.textBoxBarkod = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.uCategoryViewProduct = new ETicaretWinApp.Controls.UCategoryView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(920, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adı";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxProductName.Location = new System.Drawing.Point(971, 30);
            this.textBoxProductName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(1152, 34);
            this.textBoxProductName.TabIndex = 2;
            this.textBoxProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProductName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 406);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Özellikleri";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(125, 54);
            this.textBoxPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(105, 22);
            this.textBoxPrice.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maliyet";
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Location = new System.Drawing.Point(328, 53);
            this.textBoxDiscount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(105, 22);
            this.textBoxDiscount.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "İndirim";
            // 
            // htmlTextboxDescription
            // 
            this.htmlTextboxDescription.Fonts = new string[] {
        "Corbel",
        "Corbel, Verdana, Arial, Helvetica, sans-serif",
        "Georgia, Times New Roman, Times, serif",
        "Consolas, Courier New, Courier, monospace"};
            this.htmlTextboxDescription.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.htmlTextboxDescription.Location = new System.Drawing.Point(16, 426);
            this.htmlTextboxDescription.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.htmlTextboxDescription.Name = "htmlTextboxDescription";
            this.htmlTextboxDescription.Padding = new System.Windows.Forms.Padding(1);
            this.htmlTextboxDescription.ShowHtmlSource = false;
            this.htmlTextboxDescription.Size = new System.Drawing.Size(632, 144);
            this.htmlTextboxDescription.TabIndex = 11;
            this.htmlTextboxDescription.ToolbarStyle = GvS.Controls.ToolbarStyles.AlwaysInternal;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemMenu
            // 
            this.MenuItemMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSaveAndClose,
            this.MenuItemSaveNext,
            this.MenuItemSave,
            this.MenuItemShareInstagram,
            this.MenuItemExportN11});
            this.MenuItemMenu.Name = "MenuItemMenu";
            this.MenuItemMenu.Size = new System.Drawing.Size(60, 24);
            this.MenuItemMenu.Text = "Menu";
            // 
            // MenuItemSaveAndClose
            // 
            this.MenuItemSaveAndClose.Name = "MenuItemSaveAndClose";
            this.MenuItemSaveAndClose.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.MenuItemSaveAndClose.Size = new System.Drawing.Size(226, 26);
            this.MenuItemSaveAndClose.Text = "Kaydet Kapat";
            this.MenuItemSaveAndClose.Click += new System.EventHandler(this.MenuItemSaveAndClose_Click);
            // 
            // MenuItemSaveNext
            // 
            this.MenuItemSaveNext.Name = "MenuItemSaveNext";
            this.MenuItemSaveNext.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.MenuItemSaveNext.Size = new System.Drawing.Size(226, 26);
            this.MenuItemSaveNext.Text = "Kaydet Sonraki";
            this.MenuItemSaveNext.Click += new System.EventHandler(this.MenuItemSaveNext_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSave.Size = new System.Drawing.Size(226, 26);
            this.MenuItemSave.Text = "Kaydet";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemShareInstagram
            // 
            this.MenuItemShareInstagram.Name = "MenuItemShareInstagram";
            this.MenuItemShareInstagram.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.MenuItemShareInstagram.Size = new System.Drawing.Size(226, 26);
            this.MenuItemShareInstagram.Text = "Instagram Paylaş";
            this.MenuItemShareInstagram.Click += new System.EventHandler(this.MenuItemShareInstagram_Click);
            // 
            // MenuItemExportN11
            // 
            this.MenuItemExportN11.Name = "MenuItemExportN11";
            this.MenuItemExportN11.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.MenuItemExportN11.Size = new System.Drawing.Size(226, 26);
            this.MenuItemExportN11.Text = "E Pazar\'a Aktar";
            this.MenuItemExportN11.Click += new System.EventHandler(this.MenuItemExportN11_Click);
            // 
            // panelGalery
            // 
            this.panelGalery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGalery.Location = new System.Drawing.Point(0, 0);
            this.panelGalery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelGalery.Name = "panelGalery";
            this.panelGalery.Size = new System.Drawing.Size(339, 722);
            this.panelGalery.TabIndex = 13;
            // 
            // webBrowserProduct
            // 
            this.webBrowserProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserProduct.Location = new System.Drawing.Point(0, 0);
            this.webBrowserProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowserProduct.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowserProduct.Name = "webBrowserProduct";
            this.webBrowserProduct.ScriptErrorsSuppressed = true;
            this.webBrowserProduct.Size = new System.Drawing.Size(1157, 719);
            this.webBrowserProduct.TabIndex = 14;
            this.webBrowserProduct.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserProduct_DocumentCompleted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1208, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Google Search";
            // 
            // textBoxGoogleUrl
            // 
            this.textBoxGoogleUrl.Location = new System.Drawing.Point(1388, 100);
            this.textBoxGoogleUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGoogleUrl.Name = "textBoxGoogleUrl";
            this.textBoxGoogleUrl.Size = new System.Drawing.Size(735, 22);
            this.textBoxGoogleUrl.TabIndex = 15;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(688, 128);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelGalery);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowserProduct);
            this.splitContainer1.Size = new System.Drawing.Size(1501, 722);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 17;
            // 
            // buttonBack
            // 
            this.buttonBack.Image = global::ETicaretWinApp.Properties.Resources._06;
            this.buttonBack.Location = new System.Drawing.Point(1320, 96);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(59, 28);
            this.buttonBack.TabIndex = 18;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Stok Kodu";
            // 
            // textBoxStokCode
            // 
            this.textBoxStokCode.BackColor = System.Drawing.Color.White;
            this.textBoxStokCode.Location = new System.Drawing.Point(116, 30);
            this.textBoxStokCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxStokCode.Name = "textBoxStokCode";
            this.textBoxStokCode.ReadOnly = true;
            this.textBoxStokCode.Size = new System.Drawing.Size(132, 22);
            this.textBoxStokCode.TabIndex = 20;
            // 
            // textBoxProductSource
            // 
            this.textBoxProductSource.BackColor = System.Drawing.Color.White;
            this.textBoxProductSource.Location = new System.Drawing.Point(388, 31);
            this.textBoxProductSource.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxProductSource.Name = "textBoxProductSource";
            this.textBoxProductSource.ReadOnly = true;
            this.textBoxProductSource.Size = new System.Drawing.Size(132, 22);
            this.textBoxProductSource.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(288, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Ürün Kaynak";
            // 
            // textBoxMarketPrice
            // 
            this.textBoxMarketPrice.Location = new System.Drawing.Point(125, 23);
            this.textBoxMarketPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMarketPrice.Name = "textBoxMarketPrice";
            this.textBoxMarketPrice.Size = new System.Drawing.Size(105, 22);
            this.textBoxMarketPrice.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMimPrice);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxWebPrice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxMarketPrice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxPrice);
            this.groupBox1.Controls.Add(this.textBoxDiscount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(20, 577);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(628, 171);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün Fiyatları";
            // 
            // textBoxMimPrice
            // 
            this.textBoxMimPrice.Location = new System.Drawing.Point(405, 16);
            this.textBoxMimPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMimPrice.Name = "textBoxMimPrice";
            this.textBoxMimPrice.Size = new System.Drawing.Size(105, 22);
            this.textBoxMimPrice.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(259, 20);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Mim Olması Gereken";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 95);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "İnternet Fiyatı";
            // 
            // textBoxWebPrice
            // 
            this.textBoxWebPrice.Location = new System.Drawing.Point(125, 91);
            this.textBoxWebPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxWebPrice.Name = "textBoxWebPrice";
            this.textBoxWebPrice.Size = new System.Drawing.Size(105, 22);
            this.textBoxWebPrice.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 58);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Fiyat";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(720, 36);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Marka";
            // 
            // comboBoxBrand
            // 
            this.comboBoxBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxBrand.FormattingEnabled = true;
            this.comboBoxBrand.Location = new System.Drawing.Point(777, 31);
            this.comboBoxBrand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxBrand.Name = "comboBoxBrand";
            this.comboBoxBrand.Size = new System.Drawing.Size(120, 24);
            this.comboBoxBrand.TabIndex = 26;
            // 
            // labelPictureSource
            // 
            this.labelPictureSource.AutoSize = true;
            this.labelPictureSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelPictureSource.ForeColor = System.Drawing.Color.Green;
            this.labelPictureSource.Location = new System.Drawing.Point(697, 90);
            this.labelPictureSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPictureSource.Name = "labelPictureSource";
            this.labelPictureSource.Size = new System.Drawing.Size(124, 20);
            this.labelPictureSource.TabIndex = 27;
            this.labelPictureSource.Text = "Image Source";
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Location = new System.Drawing.Point(551, 398);
            this.checkBoxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(92, 21);
            this.checkBoxStatus.TabIndex = 29;
            this.checkBoxStatus.Text = "Aktif Ürün";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            // 
            // buttonGetSelectedProduct
            // 
            this.buttonGetSelectedProduct.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonGetSelectedProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetSelectedProduct.Location = new System.Drawing.Point(971, 91);
            this.buttonGetSelectedProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGetSelectedProduct.Name = "buttonGetSelectedProduct";
            this.buttonGetSelectedProduct.Size = new System.Drawing.Size(179, 28);
            this.buttonGetSelectedProduct.TabIndex = 30;
            this.buttonGetSelectedProduct.Text = "Seçilen Ürünü Al";
            this.buttonGetSelectedProduct.UseVisualStyleBackColor = true;
            this.buttonGetSelectedProduct.Click += new System.EventHandler(this.buttonGetSelectedProduct_Click);
            // 
            // textBoxBarkod
            // 
            this.textBoxBarkod.BackColor = System.Drawing.Color.White;
            this.textBoxBarkod.Location = new System.Drawing.Point(585, 33);
            this.textBoxBarkod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBarkod.Name = "textBoxBarkod";
            this.textBoxBarkod.ReadOnly = true;
            this.textBoxBarkod.Size = new System.Drawing.Size(105, 22);
            this.textBoxBarkod.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(523, 37);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 31;
            this.label12.Text = "Barkod";
            // 
            // uCategoryViewProduct
            // 
            productCategory1.CategoryName = "Tümü";
            productCategory1.CategoryUrl = null;
            productCategory1.CicekSepetiCategoryId = 0;
            productCategory1.CicekSepetiCategoryName = null;
            productCategory1.HepsiBuradaCategoryId = 0;
            productCategory1.HepsiBuradaCategoryName = null;
            productCategory1.Id = 0;
            productCategory1.N11CategoryId = 0;
            productCategory1.N11CategoryName = null;
            productCategory1.N11ExportTemplateId = 0;
            productCategory1.N11ExportTemplateName = null;
            productCategory1.TargetCategory = false;
            productCategory1.TrendyolCategoryId = 0;
            productCategory1.TrendyolCategoryName = null;
            productCategory1.UpId = 0;
            this.uCategoryViewProduct.Category = productCategory1;
            this.uCategoryViewProduct.Location = new System.Drawing.Point(16, 69);
            productCategory2.CategoryName = "Tümü";
            productCategory2.CategoryUrl = null;
            productCategory2.CicekSepetiCategoryId = 0;
            productCategory2.CicekSepetiCategoryName = null;
            productCategory2.HepsiBuradaCategoryId = 0;
            productCategory2.HepsiBuradaCategoryName = null;
            productCategory2.Id = 0;
            productCategory2.N11CategoryId = 0;
            productCategory2.N11CategoryName = null;
            productCategory2.N11ExportTemplateId = 0;
            productCategory2.N11ExportTemplateName = null;
            productCategory2.TargetCategory = false;
            productCategory2.TrendyolCategoryId = 0;
            productCategory2.TrendyolCategoryName = null;
            productCategory2.UpId = 0;
            this.uCategoryViewProduct.MainCategory = productCategory2;
            this.uCategoryViewProduct.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.uCategoryViewProduct.Name = "uCategoryViewProduct";
            this.uCategoryViewProduct.Size = new System.Drawing.Size(632, 321);
            productCategory3.CategoryName = "Tümü";
            productCategory3.CategoryUrl = null;
            productCategory3.CicekSepetiCategoryId = 0;
            productCategory3.CicekSepetiCategoryName = null;
            productCategory3.HepsiBuradaCategoryId = 0;
            productCategory3.HepsiBuradaCategoryName = null;
            productCategory3.Id = 0;
            productCategory3.N11CategoryId = 0;
            productCategory3.N11CategoryName = null;
            productCategory3.N11ExportTemplateId = 0;
            productCategory3.N11ExportTemplateName = null;
            productCategory3.TargetCategory = false;
            productCategory3.TrendyolCategoryId = 0;
            productCategory3.TrendyolCategoryName = null;
            productCategory3.UpId = 0;
            this.uCategoryViewProduct.SubCategory = productCategory3;
            this.uCategoryViewProduct.TabIndex = 3;
            // 
            // FormProductEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 894);
            this.Controls.Add(this.textBoxBarkod);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.buttonGetSelectedProduct);
            this.Controls.Add(this.checkBoxStatus);
            this.Controls.Add(this.labelPictureSource);
            this.Controls.Add(this.comboBoxBrand);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxProductSource);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxStokCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxGoogleUrl);
            this.Controls.Add(this.htmlTextboxDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uCategoryViewProduct);
            this.Controls.Add(this.textBoxProductName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormProductEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Düzenle";
            this.Load += new System.EventHandler(this.FormProductEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label label4;
        private GvS.Controls.HtmlTextbox htmlTextboxDescription;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAndClose;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveNext;
        private System.Windows.Forms.Panel panelGalery;
        private System.Windows.Forms.WebBrowser webBrowserProduct;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGoogleUrl;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStokCode;
        private System.Windows.Forms.TextBox textBoxProductSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxMarketPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxBrand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxWebPrice;
        private System.Windows.Forms.Label labelPictureSource;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.Button buttonGetSelectedProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuItemShareInstagram;
        private System.Windows.Forms.TextBox textBoxMimPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxBarkod;
        private System.Windows.Forms.Label label12;
        private Controls.UCategoryView uCategoryViewProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportN11;
    }
}