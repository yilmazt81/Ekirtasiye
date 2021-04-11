
namespace ETicaretWinApp
{
    partial class FormExportSingleCicekSepeti
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveExport = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.fLayoutPanelAttribute = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxWebPrice = new System.Windows.Forms.TextBox();
            this.textBoxMimPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.htmlTextboxDescription = new GvS.Controls.HtmlTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainerBrowser = new System.Windows.Forms.SplitContainer();
            this.webBrowserProduct = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonGetSelectedProduct = new System.Windows.Forms.Button();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBarkod = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MenuItemNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBrowser)).BeginInit();
            this.splitContainerBrowser.Panel2.SuspendLayout();
            this.splitContainerBrowser.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menüToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1065, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menüToolStripMenuItem
            // 
            this.menüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSaveExport,
            this.MenuItemNext});
            this.menüToolStripMenuItem.Name = "menüToolStripMenuItem";
            this.menüToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menüToolStripMenuItem.Text = "Menü";
            // 
            // MenuItemSaveExport
            // 
            this.MenuItemSaveExport.Name = "MenuItemSaveExport";
            this.MenuItemSaveExport.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.MenuItemSaveExport.Size = new System.Drawing.Size(180, 22);
            this.MenuItemSaveExport.Text = "Save - Export";
            this.MenuItemSaveExport.Click += new System.EventHandler(this.MenuItemSaveExport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainerLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainerBrowser);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1065, 541);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.fLayoutPanelAttribute);
            this.splitContainerLeft.Panel2.Controls.Add(this.panel2);
            this.splitContainerLeft.Size = new System.Drawing.Size(354, 541);
            this.splitContainerLeft.SplitterDistance = 147;
            this.splitContainerLeft.TabIndex = 0;
            // 
            // fLayoutPanelAttribute
            // 
            this.fLayoutPanelAttribute.AutoScroll = true;
            this.fLayoutPanelAttribute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLayoutPanelAttribute.Location = new System.Drawing.Point(0, 211);
            this.fLayoutPanelAttribute.Name = "fLayoutPanelAttribute";
            this.fLayoutPanelAttribute.Size = new System.Drawing.Size(354, 179);
            this.fLayoutPanelAttribute.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxWebPrice);
            this.panel2.Controls.Add(this.textBoxMimPrice);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.htmlTextboxDescription);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 211);
            this.panel2.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "İnternet Fiyatı";
            // 
            // textBoxWebPrice
            // 
            this.textBoxWebPrice.Location = new System.Drawing.Point(126, 168);
            this.textBoxWebPrice.Name = "textBoxWebPrice";
            this.textBoxWebPrice.Size = new System.Drawing.Size(80, 20);
            this.textBoxWebPrice.TabIndex = 31;
            // 
            // textBoxMimPrice
            // 
            this.textBoxMimPrice.Location = new System.Drawing.Point(126, 142);
            this.textBoxMimPrice.Name = "textBoxMimPrice";
            this.textBoxMimPrice.Size = new System.Drawing.Size(80, 20);
            this.textBoxMimPrice.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Mim Olması Gereken";
            // 
            // htmlTextboxDescription
            // 
            this.htmlTextboxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.htmlTextboxDescription.Location = new System.Drawing.Point(12, 19);
            this.htmlTextboxDescription.Name = "htmlTextboxDescription";
            this.htmlTextboxDescription.Padding = new System.Windows.Forms.Padding(1);
            this.htmlTextboxDescription.ShowHtmlSource = false;
            this.htmlTextboxDescription.Size = new System.Drawing.Size(326, 117);
            this.htmlTextboxDescription.TabIndex = 13;
            this.htmlTextboxDescription.ToolbarStyle = GvS.Controls.ToolbarStyles.AlwaysInternal;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Özellikleri";
            // 
            // splitContainerBrowser
            // 
            this.splitContainerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBrowser.Location = new System.Drawing.Point(0, 118);
            this.splitContainerBrowser.Name = "splitContainerBrowser";
            // 
            // splitContainerBrowser.Panel2
            // 
            this.splitContainerBrowser.Panel2.Controls.Add(this.webBrowserProduct);
            this.splitContainerBrowser.Size = new System.Drawing.Size(707, 423);
            this.splitContainerBrowser.SplitterDistance = 161;
            this.splitContainerBrowser.TabIndex = 1;
            // 
            // webBrowserProduct
            // 
            this.webBrowserProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserProduct.Location = new System.Drawing.Point(0, 0);
            this.webBrowserProduct.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserProduct.Name = "webBrowserProduct";
            this.webBrowserProduct.Size = new System.Drawing.Size(542, 423);
            this.webBrowserProduct.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonGetSelectedProduct);
            this.panel1.Controls.Add(this.textBoxProductName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxBarkod);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 118);
            this.panel1.TabIndex = 0;
            // 
            // buttonGetSelectedProduct
            // 
            this.buttonGetSelectedProduct.Image = global::ETicaretWinApp.Properties.Resources.Accept;
            this.buttonGetSelectedProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGetSelectedProduct.Location = new System.Drawing.Point(20, 79);
            this.buttonGetSelectedProduct.Name = "buttonGetSelectedProduct";
            this.buttonGetSelectedProduct.Size = new System.Drawing.Size(134, 23);
            this.buttonGetSelectedProduct.TabIndex = 39;
            this.buttonGetSelectedProduct.Text = "Seçilen Ürünü Al";
            this.buttonGetSelectedProduct.UseVisualStyleBackColor = true;
            this.buttonGetSelectedProduct.Click += new System.EventHandler(this.buttonGetSelectedProduct_Click);
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxProductName.Location = new System.Drawing.Point(61, 38);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(634, 29);
            this.textBoxProductName.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Adı";
            // 
            // textBoxBarkod
            // 
            this.textBoxBarkod.BackColor = System.Drawing.Color.White;
            this.textBoxBarkod.Location = new System.Drawing.Point(61, 12);
            this.textBoxBarkod.Name = "textBoxBarkod";
            this.textBoxBarkod.ReadOnly = true;
            this.textBoxBarkod.Size = new System.Drawing.Size(80, 20);
            this.textBoxBarkod.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Barkod";
            // 
            // MenuItemNext
            // 
            this.MenuItemNext.Name = "MenuItemNext";
            this.MenuItemNext.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.MenuItemNext.Size = new System.Drawing.Size(180, 22);
            this.MenuItemNext.Text = "Sonraki ";
            this.MenuItemNext.Click += new System.EventHandler(this.MenuItemNext_Click);
            // 
            // FormExportSingleCicekSepeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 565);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormExportSingleCicekSepeti";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormExportSingleCicekSepeti";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainerBrowser.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBrowser)).EndInit();
            this.splitContainerBrowser.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveExport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxBarkod;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private GvS.Controls.HtmlTextbox htmlTextboxDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMimPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxWebPrice;
        private System.Windows.Forms.SplitContainer splitContainerBrowser;
        private System.Windows.Forms.WebBrowser webBrowserProduct;
        private System.Windows.Forms.FlowLayoutPanel fLayoutPanelAttribute;
        private System.Windows.Forms.Button buttonGetSelectedProduct;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNext;
    }
}