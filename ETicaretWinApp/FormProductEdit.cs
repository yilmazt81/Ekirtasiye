
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ETicaretWinApp
{
    public partial class FormProductEdit : Form
    {
        Controls.UProductPictures uProductPictures = null;
        List<ProductCategory> productCategory = ApiHelper.GetAllProductCategories();
        IdeaCatalog ideaCatalog = null;
        private string _localDownloadPicture = string.Empty;
        public delegate void SaveNextDocument(IdeaCatalog ideaCatalog);
        public event SaveNextDocument OnSaveAndNextDocument = null;
        public FormProductEdit()
        {
            InitializeComponent();
            ApiHelper.GetAllProductCategories();

            uCategoryViewProduct.RefreshMainGroup();
            uProductPictures = new Controls.UProductPictures();
            panelGalery.Controls.Add(uProductPictures);
            uProductPictures.Dock = DockStyle.Fill;
            var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
                Key.SetValue(appName, 99999, RegistryValueKind.DWord);
            textBoxStokCode.ReadOnly = false;
            textBoxProductSource.ReadOnly = false;
            checkBoxStatus.Checked = true;
            comboBoxBrand.DataSource = ApiHelper.GetProductBrands();

        }


        public IdeaCatalog SelectedProduct {
            set {
                ideaCatalog = value;

                textBoxDiscount.Text = (ideaCatalog.RebatePercent == 0 ? string.Empty : ideaCatalog.RebatePercent.ToString());
                textBoxProductName.Text = HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Label);

                textBoxPrice.Text = ideaCatalog.Price1;
                uCategoryViewProduct.MainCategory = (ideaCatalog.MainCategoryId != 0 ? productCategory.FirstOrDefault(s => s.Id == ideaCatalog.MainCategoryId) : null);
                uCategoryViewProduct.Category = (ideaCatalog.CategoryId != 0 ? productCategory.FirstOrDefault(s => s.Id == ideaCatalog.CategoryId) : null);
                uCategoryViewProduct.SubCategory = (ideaCatalog.SubCategoryId != 0 ? productCategory.FirstOrDefault(s => s.Id == ideaCatalog.SubCategoryId) : null);

                textBoxProductSource.Text = ideaCatalog.ProductSource;
                textBoxStokCode.Text = ideaCatalog.StockCode;
                textBoxWebPrice.Text = ideaCatalog.WebPrice;
                textBoxMimPrice.Text = ideaCatalog.MimimumPrice;
                textBoxMarketPrice.Text = ideaCatalog.MarketPrice;
                checkBoxStatus.Checked = ideaCatalog.Status;
                textBoxBarkod.Text = ideaCatalog.Barcode;

                comboBoxBrand.Text = HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Brand);


                bool findByService = false;
                uProductPictures.ClearImages();



                if (!string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                {
                    if (ideaCatalog.Picture1Path.Contains("turkyilmazozkan"))
                    {
                        findByService = true;
                    }
                    uProductPictures.AddPicture(ideaCatalog.Id, ideaCatalog.Picture1Path);
                }
                else
                {
                    ideaCatalog.Picture1Path = "";

                }

                if (!string.IsNullOrEmpty(ideaCatalog.Picture2Path))
                {
                    uProductPictures.AddPicture(ideaCatalog.Id, ideaCatalog.Picture2Path);
                }
                else
                {
                    ideaCatalog.Picture2Path = "";

                }
                if (!string.IsNullOrEmpty(ideaCatalog.Picture3Path))
                {
                    uProductPictures.AddPicture(ideaCatalog.Id, ideaCatalog.Picture3Path);
                }
                else
                {
                    ideaCatalog.Picture3Path = "";
                }
                if (!string.IsNullOrEmpty(ideaCatalog.Picture4Path))
                {
                    uProductPictures.AddPicture(ideaCatalog.Id, ideaCatalog.Picture4Path);
                }
                else
                {
                    ideaCatalog.Picture4Path = "";
                }
                htmlTextboxDescription.Text = ideaCatalog.Details;
                if (!string.IsNullOrEmpty(ideaCatalog.Label))
                {
                    string searchParam = HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Label).Replace("%", "yüzde").Replace("&", "%26");
                    if (!string.IsNullOrEmpty(ideaCatalog.Barcode))
                    {
                        searchParam = ideaCatalog.Barcode;
                    }
                    string pageUrl = $@"https://www.google.com/search?q={ searchParam }&tbm=shop";
                    textBoxGoogleUrl.Text = pageUrl;
                    webBrowserProduct.Navigate(textBoxGoogleUrl.Text);
                }


                labelPictureSource.ForeColor = (findByService ? Color.Green : Color.GreenYellow);
                labelPictureSource.Text = (!findByService ? "Resim Kaynağı : Distribütör" : "Resim Kaynağı : Otomatik");

            }
            get {
                if (ideaCatalog == null)
                {
                    ideaCatalog = new IdeaCatalog();
                }
                ideaCatalog.StockCode = textBoxStokCode.Text;
                ideaCatalog.Label = HelperXmlRead.ConvertHtmlCodesToTurkish(textBoxProductName.Text);
                ideaCatalog.RebatePercent = (string.IsNullOrEmpty(textBoxDiscount.Text) ? 0 : int.Parse(textBoxDiscount.Text));
                ideaCatalog.Price1 = textBoxPrice.Text;
                ideaCatalog.MainCategoryId = uCategoryViewProduct.MainCategory.Id;
                ideaCatalog.Web_MainCategory = uCategoryViewProduct.MainCategory.CategoryName;
                ideaCatalog.Status = checkBoxStatus.Checked;

                ideaCatalog.CategoryId = uCategoryViewProduct.Category.Id;
                ideaCatalog.Web_Category = uCategoryViewProduct.Category.CategoryName;
                ideaCatalog.SubCategoryId = uCategoryViewProduct.SubCategory.Id;
                ideaCatalog.Web_SubCategory = uCategoryViewProduct.SubCategory.CategoryName;
                ideaCatalog.ProductSource = textBoxProductSource.Text;
                ideaCatalog.MarketPrice = textBoxMarketPrice.Text;

                ideaCatalog.Details = htmlTextboxDescription.Text;
                ideaCatalog.Brand = HelperXmlRead.ConvertHtmlCodesToTurkish(comboBoxBrand.Text);

                ideaCatalog.WebPrice = textBoxWebPrice.Text;
                if (string.IsNullOrEmpty(ideaCatalog.Picture1Path) && !string.IsNullOrEmpty(_localDownloadPicture))
                {
                    ideaCatalog.Picture1Path = GoogleSearchHtmlExtractor.UploadImage(_localDownloadPicture);
                }

                _localDownloadPicture = string.Empty;
                if (!string.IsNullOrEmpty(_localDownloadPicture))
                {
                    File.Delete(_localDownloadPicture);
                }

                return ideaCatalog;
            }
        }

        private void FormProductEdit_Load(object sender, EventArgs e)
        {

        }

        private void Save()
        {

            var selectedProduct = SelectedProduct;

            selectedProduct.LastEdited = "";
            selectedProduct.LastEditedDate = DateTime.Now;
            selectedProduct.WebExportStatus = "Update";
            if (!ApiHelper.InsertIdeaCatalog(selectedProduct))
            {
                MessageBox.Show("Ürün Kaydedilemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }



        private void MenuItemSaveNext_Click(object sender, EventArgs e)
        {
            Save();

            if (OnSaveAndNextDocument != null)
                OnSaveAndNextDocument(SelectedProduct);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            webBrowserProduct.GoBack();
        }

        private void MenuItemSaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            DialogResult = DialogResult.OK;
        }

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void webBrowserProduct_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (ideaCatalog == null)
                {
                    ideaCatalog = new IdeaCatalog();
                    ideaCatalog.Title = textBoxProductName.Text;
                }
                if (webBrowserProduct.Document.Body == null)
                    return;
                var productLinks = GoogleSearchHtmlExtractor.GetProductLinks(webBrowserProduct.Document.Body.InnerHtml, ideaCatalog.Title).OrderBy(s => s.PageOrder).ToArray();
                //gridControlWebSource.DataSource = productLinks;

            }
            catch (Exception ex)
            {
                //FormMain.ShowException(ex);
            }
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void textBoxProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string pageUrl = $@"https://www.google.com/search?q={ HelperXmlRead.ConvertHtmlCodesToTurkish(textBoxProductName.Text).Replace("%", "yüzde").Replace("&", "%26") }&tbm=shop";
                textBoxGoogleUrl.Text = pageUrl;
                webBrowserProduct.Navigate(textBoxGoogleUrl.Text);
            }
        }
        /*
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {

                if (gridControlWebSource.DataSource == null)
                    return;
                var selected = gridView1.GetSelectedRows().FirstOrDefault();
                var selectedRow = gridView1.GetRow(selected);

                var webProduct = (WebPageProduct)selectedRow;
                textBoxWebPrice.Text = webProduct.ProductPrice.Replace("₺", "");
                if (string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                {
                    string extention = "";
                    var imageFile = GoogleSearchHtmlExtractor.SaveImage(webProduct.ImageBase64, ref extention);
                    _localDownloadPicture = imageFile;
                    uProductPictures.AddPicture(ideaCatalog.Id, imageFile);
                }

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }*/
        private void ClickDescriptionMoreClick()
        {
            foreach (System.Windows.Forms.HtmlElement html in webBrowserProduct.Document.GetElementsByTagName("a"))
            {
                var attrib = html.GetAttribute("jsaction");
                if (attrib.ToString() == "spop.td")
                {
                    html.InvokeMember("click");
                    // findDocumentOpenLink = true;
                    //var strUpdate = webBrowserProduct.Document.Body.InnerHtml;
                    Application.DoEvents();

                    break;

                    // return;
                }
            }
        }
        private void buttonGetSelectedProduct_Click(object sender, EventArgs e)
        {
            if (webBrowserProduct.Document.Body == null)
                return;
            try
            {
                // ClickDescriptionMoreClick();

                var selectedProduct = GoogleSearchHtmlExtractor.GetSelectedProduct(webBrowserProduct.Document.Body.InnerHtml);
                if (selectedProduct.ProductImages == null)
                    return;

                ideaCatalog.Picture1Path = "";
                ideaCatalog.Picture2Path = "";
                ideaCatalog.Picture3Path = "";
                ideaCatalog.Picture4Path = "";

                if (!string.IsNullOrEmpty(selectedProduct.Description))
                {
                    htmlTextboxDescription.Text = selectedProduct.Description;
                }
                
                textBoxWebPrice.Text = selectedProduct.ProductPrice;
                uProductPictures.ClearImages();
                int counter = 1;
                foreach (var oneImage in selectedProduct.ProductImages.Take(4))
                {

                    var imageFile = GoogleSearchHtmlExtractor.SaveAndUploadImage(oneImage.ImageData);
                    imageFile = "http://turkyilmazozkan.xyz/webImage/" + imageFile;
                    uProductPictures.AddPicture(ideaCatalog.Id, imageFile);
                    if (counter == 1)
                        ideaCatalog.Picture1Path = imageFile;
                    if (counter == 2)
                        ideaCatalog.Picture2Path = imageFile;
                    if (counter == 3)
                        ideaCatalog.Picture3Path = imageFile;
                    if (counter == 4)
                        ideaCatalog.Picture4Path = imageFile;

                    counter++;

                }
            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }

        private async void MenuItemShareInstagram_Click(object sender, EventArgs e)
        {

            var ideC = SelectedProduct;

            FormShareIntegramView formShareIntegramView = new FormShareIntegramView(ideC);
            formShareIntegramView.Show();
        }

        private void MenuItemExportN11_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItemSave_Click(sender, e);
                var returnMessage = N11Helper.ExportProduct(ideaCatalog);
                if (returnMessage != "ok")
                {
                    MessageBox.Show(returnMessage, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }
                


                if (OnSaveAndNextDocument != null)
                    OnSaveAndNextDocument(SelectedProduct);

            }
            catch (Exception ex)
            {

                FormMain.ShowException(ex);
            }
        }
    }
}
