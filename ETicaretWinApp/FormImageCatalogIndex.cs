using EKirtasiye.Controls;
using EKirtasiye.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public partial class FormImageCatalogIndex : Form
    {

        UImageEditor uImageEditor = null;
        List<CatalogImagePage> catalogImagePages = null;
        public FormImageCatalogIndex()
        {
            InitializeComponent();
            uImageEditor = new UImageEditor();
            splitContainerMain.Panel2.Controls.Add(uImageEditor);
            uImageEditor.Dock = DockStyle.Fill;
            string sourceFolder = Path.Combine(System.Configuration.ConfigurationManager.AppSettings["LocalWorkFolder"], "Tiff");
            var files = Directory.GetFiles(sourceFolder, "*.tif");
       
            catalogImagePages = files.Select(s => new CatalogImagePage()
            {
                FileName=Path.GetFileName(s),
                ImageFilePath=s
            }).ToList();

            gridControlFiles.DataSource = catalogImagePages;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            //e.FocusedRowHandle;
            var item = catalogImagePages[e.FocusedRowHandle];
            uImageEditor.LoadImage(item.ImageFilePath);
            textBoxPageText.Text = string.Empty;
            string txtFile = Path.ChangeExtension(item.ImageFilePath, ".txt");
            if (File.Exists(txtFile))
            {
                textBoxPageText.Text = File.ReadAllText(txtFile);
            }
        }
   

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            try
            {

                /*

                 var imagePaths = uImageEditor.SaveAnnotationItemsImages(sourceFolder);

                 IdeaCatalog ideaCatalog = new IdeaCatalog()
                 {
                     ProductSource = "Catalog"
                 };
                 int count = 1;
                 foreach (var targetFileName in imagePaths)
                 { 
                      if (count == 1)
                         ideaCatalog.Picture1Path = targetFileName;
                     else if (count==2)
                         ideaCatalog.Picture2Path = targetFileName;
                     else if (count == 3)
                         ideaCatalog.Picture3Path = targetFileName;
                     else if (count == 4)
                         ideaCatalog.Picture3Path = targetFileName;
                     count++;

                 }


                 FormProductEdit formProductEdit = new FormProductEdit();
                 formProductEdit.SelectedProduct = ideaCatalog;
                 formProductEdit.Show(); */
            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }

        }
    }
}
