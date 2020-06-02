namespace ETicaretWinApp
{
    partial class FormSelectProductSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectProductSource));
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxExportAll = new System.Windows.Forms.CheckBox();
            this.checkBoxAddDiscount = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numUpDownMaxDiscount = new System.Windows.Forms.NumericUpDown();
            this.panelDiscount = new System.Windows.Forms.Panel();
            this.numUpDownDiscountProductCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.uProductFilterCombo1 = new ETicaretWinApp.Controls.UProductFilterCombo();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMaxDiscount)).BeginInit();
            this.panelDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDiscountProductCount)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOk.Location = new System.Drawing.Point(615, 304);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(107, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Tamam";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Image = global::ETicaretWinApp.Properties.Resources._50;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(489, 302);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "İptal";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxExportAll
            // 
            this.checkBoxExportAll.AutoSize = true;
            this.checkBoxExportAll.Location = new System.Drawing.Point(25, 135);
            this.checkBoxExportAll.Name = "checkBoxExportAll";
            this.checkBoxExportAll.Size = new System.Drawing.Size(104, 17);
            this.checkBoxExportAll.TabIndex = 3;
            this.checkBoxExportAll.Text = "Tüm Kayıtları işle";
            this.checkBoxExportAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddDiscount
            // 
            this.checkBoxAddDiscount.AutoSize = true;
            this.checkBoxAddDiscount.Location = new System.Drawing.Point(25, 178);
            this.checkBoxAddDiscount.Name = "checkBoxAddDiscount";
            this.checkBoxAddDiscount.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAddDiscount.TabIndex = 4;
            this.checkBoxAddDiscount.Text = "İndirim Uygula";
            this.checkBoxAddDiscount.UseVisualStyleBackColor = true;
            this.checkBoxAddDiscount.CheckedChanged += new System.EventHandler(this.checkBoxAddDiscount_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Maximum İndirim";
            // 
            // numUpDownMaxDiscount
            // 
            this.numUpDownMaxDiscount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownMaxDiscount.Location = new System.Drawing.Point(96, 7);
            this.numUpDownMaxDiscount.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numUpDownMaxDiscount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUpDownMaxDiscount.Name = "numUpDownMaxDiscount";
            this.numUpDownMaxDiscount.Size = new System.Drawing.Size(68, 20);
            this.numUpDownMaxDiscount.TabIndex = 6;
            this.numUpDownMaxDiscount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // panelDiscount
            // 
            this.panelDiscount.Controls.Add(this.numUpDownDiscountProductCount);
            this.panelDiscount.Controls.Add(this.label2);
            this.panelDiscount.Controls.Add(this.numUpDownMaxDiscount);
            this.panelDiscount.Controls.Add(this.label1);
            this.panelDiscount.Location = new System.Drawing.Point(128, 173);
            this.panelDiscount.Name = "panelDiscount";
            this.panelDiscount.Size = new System.Drawing.Size(336, 69);
            this.panelDiscount.TabIndex = 7;
            this.panelDiscount.Visible = false;
            // 
            // numUpDownDiscountProductCount
            // 
            this.numUpDownDiscountProductCount.Location = new System.Drawing.Point(258, 9);
            this.numUpDownDiscountProductCount.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numUpDownDiscountProductCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownDiscountProductCount.Name = "numUpDownDiscountProductCount";
            this.numUpDownDiscountProductCount.Size = new System.Drawing.Size(68, 20);
            this.numUpDownDiscountProductCount.TabIndex = 8;
            this.numUpDownDiscountProductCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(170, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 58);
            this.label2.TabIndex = 7;
            this.label2.Text = "Listenin Yüzde Kaçına İndirip uygulanacak ?";
            // 
            // uProductFilterCombo1
            // 
            this.uProductFilterCombo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uProductFilterCombo1.ExportHB = "";
            this.uProductFilterCombo1.ExportN11 = "";
            this.uProductFilterCombo1.Location = new System.Drawing.Point(12, 12);
            this.uProductFilterCombo1.Name = "uProductFilterCombo1";
            this.uProductFilterCombo1.PriceFilter = "";
            this.uProductFilterCombo1.PriceFilterType = "";
            this.uProductFilterCombo1.Size = new System.Drawing.Size(723, 159);
            this.uProductFilterCombo1.StokCodeList = ((System.Collections.Generic.List<string>)(resources.GetObject("uProductFilterCombo1.StokCodeList")));
            this.uProductFilterCombo1.TabIndex = 0;
            // 
            // FormSelectProductSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 339);
            this.Controls.Add(this.panelDiscount);
            this.Controls.Add(this.checkBoxAddDiscount);
            this.Controls.Add(this.checkBoxExportAll);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.uProductFilterCombo1);
            this.Name = "FormSelectProductSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Kaynağı";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMaxDiscount)).EndInit();
            this.panelDiscount.ResumeLayout(false);
            this.panelDiscount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDiscountProductCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.UProductFilterCombo uProductFilterCombo1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxExportAll;
        private System.Windows.Forms.CheckBox checkBoxAddDiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numUpDownMaxDiscount;
        private System.Windows.Forms.Panel panelDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUpDownDiscountProductCount;
    }
}