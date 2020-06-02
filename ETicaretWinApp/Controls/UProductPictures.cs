using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using System.Net;
using System.IO;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors;

namespace ETicaretWinApp.Controls
{
    public partial class UProductPictures : UserControl
    {
        GalleryControl galleryControl = new GalleryControl();
        GalleryItemGroup groupProduct = null;

        public delegate void SelectedImage(string imagePath);
        public event SelectedImage OnSelectedImage = null;
        // PictureEdit imageEdit = null;

        List<string> lPictures = new List<string>();
        List<string> lLocalPictures = new List<string>();
        public UProductPictures()
        {
            InitializeComponent();
            this.Controls.Add(galleryControl);
            galleryControl.Dock = DockStyle.Fill;
            galleryControl.Capture = true;

            galleryControl.Gallery.ItemCheckedChanged += Gallery_ItemCheckedChanged;

            for (int i = 1; i < 10; i++)
            {
                StripComboBoxSize.Items.Add(i * 50);
            }
            groupProduct = new GalleryItemGroup();

            galleryControl.Gallery.ImageSize = new Size(200, 200);
            galleryControl.Gallery.ShowItemText = true;
            galleryControl.Gallery.ItemImageLayout = ImageLayoutMode.Stretch;
            galleryControl.Gallery.Groups.Add(groupProduct);
            /*
            imageEdit = new PictureEdit();
            imageEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
         
             
            imageEdit.Dock = DockStyle.Fill;
            */
        }

        private void Gallery_ItemCheckedChanged(object sender, GalleryItemEventArgs e)
        {
            var imageOption = e.Item.ImageOptions;

        }

        int pictureCounter = 1;

        public void ClearImages()
        {
            pictureCounter = 1;
            groupProduct.Items.Clear();

        }
        public void AddPicture(int productId, string picturePath)
        {
            try
            {

                StripComboBoxSize.Text = ApplicationSettingHelper.ReadValue("ViewerForm", "ImageSize", "200");



                string tmpPath = Path.Combine(Application.StartupPath, $@"ImageTemp\{productId}_{Path.GetFileName(picturePath)}");
                Image im1 = null;
                if (picturePath.StartsWith("http"))
                {

                    if (!Directory.Exists(Path.GetDirectoryName(tmpPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(tmpPath));

                    if (!File.Exists(tmpPath))
                    {
                        using (WebClient webClient = new WebClient())
                        {
                            webClient.Headers.Add(HttpRequestHeader.UserAgent, "EKirtasiye");

                            webClient.DownloadFile(picturePath, tmpPath);

                        }
                    }
                    im1 = Image.FromFile(tmpPath);
                    lLocalPictures.Add(tmpPath);

                }
                else
                {
                    im1 = Image.FromFile(picturePath);
                    lLocalPictures.Add(picturePath);
                    tmpPath = picturePath;

                }

                var item = new GalleryItem(im1, $"Resim {pictureCounter}", $" Boyut = {im1.Size.Width} x {im1.Size.Height}");
                item.ItemClick += İtem_ItemClick;
                item.Tag = tmpPath;
                groupProduct.Items.Add(item);
                pictureCounter++;
                lPictures.Add(picturePath);
                //  imageEdit.Image = im1;
            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }
        }

        private void İtem_ItemClick(object sender, GalleryItemClickEventArgs e)
        {

            var item = e.Item;
            if (OnSelectedImage != null)
                OnSelectedImage(e.Item.Tag.ToString());
            //imageEdit.Image = e.Item.ImageOptions.Image;

        }

        public string[] ProductPictures {

            get {
                return lPictures.ToArray();
            }
        }

        public string[] ProductPicturesLocal {

            get {
                return lLocalPictures.ToArray();
            }
        }
        private void StripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int size = int.Parse(StripComboBoxSize.Text);
            galleryControl.Gallery.ImageSize = new Size(size, size);
            ApplicationSettingHelper.AddValue("ViewerForm", "ImageSize", size.ToString());

        }

        public int ImageSize {
            set {
                galleryControl.Gallery.ImageSize = new Size(value, value);
            }
        }
    }
}
