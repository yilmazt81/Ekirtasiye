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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageListShop = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHBMerchandId = new System.Windows.Forms.TextBox();
            this.textBoxHBUserName = new System.Windows.Forms.TextBox();
            this.textBoxHBPassword = new System.Windows.Forms.TextBox();
            this.textBoxHBProductAdress = new System.Windows.Forms.TextBox();
            this.textBoxN11SecretKey = new System.Windows.Forms.TextBox();
            this.textBoxN11AppKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxHBListingAdress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonN11CategoryGet = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(17, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(589, 319);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
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
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(581, 288);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hepsi Burada";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonN11CategoryGet);
            this.tabPage2.Controls.Add(this.textBoxN11SecretKey);
            this.tabPage2.Controls.Add(this.textBoxN11AppKey);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(581, 288);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "N11";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageListShop
            // 
            this.imageListShop.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListShop.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListShop.TransparentColor = System.Drawing.Color.Transparent;
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
            // textBoxHBMerchandId
            // 
            this.textBoxHBMerchandId.Location = new System.Drawing.Point(124, 37);
            this.textBoxHBMerchandId.Name = "textBoxHBMerchandId";
            this.textBoxHBMerchandId.Size = new System.Drawing.Size(400, 26);
            this.textBoxHBMerchandId.TabIndex = 4;
            // 
            // textBoxHBUserName
            // 
            this.textBoxHBUserName.Location = new System.Drawing.Point(124, 73);
            this.textBoxHBUserName.Name = "textBoxHBUserName";
            this.textBoxHBUserName.Size = new System.Drawing.Size(400, 26);
            this.textBoxHBUserName.TabIndex = 5;
            // 
            // textBoxHBPassword
            // 
            this.textBoxHBPassword.Location = new System.Drawing.Point(124, 106);
            this.textBoxHBPassword.Name = "textBoxHBPassword";
            this.textBoxHBPassword.PasswordChar = '*';
            this.textBoxHBPassword.Size = new System.Drawing.Size(400, 26);
            this.textBoxHBPassword.TabIndex = 6;
            // 
            // textBoxHBProductAdress
            // 
            this.textBoxHBProductAdress.Location = new System.Drawing.Point(191, 143);
            this.textBoxHBProductAdress.Name = "textBoxHBProductAdress";
            this.textBoxHBProductAdress.Size = new System.Drawing.Size(333, 26);
            this.textBoxHBProductAdress.TabIndex = 7;
            // 
            // textBoxN11SecretKey
            // 
            this.textBoxN11SecretKey.Location = new System.Drawing.Point(107, 60);
            this.textBoxN11SecretKey.Name = "textBoxN11SecretKey";
            this.textBoxN11SecretKey.PasswordChar = '*';
            this.textBoxN11SecretKey.Size = new System.Drawing.Size(400, 26);
            this.textBoxN11SecretKey.TabIndex = 10;
            // 
            // textBoxN11AppKey
            // 
            this.textBoxN11AppKey.Location = new System.Drawing.Point(107, 27);
            this.textBoxN11AppKey.Name = "textBoxN11AppKey";
            this.textBoxN11AppKey.Size = new System.Drawing.Size(400, 26);
            this.textBoxN11AppKey.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 63);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "ScreetKey";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "AppKey";
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
            // FormShopSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 385);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormShopSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pazar Yeri Ayarlari";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
    }
}