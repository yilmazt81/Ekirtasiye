namespace ETicaretWinApp
{
    partial class FormImageCatalogIndex
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
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.gridControlFiles = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBoxPageText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.buttonNewProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerLeft);
            this.splitContainerMain.Size = new System.Drawing.Size(1692, 698);
            this.splitContainerMain.SplitterDistance = 469;
            this.splitContainerMain.TabIndex = 0;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.gridControlFiles);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.buttonNewProduct);
            this.splitContainerLeft.Panel2.Controls.Add(this.textBoxPageText);
            this.splitContainerLeft.Panel2.Controls.Add(this.label1);
            this.splitContainerLeft.Size = new System.Drawing.Size(469, 698);
            this.splitContainerLeft.SplitterDistance = 150;
            this.splitContainerLeft.TabIndex = 0;
            // 
            // gridControlFiles
            // 
            this.gridControlFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlFiles.Location = new System.Drawing.Point(0, 0);
            this.gridControlFiles.MainView = this.gridView1;
            this.gridControlFiles.Name = "gridControlFiles";
            this.gridControlFiles.Size = new System.Drawing.Size(469, 150);
            this.gridControlFiles.TabIndex = 0;
            this.gridControlFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControlFiles;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Dosya Adı";
            this.gridColumn1.FieldName = "FileName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ürün Sayı";
            this.gridColumn2.FieldName = "ProductCount";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // textBoxPageText
            // 
            this.textBoxPageText.Location = new System.Drawing.Point(10, 29);
            this.textBoxPageText.Multiline = true;
            this.textBoxPageText.Name = "textBoxPageText";
            this.textBoxPageText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxPageText.Size = new System.Drawing.Size(451, 97);
            this.textBoxPageText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sayfa Text";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1692, 24);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // buttonNewProduct
            // 
            this.buttonNewProduct.Location = new System.Drawing.Point(366, 143);
            this.buttonNewProduct.Name = "buttonNewProduct";
            this.buttonNewProduct.Size = new System.Drawing.Size(95, 23);
            this.buttonNewProduct.TabIndex = 2;
            this.buttonNewProduct.Text = "Yeni Ürün";
            this.buttonNewProduct.UseVisualStyleBackColor = true;
            this.buttonNewProduct.Click += new System.EventHandler(this.buttonNewProduct_Click);
            // 
            // FormImageCatalogIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 722);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormImageCatalogIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüntüden Ürün Ekleme";
            this.splitContainerMain.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            this.splitContainerLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private DevExpress.XtraGrid.GridControl gridControlFiles;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPageText;
        private System.Windows.Forms.Button buttonNewProduct;
    }
}