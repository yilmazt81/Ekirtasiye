﻿namespace ETicaretWinApp
{
    partial class FormShopSetting
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBoxUseHb = new System.Windows.Forms.CheckBox();
            this.textBoxHBListingAdress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxHBProductAdress = new System.Windows.Forms.TextBox();
            this.textBoxHBPassword = new System.Windows.Forms.TextBox();
            this.textBoxHBUserName = new System.Windows.Forms.TextBox();
            this.textBoxHBMerchandId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxUseN11 = new System.Windows.Forms.CheckBox();
            this.buttonN11CategoryGet = new System.Windows.Forms.Button();
            this.textBoxN11SecretKey = new System.Windows.Forms.TextBox();
            this.textBoxN11AppKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageTrendYol = new System.Windows.Forms.TabPage();
            this.checkBoxUseTrend = new System.Windows.Forms.CheckBox();
            this.buttonTrendyolRefresh = new System.Windows.Forms.Button();
            this.comboBoxTrendyolCargo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonGetCategoryTrendyol = new System.Windows.Forms.Button();
            this.textBoxTyEndPoint = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTyPassword = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTyUserName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTySupplierId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.imageListShop = new System.Windows.Forms.ImageList(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tabPageCicekSepeti = new System.Windows.Forms.TabPage();
            this.checkBoxUseCicekSepeti = new System.Windows.Forms.CheckBox();
            this.textBoxCicekSepetiApiKey = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxCicekSepetiSupplierId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonCicekSepetiGetCategory = new System.Windows.Forms.Button();
            this.textBoxCicekSepetiUrl = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPageTrendYol.SuspendLayout();
            this.tabPageCicekSepeti.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPageTrendYol);
            this.tabControl1.Controls.Add(this.tabPageCicekSepeti);
            this.tabControl1.Location = new System.Drawing.Point(17, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 319);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxUseHb);
            this.tabPage1.Controls.Add(this.textBoxHBListingAdress);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.textBoxHBProductAdress);
            this.tabPage1.Controls.Add(this.textBoxHBPassword);
            this.tabPage1.Controls.Add(this.textBoxHBUserName);
            this.tabPage1.Controls.Add(this.textBoxHBMerchandId);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(581, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hepsi Burada";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseHb
            // 
            this.checkBoxUseHb.AutoSize = true;
            this.checkBoxUseHb.Location = new System.Drawing.Point(38, 8);
            this.checkBoxUseHb.Name = "checkBoxUseHb";
            this.checkBoxUseHb.Size = new System.Drawing.Size(172, 22);
            this.checkBoxUseHb.TabIndex = 10;
            this.checkBoxUseHb.Text = "HB Entegrasyonu kullan";
            this.checkBoxUseHb.UseVisualStyleBackColor = true;
            // 
            // textBoxHBListingAdress
            // 
            this.textBoxHBListingAdress.Location = new System.Drawing.Point(191, 184);
            this.textBoxHBListingAdress.Name = "textBoxHBListingAdress";
            this.textBoxHBListingAdress.Size = new System.Drawing.Size(333, 26);
            this.textBoxHBListingAdress.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 187);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 18);
            this.label7.TabIndex = 8;
            this.label7.Text = "Listing Service Adress";
            // 
            // textBoxHBProductAdress
            // 
            this.textBoxHBProductAdress.Location = new System.Drawing.Point(191, 143);
            this.textBoxHBProductAdress.Name = "textBoxHBProductAdress";
            this.textBoxHBProductAdress.Size = new System.Drawing.Size(333, 26);
            this.textBoxHBProductAdress.TabIndex = 7;
            // 
            // textBoxHBPassword
            // 
            this.textBoxHBPassword.Location = new System.Drawing.Point(124, 106);
            this.textBoxHBPassword.Name = "textBoxHBPassword";
            this.textBoxHBPassword.PasswordChar = '*';
            this.textBoxHBPassword.Size = new System.Drawing.Size(400, 26);
            this.textBoxHBPassword.TabIndex = 6;
            // 
            // textBoxHBUserName
            // 
            this.textBoxHBUserName.Location = new System.Drawing.Point(124, 73);
            this.textBoxHBUserName.Name = "textBoxHBUserName";
            this.textBoxHBUserName.Size = new System.Drawing.Size(400, 26);
            this.textBoxHBUserName.TabIndex = 5;
            // 
            // textBoxHBMerchandId
            // 
            this.textBoxHBMerchandId.Location = new System.Drawing.Point(124, 37);
            this.textBoxHBMerchandId.Name = "textBoxHBMerchandId";
            this.textBoxHBMerchandId.Size = new System.Drawing.Size(400, 26);
            this.textBoxHBMerchandId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product Service Adress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Merchant Id";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBoxUseN11);
            this.tabPage2.Controls.Add(this.buttonN11CategoryGet);
            this.tabPage2.Controls.Add(this.textBoxN11SecretKey);
            this.tabPage2.Controls.Add(this.textBoxN11AppKey);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(581, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "N11";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseN11
            // 
            this.checkBoxUseN11.AutoSize = true;
            this.checkBoxUseN11.Location = new System.Drawing.Point(21, 5);
            this.checkBoxUseN11.Name = "checkBoxUseN11";
            this.checkBoxUseN11.Size = new System.Drawing.Size(179, 22);
            this.checkBoxUseN11.TabIndex = 12;
            this.checkBoxUseN11.Text = "N11 Entegrasyonu kullan";
            this.checkBoxUseN11.UseVisualStyleBackColor = true;
            // 
            // buttonN11CategoryGet
            // 
            this.buttonN11CategoryGet.Image = global::ETicaretWinApp.Properties.Resources._07;
            this.buttonN11CategoryGet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonN11CategoryGet.Location = new System.Drawing.Point(305, 109);
            this.buttonN11CategoryGet.Name = "buttonN11CategoryGet";
            this.buttonN11CategoryGet.Size = new System.Drawing.Size(202, 31);
            this.buttonN11CategoryGet.TabIndex = 11;
            this.buttonN11CategoryGet.Text = "KategoryListesi Çek";
            this.buttonN11CategoryGet.UseVisualStyleBackColor = true;
            this.buttonN11CategoryGet.Click += new System.EventHandler(this.buttonN11CategoryGet_Click);
            // 
            // textBoxN11SecretKey
            // 
            this.textBoxN11SecretKey.Location = new System.Drawing.Point(107, 63);
            this.textBoxN11SecretKey.Name = "textBoxN11SecretKey";
            this.textBoxN11SecretKey.PasswordChar = '*';
            this.textBoxN11SecretKey.Size = new System.Drawing.Size(400, 26);
            this.textBoxN11SecretKey.TabIndex = 10;
            // 
            // textBoxN11AppKey
            // 
            this.textBoxN11AppKey.Location = new System.Drawing.Point(107, 30);
            this.textBoxN11AppKey.Name = "textBoxN11AppKey";
            this.textBoxN11AppKey.Size = new System.Drawing.Size(400, 26);
            this.textBoxN11AppKey.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "ScreetKey";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "AppKey";
            // 
            // tabPageTrendYol
            // 
            this.tabPageTrendYol.Controls.Add(this.checkBoxUseTrend);
            this.tabPageTrendYol.Controls.Add(this.buttonTrendyolRefresh);
            this.tabPageTrendYol.Controls.Add(this.comboBoxTrendyolCargo);
            this.tabPageTrendYol.Controls.Add(this.label12);
            this.tabPageTrendYol.Controls.Add(this.buttonGetCategoryTrendyol);
            this.tabPageTrendYol.Controls.Add(this.textBoxTyEndPoint);
            this.tabPageTrendYol.Controls.Add(this.label11);
            this.tabPageTrendYol.Controls.Add(this.textBoxTyPassword);
            this.tabPageTrendYol.Controls.Add(this.label10);
            this.tabPageTrendYol.Controls.Add(this.textBoxTyUserName);
            this.tabPageTrendYol.Controls.Add(this.label9);
            this.tabPageTrendYol.Controls.Add(this.textBoxTySupplierId);
            this.tabPageTrendYol.Controls.Add(this.label8);
            this.tabPageTrendYol.Location = new System.Drawing.Point(4, 27);
            this.tabPageTrendYol.Name = "tabPageTrendYol";
            this.tabPageTrendYol.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrendYol.Size = new System.Drawing.Size(581, 288);
            this.tabPageTrendYol.TabIndex = 2;
            this.tabPageTrendYol.Text = "TrendYol";
            this.tabPageTrendYol.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseTrend
            // 
            this.checkBoxUseTrend.AutoSize = true;
            this.checkBoxUseTrend.Location = new System.Drawing.Point(6, 1);
            this.checkBoxUseTrend.Name = "checkBoxUseTrend";
            this.checkBoxUseTrend.Size = new System.Drawing.Size(190, 22);
            this.checkBoxUseTrend.TabIndex = 16;
            this.checkBoxUseTrend.Text = "Trend Entegrasyonu kullan";
            this.checkBoxUseTrend.UseVisualStyleBackColor = true;
            // 
            // buttonTrendyolRefresh
            // 
            this.buttonTrendyolRefresh.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonTrendyolRefresh.Location = new System.Drawing.Point(429, 202);
            this.buttonTrendyolRefresh.Name = "buttonTrendyolRefresh";
            this.buttonTrendyolRefresh.Size = new System.Drawing.Size(45, 25);
            this.buttonTrendyolRefresh.TabIndex = 15;
            this.buttonTrendyolRefresh.UseVisualStyleBackColor = true;
            this.buttonTrendyolRefresh.Click += new System.EventHandler(this.buttonTrendyolRefresh_Click);
            // 
            // comboBoxTrendyolCargo
            // 
            this.comboBoxTrendyolCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrendyolCargo.FormattingEnabled = true;
            this.comboBoxTrendyolCargo.Location = new System.Drawing.Point(127, 201);
            this.comboBoxTrendyolCargo.Name = "comboBoxTrendyolCargo";
            this.comboBoxTrendyolCargo.Size = new System.Drawing.Size(296, 26);
            this.comboBoxTrendyolCargo.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 205);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 18);
            this.label12.TabIndex = 13;
            this.label12.Text = "Kargo Firması";
            // 
            // buttonGetCategoryTrendyol
            // 
            this.buttonGetCategoryTrendyol.Image = global::ETicaretWinApp.Properties.Resources._07;
            this.buttonGetCategoryTrendyol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetCategoryTrendyol.Location = new System.Drawing.Point(373, 248);
            this.buttonGetCategoryTrendyol.Name = "buttonGetCategoryTrendyol";
            this.buttonGetCategoryTrendyol.Size = new System.Drawing.Size(202, 31);
            this.buttonGetCategoryTrendyol.TabIndex = 12;
            this.buttonGetCategoryTrendyol.Text = "KategoryListesi Çek";
            this.buttonGetCategoryTrendyol.UseVisualStyleBackColor = true;
            this.buttonGetCategoryTrendyol.Click += new System.EventHandler(this.buttonGetCategoryTrendyol_Click);
            // 
            // textBoxTyEndPoint
            // 
            this.textBoxTyEndPoint.Location = new System.Drawing.Point(127, 153);
            this.textBoxTyEndPoint.Name = "textBoxTyEndPoint";
            this.textBoxTyEndPoint.Size = new System.Drawing.Size(296, 26);
            this.textBoxTyEndPoint.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Url";
            // 
            // textBoxTyPassword
            // 
            this.textBoxTyPassword.Location = new System.Drawing.Point(127, 103);
            this.textBoxTyPassword.Name = "textBoxTyPassword";
            this.textBoxTyPassword.Size = new System.Drawing.Size(296, 26);
            this.textBoxTyPassword.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 18);
            this.label10.TabIndex = 4;
            this.label10.Text = "API Secet";
            // 
            // textBoxTyUserName
            // 
            this.textBoxTyUserName.Location = new System.Drawing.Point(127, 61);
            this.textBoxTyUserName.Name = "textBoxTyUserName";
            this.textBoxTyUserName.Size = new System.Drawing.Size(296, 26);
            this.textBoxTyUserName.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "API Key";
            // 
            // textBoxTySupplierId
            // 
            this.textBoxTySupplierId.Location = new System.Drawing.Point(127, 24);
            this.textBoxTySupplierId.Name = "textBoxTySupplierId";
            this.textBoxTySupplierId.Size = new System.Drawing.Size(296, 26);
            this.textBoxTySupplierId.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "SupplierID";
            // 
            // imageListShop
            // 
            this.imageListShop.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListShop.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListShop.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Image = global::ETicaretWinApp.Properties.Resources._50;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(308, 344);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(124, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(478, 344);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(124, 35);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Tamam";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tabPageCicekSepeti
            // 
            this.tabPageCicekSepeti.Controls.Add(this.textBoxCicekSepetiUrl);
            this.tabPageCicekSepeti.Controls.Add(this.label15);
            this.tabPageCicekSepeti.Controls.Add(this.buttonCicekSepetiGetCategory);
            this.tabPageCicekSepeti.Controls.Add(this.textBoxCicekSepetiApiKey);
            this.tabPageCicekSepeti.Controls.Add(this.label13);
            this.tabPageCicekSepeti.Controls.Add(this.textBoxCicekSepetiSupplierId);
            this.tabPageCicekSepeti.Controls.Add(this.label14);
            this.tabPageCicekSepeti.Controls.Add(this.checkBoxUseCicekSepeti);
            this.tabPageCicekSepeti.Location = new System.Drawing.Point(4, 27);
            this.tabPageCicekSepeti.Name = "tabPageCicekSepeti";
            this.tabPageCicekSepeti.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCicekSepeti.Size = new System.Drawing.Size(581, 288);
            this.tabPageCicekSepeti.TabIndex = 3;
            this.tabPageCicekSepeti.Text = "Çiçek Sepeti";
            this.tabPageCicekSepeti.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseCicekSepeti
            // 
            this.checkBoxUseCicekSepeti.AutoSize = true;
            this.checkBoxUseCicekSepeti.Location = new System.Drawing.Point(17, 17);
            this.checkBoxUseCicekSepeti.Name = "checkBoxUseCicekSepeti";
            this.checkBoxUseCicekSepeti.Size = new System.Drawing.Size(230, 22);
            this.checkBoxUseCicekSepeti.TabIndex = 17;
            this.checkBoxUseCicekSepeti.Text = "Çiçek Sepeti Entegrasyonu kullan";
            this.checkBoxUseCicekSepeti.UseVisualStyleBackColor = true;
            // 
            // textBoxCicekSepetiApiKey
            // 
            this.textBoxCicekSepetiApiKey.Location = new System.Drawing.Point(115, 93);
            this.textBoxCicekSepetiApiKey.Name = "textBoxCicekSepetiApiKey";
            this.textBoxCicekSepetiApiKey.Size = new System.Drawing.Size(296, 26);
            this.textBoxCicekSepetiApiKey.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 18);
            this.label13.TabIndex = 20;
            this.label13.Text = "API Key";
            // 
            // textBoxCicekSepetiSupplierId
            // 
            this.textBoxCicekSepetiSupplierId.Location = new System.Drawing.Point(115, 56);
            this.textBoxCicekSepetiSupplierId.Name = "textBoxCicekSepetiSupplierId";
            this.textBoxCicekSepetiSupplierId.Size = new System.Drawing.Size(296, 26);
            this.textBoxCicekSepetiSupplierId.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 18);
            this.label14.TabIndex = 18;
            this.label14.Text = "SupplierID";
            // 
            // buttonCicekSepetiGetCategory
            // 
            this.buttonCicekSepetiGetCategory.Image = global::ETicaretWinApp.Properties.Resources._07;
            this.buttonCicekSepetiGetCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCicekSepetiGetCategory.Location = new System.Drawing.Point(209, 182);
            this.buttonCicekSepetiGetCategory.Name = "buttonCicekSepetiGetCategory";
            this.buttonCicekSepetiGetCategory.Size = new System.Drawing.Size(202, 31);
            this.buttonCicekSepetiGetCategory.TabIndex = 22;
            this.buttonCicekSepetiGetCategory.Text = "KategoryListesi Çek";
            this.buttonCicekSepetiGetCategory.UseVisualStyleBackColor = true;
            this.buttonCicekSepetiGetCategory.Click += new System.EventHandler(this.buttonCicekSepetiGetCategory_Click);
            // 
            // textBoxCicekSepetiUrl
            // 
            this.textBoxCicekSepetiUrl.Location = new System.Drawing.Point(115, 130);
            this.textBoxCicekSepetiUrl.Name = "textBoxCicekSepetiUrl";
            this.textBoxCicekSepetiUrl.Size = new System.Drawing.Size(296, 26);
            this.textBoxCicekSepetiUrl.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(15, 133);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(26, 18);
            this.label15.TabIndex = 23;
            this.label15.Text = "Url";
            // 
            // FormShopSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 385);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormShopSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pazar Yeri Ayarlari";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPageTrendYol.ResumeLayout(false);
            this.tabPageTrendYol.PerformLayout();
            this.tabPageCicekSepeti.ResumeLayout(false);
            this.tabPageCicekSepeti.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageListShop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHBProductAdress;
        private System.Windows.Forms.TextBox textBoxHBPassword;
        private System.Windows.Forms.TextBox textBoxHBUserName;
        private System.Windows.Forms.TextBox textBoxHBMerchandId;
        private System.Windows.Forms.TextBox textBoxN11SecretKey;
        private System.Windows.Forms.TextBox textBoxN11AppKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxHBListingAdress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonN11CategoryGet;
        private System.Windows.Forms.TabPage tabPageTrendYol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTySupplierId;
        private System.Windows.Forms.TextBox textBoxTyUserName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxTyPassword;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxTyEndPoint;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonGetCategoryTrendyol;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxTrendyolCargo;
        private System.Windows.Forms.Button buttonTrendyolRefresh;
        private System.Windows.Forms.CheckBox checkBoxUseHb;
        private System.Windows.Forms.CheckBox checkBoxUseN11;
        private System.Windows.Forms.CheckBox checkBoxUseTrend;
        private System.Windows.Forms.TabPage tabPageCicekSepeti;
        private System.Windows.Forms.CheckBox checkBoxUseCicekSepeti;
        private System.Windows.Forms.Button buttonCicekSepetiGetCategory;
        private System.Windows.Forms.TextBox textBoxCicekSepetiApiKey;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxCicekSepetiSupplierId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCicekSepetiUrl;
        private System.Windows.Forms.Label label15;
    }
}