namespace ETicaretWinApp
{
    partial class FormImportPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImportPreview));
            this.gridControlImport = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cMenuStripGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonStartImport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlImport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.cMenuStripGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlImport
            // 
            this.gridControlImport.ContextMenuStrip = this.cMenuStripGrid;
            this.gridControlImport.Location = new System.Drawing.Point(12, 31);
            this.gridControlImport.MainView = this.gridView1;
            this.gridControlImport.Name = "gridControlImport";
            this.gridControlImport.Size = new System.Drawing.Size(1148, 332);
            this.gridControlImport.TabIndex = 0;
            this.gridControlImport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlImport;
            this.gridView1.Name = "gridView1";
            // 
            // cMenuStripGrid
            // 
            this.cMenuStripGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExportExcel});
            this.cMenuStripGrid.Name = "cMenuStripGrid";
            this.cMenuStripGrid.Size = new System.Drawing.Size(137, 26);
            // 
            // MenuItemExportExcel
            // 
            this.MenuItemExportExcel.Name = "MenuItemExportExcel";
            this.MenuItemExportExcel.Size = new System.Drawing.Size(136, 22);
            this.MenuItemExportExcel.Text = "Excel Export";
            this.MenuItemExportExcel.Click += new System.EventHandler(this.MenuItemExportExcel_Click);
            // 
            // buttonStartImport
            // 
            this.buttonStartImport.Image = ((System.Drawing.Image)(resources.GetObject("buttonStartImport.Image")));
            this.buttonStartImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonStartImport.Location = new System.Drawing.Point(956, 372);
            this.buttonStartImport.Name = "buttonStartImport";
            this.buttonStartImport.Size = new System.Drawing.Size(177, 40);
            this.buttonStartImport.TabIndex = 2;
            this.buttonStartImport.Text = "Import A Başla";
            this.buttonStartImport.UseVisualStyleBackColor = true;
            this.buttonStartImport.Click += new System.EventHandler(this.buttonStartImport_Click);
            // 
            // FormImportPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 426);
            this.Controls.Add(this.buttonStartImport);
            this.Controls.Add(this.gridControlImport);
            this.Name = "FormImportPreview";
            this.Text = "FormImportPreview";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlImport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.cMenuStripGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlImport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ContextMenuStrip cMenuStripGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExportExcel;
        private System.Windows.Forms.Button buttonStartImport;
    }
}