namespace ETicaretWinApp
{
    partial class FormN11ExportTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormN11ExportTemplate));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDeliveryTemplate = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTemplateName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDeliveryDay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPriceType = new System.Windows.Forms.ComboBox();
            this.comboBoxCalculateType = new System.Windows.Forms.ComboBox();
            this.textBoxCalculateValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSubText = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDeliveryDay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Teslimat Şablonu";
            // 
            // comboBoxDeliveryTemplate
            // 
            this.comboBoxDeliveryTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDeliveryTemplate.FormattingEnabled = true;
            this.comboBoxDeliveryTemplate.Location = new System.Drawing.Point(329, 102);
            this.comboBoxDeliveryTemplate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDeliveryTemplate.Name = "comboBoxDeliveryTemplate";
            this.comboBoxDeliveryTemplate.Size = new System.Drawing.Size(323, 27);
            this.comboBoxDeliveryTemplate.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 55);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Şablon İsmi";
            // 
            // textBoxTemplateName
            // 
            this.textBoxTemplateName.Location = new System.Drawing.Point(329, 16);
            this.textBoxTemplateName.Name = "textBoxTemplateName";
            this.textBoxTemplateName.Size = new System.Drawing.Size(323, 27);
            this.textBoxTemplateName.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kargo Süresi";
            // 
            // numericUpDeliveryDay
            // 
            this.numericUpDeliveryDay.Location = new System.Drawing.Point(329, 61);
            this.numericUpDeliveryDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDeliveryDay.Name = "numericUpDeliveryDay";
            this.numericUpDeliveryDay.Size = new System.Drawing.Size(63, 27);
            this.numericUpDeliveryDay.TabIndex = 9;
            this.numericUpDeliveryDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gün";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(197, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Satış Fiyatı";
            // 
            // comboBoxPriceType
            // 
            this.comboBoxPriceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPriceType.FormattingEnabled = true;
            this.comboBoxPriceType.Items.AddRange(new object[] {
            "Maliyet",
            "Web Fiyat"});
            this.comboBoxPriceType.Location = new System.Drawing.Point(329, 151);
            this.comboBoxPriceType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPriceType.Name = "comboBoxPriceType";
            this.comboBoxPriceType.Size = new System.Drawing.Size(100, 27);
            this.comboBoxPriceType.TabIndex = 12;
            // 
            // comboBoxCalculateType
            // 
            this.comboBoxCalculateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCalculateType.FormattingEnabled = true;
            this.comboBoxCalculateType.Items.AddRange(new object[] {
            "X",
            "+",
            "-"});
            this.comboBoxCalculateType.Location = new System.Drawing.Point(437, 151);
            this.comboBoxCalculateType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCalculateType.Name = "comboBoxCalculateType";
            this.comboBoxCalculateType.Size = new System.Drawing.Size(72, 27);
            this.comboBoxCalculateType.TabIndex = 13;
            // 
            // textBoxCalculateValue
            // 
            this.textBoxCalculateValue.Location = new System.Drawing.Point(516, 151);
            this.textBoxCalculateValue.Name = "textBoxCalculateValue";
            this.textBoxCalculateValue.Size = new System.Drawing.Size(75, 27);
            this.textBoxCalculateValue.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Satış Başlangıç";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 259);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Satış Bitiş";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Checked = false;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(329, 209);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.ShowCheckBox = true;
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(275, 27);
            this.dateTimePickerStartDate.TabIndex = 17;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Checked = false;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(329, 253);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.ShowCheckBox = true;
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(275, 27);
            this.dateTimePickerEndDate.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 309);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Alt Başlık";
            // 
            // textBoxSubText
            // 
            this.textBoxSubText.Location = new System.Drawing.Point(329, 309);
            this.textBoxSubText.Name = "textBoxSubText";
            this.textBoxSubText.Size = new System.Drawing.Size(323, 27);
            this.textBoxSubText.TabIndex = 20;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Image = global::ETicaretWinApp.Properties.Resources._50;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(365, 381);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 37);
            this.buttonCancel.TabIndex = 22;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(516, 381);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(129, 37);
            this.buttonOk.TabIndex = 21;
            this.buttonOk.Text = "Tamam ";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormN11ExportTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 430);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxSubText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCalculateValue);
            this.Controls.Add(this.comboBoxCalculateType);
            this.Controls.Add(this.comboBoxPriceType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDeliveryDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTemplateName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDeliveryTemplate);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormN11ExportTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "N11 Export Template";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDeliveryDay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDeliveryTemplate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTemplateName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDeliveryDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPriceType;
        private System.Windows.Forms.ComboBox comboBoxCalculateType;
        private System.Windows.Forms.TextBox textBoxCalculateValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSubText;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}