namespace ETicaretWinApp.Controls
{
    partial class UProductFilterCombo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxInternetFiyat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStokSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxWebExportState = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStokCodeList = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboBoxExportN11 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxExportHB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPriceFilterType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dTimePickerCreated = new System.Windows.Forms.DateTimePicker();
            this.comboBoxExportIdea = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDateFilterType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxInternetFiyat
            // 
            this.comboBoxInternetFiyat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInternetFiyat.FormattingEnabled = true;
            this.comboBoxInternetFiyat.Location = new System.Drawing.Point(138, 88);
            this.comboBoxInternetFiyat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxInternetFiyat.Name = "comboBoxInternetFiyat";
            this.comboBoxInternetFiyat.Size = new System.Drawing.Size(69, 21);
            this.comboBoxInternetFiyat.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "İnternet Fiyatı ";
            // 
            // comboBoxStokSource
            // 
            this.comboBoxStokSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStokSource.FormattingEnabled = true;
            this.comboBoxStokSource.Location = new System.Drawing.Point(138, 49);
            this.comboBoxStokSource.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxStokSource.Name = "comboBoxStokSource";
            this.comboBoxStokSource.Size = new System.Drawing.Size(154, 21);
            this.comboBoxStokSource.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Stok Kaynağı";
            // 
            // comboBoxWebExportState
            // 
            this.comboBoxWebExportState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWebExportState.FormattingEnabled = true;
            this.comboBoxWebExportState.Location = new System.Drawing.Point(138, 9);
            this.comboBoxWebExportState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxWebExportState.Name = "comboBoxWebExportState";
            this.comboBoxWebExportState.Size = new System.Drawing.Size(154, 21);
            this.comboBoxWebExportState.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Web Export Durumu";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(257, 88);
            this.comboBoxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(78, 21);
            this.comboBoxStatus.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Durum";
            // 
            // buttonStokCodeList
            // 
            this.buttonStokCodeList.Location = new System.Drawing.Point(309, 7);
            this.buttonStokCodeList.Name = "buttonStokCodeList";
            this.buttonStokCodeList.Size = new System.Drawing.Size(110, 23);
            this.buttonStokCodeList.TabIndex = 26;
            this.buttonStokCodeList.Text = "Stok Kodu Yükle";
            this.buttonStokCodeList.UseVisualStyleBackColor = true;
            this.buttonStokCodeList.Click += new System.EventHandler(this.buttonStokCodeList_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Image = global::ETicaretWinApp.Properties.Resources._21;
            this.buttonReset.Location = new System.Drawing.Point(425, 7);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(21, 23);
            this.buttonReset.TabIndex = 27;
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // comboBoxExportN11
            // 
            this.comboBoxExportN11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportN11.FormattingEnabled = true;
            this.comboBoxExportN11.Items.AddRange(new object[] {
            "Tümü",
            "Evet",
            "Hayır",
            "Aktif (Satışta)",
            "Beklemede",
            "Yasaklı",
            "Liste Dışı",
            "Onay bekleyen",
            "Reddedilen"});
            this.comboBoxExportN11.Location = new System.Drawing.Point(438, 52);
            this.comboBoxExportN11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxExportN11.Name = "comboBoxExportN11";
            this.comboBoxExportN11.Size = new System.Drawing.Size(78, 21);
            this.comboBoxExportN11.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(362, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Export N11";
            // 
            // comboBoxExportHB
            // 
            this.comboBoxExportHB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportHB.FormattingEnabled = true;
            this.comboBoxExportHB.Items.AddRange(new object[] {
            "Tümü",
            "Evet",
            "Hayır"});
            this.comboBoxExportHB.Location = new System.Drawing.Point(438, 91);
            this.comboBoxExportHB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxExportHB.Name = "comboBoxExportHB";
            this.comboBoxExportHB.Size = new System.Drawing.Size(78, 21);
            this.comboBoxExportHB.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(362, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Export HB";
            // 
            // comboBoxPriceFilterType
            // 
            this.comboBoxPriceFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriceFilterType.FormattingEnabled = true;
            this.comboBoxPriceFilterType.Items.AddRange(new object[] {
            "Tümü",
            ">",
            "<",
            "="});
            this.comboBoxPriceFilterType.Location = new System.Drawing.Point(565, 52);
            this.comboBoxPriceFilterType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxPriceFilterType.Name = "comboBoxPriceFilterType";
            this.comboBoxPriceFilterType.Size = new System.Drawing.Size(61, 21);
            this.comboBoxPriceFilterType.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(530, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Fiyat";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(633, 52);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(73, 20);
            this.textBoxPrice.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(530, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Oluşturma";
            // 
            // dTimePickerCreated
            // 
            this.dTimePickerCreated.Checked = false;
            this.dTimePickerCreated.Location = new System.Drawing.Point(657, 91);
            this.dTimePickerCreated.Name = "dTimePickerCreated";
            this.dTimePickerCreated.ShowCheckBox = true;
            this.dTimePickerCreated.Size = new System.Drawing.Size(111, 20);
            this.dTimePickerCreated.TabIndex = 36;
            // 
            // comboBoxExportIdea
            // 
            this.comboBoxExportIdea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxExportIdea.FormattingEnabled = true;
            this.comboBoxExportIdea.Items.AddRange(new object[] {
            "Tümü",
            "Evet",
            "Hayır"});
            this.comboBoxExportIdea.Location = new System.Drawing.Point(438, 133);
            this.comboBoxExportIdea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxExportIdea.Name = "comboBoxExportIdea";
            this.comboBoxExportIdea.Size = new System.Drawing.Size(78, 21);
            this.comboBoxExportIdea.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Export Idea";
            // 
            // comboBoxDateFilterType
            // 
            this.comboBoxDateFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDateFilterType.FormattingEnabled = true;
            this.comboBoxDateFilterType.Items.AddRange(new object[] {
            "=",
            ">",
            "<"});
            this.comboBoxDateFilterType.Location = new System.Drawing.Point(590, 90);
            this.comboBoxDateFilterType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxDateFilterType.Name = "comboBoxDateFilterType";
            this.comboBoxDateFilterType.Size = new System.Drawing.Size(61, 21);
            this.comboBoxDateFilterType.TabIndex = 39;
            // 
            // UProductFilterCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxDateFilterType);
            this.Controls.Add(this.comboBoxExportIdea);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dTimePickerCreated);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.comboBoxPriceFilterType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxExportHB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxExportN11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonStokCodeList);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxInternetFiyat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxStokSource);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxWebExportState);
            this.Controls.Add(this.label4);
            this.Name = "UProductFilterCombo";
            this.Size = new System.Drawing.Size(785, 172);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxInternetFiyat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStokSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxWebExportState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStokCodeList;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ComboBox comboBoxExportN11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxExportHB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPriceFilterType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dTimePickerCreated;
        private System.Windows.Forms.ComboBox comboBoxExportIdea;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDateFilterType;
    }
}
