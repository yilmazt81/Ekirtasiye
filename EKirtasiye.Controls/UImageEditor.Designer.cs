namespace EKirtasiye.Controls
{
    partial class UImageEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UImageEditor));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.StripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.StripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.StripSplitButtonPrivateZoom = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuItemZoomWith = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemZoomHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.StripButtonRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.StripButtonRotateDown = new System.Windows.Forms.ToolStripButton();
            this.StripButtonRotateRight = new System.Windows.Forms.ToolStripButton();
            this.StripButtonCutImage = new System.Windows.Forms.ToolStripButton();
            this.StripDropButtonDrawAnnotate = new System.Windows.Forms.ToolStripDropDownButton();
            this.ToolStripMenuItemRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemText = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAnnotationPicture = new System.Windows.Forms.ToolStripMenuItem();
            this.StripButtonHand = new System.Windows.Forms.ToolStripButton();
            this.StripButtonClearAnnotation = new System.Windows.Forms.ToolStripButton();
            this.cMenuStripView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemAnnotationProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemTakeFront = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMoveBack = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDeleteAnnotation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain.SuspendLayout();
            this.cMenuStripView.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripButtonZoomIn,
            this.StripButtonZoomOut,
            this.StripSplitButtonPrivateZoom,
            this.StripButtonRotateLeft,
            this.StripButtonRotateDown,
            this.StripButtonRotateRight,
            this.StripButtonCutImage,
            this.StripDropButtonDrawAnnotate,
            this.StripButtonHand,
            this.StripButtonClearAnnotation});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1289, 25);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // StripButtonZoomIn
            // 
            this.StripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonZoomIn.Image")));
            this.StripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonZoomIn.Name = "StripButtonZoomIn";
            this.StripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
            this.StripButtonZoomIn.Text = "Yakınlaştır";
            this.StripButtonZoomIn.Click += new System.EventHandler(this.StripButtonZoomIn_Click);
            // 
            // StripButtonZoomOut
            // 
            this.StripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonZoomOut.Image")));
            this.StripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonZoomOut.Name = "StripButtonZoomOut";
            this.StripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
            this.StripButtonZoomOut.Text = "Uzaklaştır";
            this.StripButtonZoomOut.Click += new System.EventHandler(this.StripButtonZoomOut_Click);
            // 
            // StripSplitButtonPrivateZoom
            // 
            this.StripSplitButtonPrivateZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripSplitButtonPrivateZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemZoomWith,
            this.MenuItemZoomHeight});
            this.StripSplitButtonPrivateZoom.Image = ((System.Drawing.Image)(resources.GetObject("StripSplitButtonPrivateZoom.Image")));
            this.StripSplitButtonPrivateZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripSplitButtonPrivateZoom.Name = "StripSplitButtonPrivateZoom";
            this.StripSplitButtonPrivateZoom.Size = new System.Drawing.Size(32, 22);
            this.StripSplitButtonPrivateZoom.Text = "Tam Sığdır";
            this.StripSplitButtonPrivateZoom.ButtonClick += new System.EventHandler(this.StripSplitButtonPrivateZoom_ButtonClick);
            // 
            // MenuItemZoomWith
            // 
            this.MenuItemZoomWith.Name = "MenuItemZoomWith";
            this.MenuItemZoomWith.Size = new System.Drawing.Size(154, 22);
            this.MenuItemZoomWith.Text = "Sayfa Genişlik";
            this.MenuItemZoomWith.Click += new System.EventHandler(this.MenuItemZoomWith_Click);
            // 
            // MenuItemZoomHeight
            // 
            this.MenuItemZoomHeight.Name = "MenuItemZoomHeight";
            this.MenuItemZoomHeight.Size = new System.Drawing.Size(154, 22);
            this.MenuItemZoomHeight.Text = "Sayfa Yükseklik";
            this.MenuItemZoomHeight.Click += new System.EventHandler(this.MenuItemZoomHeight_Click);
            // 
            // StripButtonRotateLeft
            // 
            this.StripButtonRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonRotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonRotateLeft.Image")));
            this.StripButtonRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonRotateLeft.Name = "StripButtonRotateLeft";
            this.StripButtonRotateLeft.Size = new System.Drawing.Size(23, 22);
            this.StripButtonRotateLeft.Text = "Sola Döndür";
            this.StripButtonRotateLeft.Click += new System.EventHandler(this.StripButtonRotateLeft_Click);
            // 
            // StripButtonRotateDown
            // 
            this.StripButtonRotateDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonRotateDown.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonRotateDown.Image")));
            this.StripButtonRotateDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonRotateDown.Name = "StripButtonRotateDown";
            this.StripButtonRotateDown.Size = new System.Drawing.Size(23, 22);
            this.StripButtonRotateDown.Text = "Ters Döndür";
            this.StripButtonRotateDown.Click += new System.EventHandler(this.StripButtonRotateDown_Click);
            // 
            // StripButtonRotateRight
            // 
            this.StripButtonRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonRotateRight.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonRotateRight.Image")));
            this.StripButtonRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonRotateRight.Name = "StripButtonRotateRight";
            this.StripButtonRotateRight.Size = new System.Drawing.Size(23, 22);
            this.StripButtonRotateRight.Text = "Sağa Döndür";
            this.StripButtonRotateRight.Click += new System.EventHandler(this.StripButtonRotateRight_Click);
            // 
            // StripButtonCutImage
            // 
            this.StripButtonCutImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonCutImage.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonCutImage.Image")));
            this.StripButtonCutImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonCutImage.Name = "StripButtonCutImage";
            this.StripButtonCutImage.Size = new System.Drawing.Size(23, 22);
            this.StripButtonCutImage.Text = "Kes";
            this.StripButtonCutImage.Click += new System.EventHandler(this.StripButtonCutImage_Click);
            // 
            // StripDropButtonDrawAnnotate
            // 
            this.StripDropButtonDrawAnnotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripDropButtonDrawAnnotate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemRectangle,
            this.ToolStripMenuItemEllipse,
            this.MenuItemText,
            this.MenuItemAnnotationPicture});
            this.StripDropButtonDrawAnnotate.Image = ((System.Drawing.Image)(resources.GetObject("StripDropButtonDrawAnnotate.Image")));
            this.StripDropButtonDrawAnnotate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripDropButtonDrawAnnotate.Name = "StripDropButtonDrawAnnotate";
            this.StripDropButtonDrawAnnotate.Size = new System.Drawing.Size(29, 22);
            this.StripDropButtonDrawAnnotate.Text = "Çizim";
            this.StripDropButtonDrawAnnotate.Click += new System.EventHandler(this.StripDropButtonDrawAnnotate_Click);
            // 
            // ToolStripMenuItemRectangle
            // 
            this.ToolStripMenuItemRectangle.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemRectangle.Image")));
            this.ToolStripMenuItemRectangle.Name = "ToolStripMenuItemRectangle";
            this.ToolStripMenuItemRectangle.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItemRectangle.Text = "Çerçeve";
            this.ToolStripMenuItemRectangle.Click += new System.EventHandler(this.ToolStripMenuItemRectangle_Click);
            // 
            // ToolStripMenuItemEllipse
            // 
            this.ToolStripMenuItemEllipse.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItemEllipse.Image")));
            this.ToolStripMenuItemEllipse.Name = "ToolStripMenuItemEllipse";
            this.ToolStripMenuItemEllipse.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItemEllipse.Text = "Daire";
            this.ToolStripMenuItemEllipse.Click += new System.EventHandler(this.ToolStripMenuItemCircle_Click);
            // 
            // MenuItemText
            // 
            this.MenuItemText.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemText.Image")));
            this.MenuItemText.Name = "MenuItemText";
            this.MenuItemText.Size = new System.Drawing.Size(116, 22);
            this.MenuItemText.Text = "Yazi";
            this.MenuItemText.Click += new System.EventHandler(this.MenuItemText_Click);
            // 
            // MenuItemAnnotationPicture
            // 
            this.MenuItemAnnotationPicture.Image = ((System.Drawing.Image)(resources.GetObject("MenuItemAnnotationPicture.Image")));
            this.MenuItemAnnotationPicture.Name = "MenuItemAnnotationPicture";
            this.MenuItemAnnotationPicture.Size = new System.Drawing.Size(116, 22);
            this.MenuItemAnnotationPicture.Text = "Resim";
            this.MenuItemAnnotationPicture.Click += new System.EventHandler(this.MenuItemAnnotationPicture_Click);
            // 
            // StripButtonHand
            // 
            this.StripButtonHand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonHand.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonHand.Image")));
            this.StripButtonHand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonHand.Name = "StripButtonHand";
            this.StripButtonHand.Size = new System.Drawing.Size(23, 22);
            this.StripButtonHand.Text = "toolStripButton1";
            this.StripButtonHand.Click += new System.EventHandler(this.StripButtonHand_Click);
            // 
            // StripButtonClearAnnotation
            // 
            this.StripButtonClearAnnotation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StripButtonClearAnnotation.Image = ((System.Drawing.Image)(resources.GetObject("StripButtonClearAnnotation.Image")));
            this.StripButtonClearAnnotation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StripButtonClearAnnotation.Name = "StripButtonClearAnnotation";
            this.StripButtonClearAnnotation.Size = new System.Drawing.Size(23, 22);
            this.StripButtonClearAnnotation.Text = "Temizle";
            this.StripButtonClearAnnotation.Click += new System.EventHandler(this.StripButtonClearAnnotation_Click);
            // 
            // cMenuStripView
            // 
            this.cMenuStripView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAnnotationProperty,
            this.MenuItemTakeFront,
            this.MenuItemMoveBack,
            this.MenuItemDeleteAnnotation});
            this.cMenuStripView.Name = "cMenuStripView";
            this.cMenuStripView.Size = new System.Drawing.Size(181, 114);
            // 
            // MenuItemAnnotationProperty
            // 
            this.MenuItemAnnotationProperty.Name = "MenuItemAnnotationProperty";
            this.MenuItemAnnotationProperty.Size = new System.Drawing.Size(180, 22);
            this.MenuItemAnnotationProperty.Text = "Özellikler";
            this.MenuItemAnnotationProperty.Click += new System.EventHandler(this.MenuItemAnnotationProperty_Click);
            // 
            // MenuItemTakeFront
            // 
            this.MenuItemTakeFront.Name = "MenuItemTakeFront";
            this.MenuItemTakeFront.Size = new System.Drawing.Size(180, 22);
            this.MenuItemTakeFront.Text = "Öne Al";
            this.MenuItemTakeFront.Click += new System.EventHandler(this.MenuItemTakeFront_Click);
            // 
            // MenuItemMoveBack
            // 
            this.MenuItemMoveBack.Name = "MenuItemMoveBack";
            this.MenuItemMoveBack.Size = new System.Drawing.Size(180, 22);
            this.MenuItemMoveBack.Text = "Geriye Al";
            this.MenuItemMoveBack.Click += new System.EventHandler(this.MenuItemMoveBack_Click);
            // 
            // MenuItemDeleteAnnotation
            // 
            this.MenuItemDeleteAnnotation.Name = "MenuItemDeleteAnnotation";
            this.MenuItemDeleteAnnotation.Size = new System.Drawing.Size(180, 22);
            this.MenuItemDeleteAnnotation.Text = "Sil";
            this.MenuItemDeleteAnnotation.Click += new System.EventHandler(this.MenuItemDeleteAnnotation_Click);
            // 
            // UImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripMain);
            this.Name = "UImageEditor";
            this.Size = new System.Drawing.Size(1289, 667);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.cMenuStripView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton StripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton StripButtonZoomOut;
        private System.Windows.Forms.ToolStripSplitButton StripSplitButtonPrivateZoom;
        private System.Windows.Forms.ToolStripMenuItem MenuItemZoomWith;
        private System.Windows.Forms.ToolStripMenuItem MenuItemZoomHeight;
        private System.Windows.Forms.ToolStripButton StripButtonRotateLeft;
        private System.Windows.Forms.ToolStripButton StripButtonRotateDown;
        private System.Windows.Forms.ToolStripButton StripButtonRotateRight;
        private System.Windows.Forms.ToolStripButton StripButtonCutImage;
        private System.Windows.Forms.ToolStripDropDownButton StripDropButtonDrawAnnotate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRectangle;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemEllipse;
        private System.Windows.Forms.ToolStripButton StripButtonHand;
        private System.Windows.Forms.ToolStripButton StripButtonClearAnnotation;
        private System.Windows.Forms.ContextMenuStrip cMenuStripView;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAnnotationProperty;
        private System.Windows.Forms.ToolStripMenuItem MenuItemText;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAnnotationPicture;
        private System.Windows.Forms.ToolStripMenuItem MenuItemTakeFront;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMoveBack;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDeleteAnnotation;
    }
}
