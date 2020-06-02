using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atalasoft.Imaging.WinControls;
using Atalasoft.Imaging.ImageProcessing.Transforms;
using Atalasoft.Annotate.UI;
using Atalasoft.Annotate;
using System.IO;
using Atalasoft.Imaging;

namespace EKirtasiye.Controls
{
    public partial class UImageEditor : UserControl
    {

        AnnotateViewer imageViewer = null;
        //AnnotationController annotationController = null;
        private AnnotationDefaults _defaultAnnotations = new AnnotationDefaults();
        private ViewerHelper.MouseMission mouseMission = ViewerHelper.MouseMission.None;
        private string templateFile = string.Empty;
        public UImageEditor()
        {
            InitializeComponent();

            imageViewer = new AnnotateViewer();
            imageViewer.Annotations.SelectionChanged += Annotations_SelectionChanged;
            //  imageViewer.ContextMenu = this.cMenuStripView;
            //  annotationController = new AnnotationController();
            this.Controls.Add(imageViewer);
            imageViewer.Dock = DockStyle.Fill;
        }

        public void SaveAnnotation(string sourceFilePath)
        {
            imageViewer.Annotations.Save(sourceFilePath, AnnotationDataFormat.Xmp);
            templateFile = sourceFilePath;

        }

        public string TemplateFilePath {
            get {
                return templateFile;
            }

        }
        public void LoadSaveAnnotation(string sourceFilePath)
        {
            templateFile = sourceFilePath;

            imageViewer.Annotations.Load(sourceFilePath, AnnotationDataFormat.Xmp);
            foreach (LayerAnnotation oneLayer in imageViewer.Annotations.Layers)
            {
                foreach (AnnotationUI item in oneLayer.Items)
                {
                    item.ContextMenuStrip = cMenuStripView;
                }
            }
        }

        private void Annotations_SelectionChanged(object sender, EventArgs e)
        {
            imageViewer.MouseTool = MouseToolType.None;
        }

        public string ImagePath { get; set; }

        public void LoadImage(string imageFilePath)
        {
            imageViewer.Annotations.Layers.Clear();

            ImagePath = imageFilePath;
            imageViewer.Image = new Atalasoft.Imaging.AtalaImage(imageFilePath);
            imageViewer.Centered = true;
        }

        private void StripButtonZoomIn_Click(object sender, EventArgs e)
        {
            ViewerHelper.Zoom(imageViewer, ViewerHelper.ZoomType.In);

        }

        public void Zoom(ViewerHelper.ZoomType zoomType)
        {
            ViewerHelper.Zoom(imageViewer, zoomType);
        }


        private void StripButtonZoomOut_Click(object sender, EventArgs e)
        {
            ViewerHelper.Zoom(imageViewer, ViewerHelper.ZoomType.Out);

        }

        private void Rotate(int rotateAngle)
        {
            RotateCommand rotateCommand = new RotateCommand(rotateAngle, Atalasoft.Imaging.ImageProcessing.InterpolationMode.BiCubic, Color.White);
            var imageResult = rotateCommand.Apply(imageViewer.Image);
            imageViewer.Image = imageResult.Image;
        }

        private void StripButtonZoomFit_Click(object sender, EventArgs e)
        {

            ViewerHelper.Zoom(imageViewer, ViewerHelper.ZoomType.FitToWidth);

        }

        private void StripSplitButtonPrivateZoom_ButtonClick(object sender, EventArgs e)
        {
            ViewerHelper.Zoom(imageViewer, ViewerHelper.ZoomType.BestFit);
        }

        private void MenuItemZoomWith_Click(object sender, EventArgs e)
        {
            ViewerHelper.Zoom(imageViewer, ViewerHelper.ZoomType.FitToWidth);
        }

        private void MenuItemZoomHeight_Click(object sender, EventArgs e)
        {
            ViewerHelper.Zoom(imageViewer, ViewerHelper.ZoomType.FitToHeight);
        }

        private void StripButtonRotateDown_Click(object sender, EventArgs e)
        {
            Rotate(180);
        }

        private void StripButtonRotateLeft_Click(object sender, EventArgs e)
        {
            Rotate(270);
        }

        private void StripButtonRotateRight_Click(object sender, EventArgs e)
        {
            Rotate(90);
        }
        private void StripButtonCutImage_Click(object sender, EventArgs e)
        {
            StripButtonCutImage.Checked = !StripButtonCutImage.Checked;
            mouseMission = StripButtonCutImage.Checked ? ViewerHelper.MouseMission.Cut : ViewerHelper.MouseMission.None;
            //annotationController.Cut();
            imageViewer.MouseTool = MouseToolType.None;
            imageViewer.Annotations.InteractMode = AnnotateInteractMode.Author;
            //imageViewer.Selection.Visible = StripButtonCutImage.Checked;

        }

        private void ToolStripMenuItemRectangle_Click(object sender, EventArgs e)
        {
            CreateAnnotation(AnnotationType.Rectangle);

        }

        private void CreateAnnotation(AnnotationType annotationType)
        {
            imageViewer.MouseTool = MouseToolType.None;
            var anno = _defaultAnnotations.GetAnnotation(annotationType);
            anno.ContextMenuStrip = this.cMenuStripView;
            this.imageViewer.Annotations.CreateAnnotation(anno);
        }

        private void ToolStripMenuItemCircle_Click(object sender, EventArgs e)
        {

            CreateAnnotation(AnnotationType.Ellipse);

        }

        public AnnotationItem[] AnnotationItems {
            get {

                List<AnnotationItem> annotationItems = new List<AnnotationItem>();

                foreach (LayerAnnotation oneLayer in imageViewer.Annotations.Layers)
                {
                    foreach (AnnotationUI item in oneLayer.Items)
                    {
                        AnnotationItem annotationItem = new AnnotationItem()
                        {
                            Name = item.Name,
                            Rectangle = item.Bounds
                        };
                        annotationItems.Add(annotationItem);
                    }
                }
                return annotationItems.ToArray();
            }
        }

        private AnnotationUI[] AnnotationObject {
            get {
                List<AnnotationUI> annotationItems = new List<AnnotationUI>();

                foreach (LayerAnnotation oneLayer in imageViewer.Annotations.Layers)
                {
                    foreach (AnnotationUI item in oneLayer.Items)
                    {

                        annotationItems.Add(item);
                    }
                }

                return annotationItems.ToArray();
            }
        }

        public string[] SaveAnnotationItemsImages(string[] productImages)
        {

            List<string> imagePaths = new List<string>();
            Atalasoft.Imaging.Codec.ImageEncoder imageEncoder = new Atalasoft.Imaging.Codec.JpegEncoder()
            {
                Quality = 100,
                Smoothing = 70,
            };
            AtalaImage burnedImg = imageViewer.Image.Clone() as AtalaImage;

            List<string> lReturnFiles = new List<string>();
            foreach (var oneImage in productImages)
            {
                string targetFileName = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N") + ".jpg");
                foreach (AnnotationUI item in AnnotationObject)
                {
                    var imageSize = item.Size;
                    var location = item.Location;
                    if (item is EmbeddedImageAnnotation)
                    {
                        if (item.Name == "@ProductImage")
                        {
                            var embedImage = (EmbeddedImageAnnotation)item;
                            embedImage.Image = new Atalasoft.Annotate.AnnotationImage(oneImage);
                            break;
                        }
                    }

                }
                imageViewer.Burn(burnedImg);
                //graphicsA.Save();
                //atalaImage.Save(targetFileName);
                burnedImg.Save(targetFileName, imageEncoder, null);
                lReturnFiles.Add(targetFileName);
            }


            return lReturnFiles.ToArray();


        }
        private void StripButtonHand_Click(object sender, EventArgs e)
        {
            StripButtonHand.Checked = !StripButtonHand.Checked;
            imageViewer.MouseTool = MouseToolType.Pan;
            imageViewer.PanCursor = Cursors.Hand;

        }

        private void StripDropButtonDrawAnnotate_Click(object sender, EventArgs e)
        {

        }

        private void StripButtonClearAnnotation_Click(object sender, EventArgs e)
        {
            imageViewer.Annotations.Layers.Clear();
        }

        private void MenuItemAnnotationProperty_Click(object sender, EventArgs e)
        {
            try
            {
                if (imageViewer.Annotations.SelectedAnnotations.Length == 0)
                    return;
                var selectedAnnotation = imageViewer.Annotations.SelectedAnnotations[0];
                FormProperty formProperty = new FormProperty();
                formProperty.SelectedObject = (AnnotationUI)selectedAnnotation;
                if (formProperty.ShowDialog() == DialogResult.OK)
                {
                    selectedAnnotation = (AnnotationUI)formProperty.SelectedObject;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void MenuItemText_Click(object sender, EventArgs e)
        {
            CreateAnnotation(AnnotationType.Text);
        }

        private string _productImage = string.Empty;
        public string ProductImage {

            set {
                _productImage = value;
            }
        }

        public void SetAnnotationValue(string controlName, string value)
        {
            var items = AnnotationObject;
            var searchAnnotation = items.FirstOrDefault(s => s.Name == controlName);
            if (searchAnnotation != null)
            {
                if (searchAnnotation is TextAnnotation)
                {
                    var textControl = (TextAnnotation)searchAnnotation;
                    textControl.Text = value;
                }
                if (searchAnnotation is EmbeddedImageAnnotation)
                {
                    var imageEm = (EmbeddedImageAnnotation)searchAnnotation;
                    imageEm.Image = new Atalasoft.Annotate.AnnotationImage(value);
                    //imageEm.Size = new SizeF(imageEm.Image.Width, imageEm.Image.Height);
                }
            }
        }
      
        private void MenuItemAnnotationPicture_Click(object sender, EventArgs e)
        {
            //CreateAnnotation(AnnotationType.EmbeddedImage);
            Atalasoft.Annotate.UI.EmbeddedImageAnnotation ann = _defaultAnnotations.GetAnnotation(AnnotationType.EmbeddedImage) as Atalasoft.Annotate.UI.EmbeddedImageAnnotation;

            ann.ContextMenuStrip = this.cMenuStripView;
            if (!string.IsNullOrEmpty(_productImage) && (!AnnotationObject.Any(s => s.Name == "@ProductImage")))
            {
                ann.Image = new Atalasoft.Annotate.AnnotationImage(_productImage);
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Png Files|*.png|Image Files|*.jpg";
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                ann.Image = new Atalasoft.Annotate.AnnotationImage(openFileDialog.FileName);
            }
            ann.Size = new SizeF(ann.Image.Width, ann.Image.Height);
            this.imageViewer.Annotations.CreateAnnotation(ann);
        }

        private void MenuItemTakeFront_Click(object sender, EventArgs e)
        {
            if (imageViewer.Annotations.SelectedAnnotations.Length == 0)
                return;
            var selectedAnnotation = imageViewer.Annotations.SelectedAnnotations[0];
            selectedAnnotation.Controller.ChangeAnnotationPosition(ChangePositionMethod.MoveToFront);


        }

        private void MenuItemMoveBack_Click(object sender, EventArgs e)
        {
            if (imageViewer.Annotations.SelectedAnnotations.Length == 0)
                return;
            var selectedAnnotation = imageViewer.Annotations.SelectedAnnotations[0];
            selectedAnnotation.Controller.ChangeAnnotationPosition(ChangePositionMethod.MoveToBack);

        }

        private void MenuItemDeleteAnnotation_Click(object sender, EventArgs e)
        {
            if (imageViewer.Annotations.SelectedAnnotations.Length == 0)
                return;
            var selectedAnnotation = imageViewer.Annotations.SelectedAnnotations[0];
            selectedAnnotation.Remove();
        }
    }
}
