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
using EKirtasiye.Model;
using ETicaretWinApp.Controls;
using static ETicaretWinApp.FormProductEdit;

namespace ETicaretWinApp
{
    public partial class FormExportSingleCicekSepeti : Form
    {
        IdeaCatalog ideaCatalog = null;
        Controls.UProductPictures uProductPictures = null;
        Controls.UShowCategoryView categoryView = null;
        public event SaveNextDocument OnSaveAndNextDocument = null;
        List<UCicekSepetiAttribute> uCicekSepetiAttributes = new List<UCicekSepetiAttribute>();
        List<CicekSepetiProductAttribute> cicekSepetiProductAttributes = new List<CicekSepetiProductAttribute>();
        string[] yasakKelimeler = null;
        public FormExportSingleCicekSepeti()
        {
            InitializeComponent();

            var text = File.ReadAllText(Path.Combine(Application.StartupPath, "CicekSepetiYasakliKelimeler.txt"), Encoding.UTF8);
            yasakKelimeler = text.Split(',');
            uProductPictures = new Controls.UProductPictures();
            splitContainerBrowser.Panel1.Controls.Add(uProductPictures);
            uProductPictures.Dock = DockStyle.Fill;

            categoryView = new Controls.UShowCategoryView();
            categoryView.ShowCheckBoxes = false;
            categoryView.OnSelectedChangeCategory += CategoryView_OnSelectedChangeCategory;
            splitContainerLeft.Panel1.Controls.Add(categoryView);
            categoryView.Dock = DockStyle.Fill;

            categoryView.LoadData(ApiHelper.GetCicekSepetiCategories());
        }

        private void CategoryView_OnSelectedChangeCategory(ProductCategory productCategory)
        {

            if (productCategory == null)
                return;
            var attributeList = ApiHelper.GetCicekSepetiCategorieAttributes(productCategory.Id);
            if (attributeList.Count == 0)
            {

                CicekSepetiHelper.SaveCicekSepetiAttribute(productCategory.Id);
                attributeList = ApiHelper.GetCicekSepetiCategorieAttributes(productCategory.Id);
            }
            uCicekSepetiAttributes.Clear();
            fLayoutPanelAttribute.Controls.Clear();
            foreach (var item in attributeList.Where(s => s.Attributename != "Dinamik Özellik"))
            {
                LoadAttribute(productCategory.Id, item);
            }
        }

        private void LoadAttribute(int _categoryId, CicekSepetiAttribute trendyolAttribute)
        {
            UCicekSepetiAttribute uTrendyol = new UCicekSepetiAttribute()
            {
                Attribute = trendyolAttribute
            };

            var productAttribute = cicekSepetiProductAttributes.FirstOrDefault(s => s.Attributeid == trendyolAttribute.Attributeid);
            if (productAttribute != null)
            {
                uTrendyol.AttributeValue = productAttribute.AttributeValue.ToString();
            }
            else
            {
                var attributedefaultValue = ApiHelper.GetCicekSepetiCategoryDefaultAttribute(_categoryId, trendyolAttribute.Id);
                if (attributedefaultValue != null)
                {
                    uTrendyol.AttributeValue = attributedefaultValue.AttributeValue.ToString();
                }else if (trendyolAttribute.Name == "Renk")
                {
                    var color = trendyolAttribute.AttributeValues.FirstOrDefault(s => s.AttributeText == "Çok Renkli");
                    if (color != null)
                    {
                        uTrendyol.AttributeValue = color.AttributeValue;
                    }
                }else if (trendyolAttribute.Name == "Marka")
                {
                    var marka = trendyolAttribute.AttributeValues.FirstOrDefault(s => s.AttributeText == ideaCatalog.Brand);
                    if (marka != null)
                    {
                        uTrendyol.AttributeValue = marka.AttributeValue;
                    }
                }
            }
           
            this.fLayoutPanelAttribute.Controls.Add(uTrendyol);
            uCicekSepetiAttributes.Add(uTrendyol);
        }

        public IdeaCatalog SelectedProduct {
            set {
                ideaCatalog = value;

                textBoxProductName.Text = HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Label);


                textBoxWebPrice.Text = ideaCatalog.WebPrice;
                textBoxMimPrice.Text = ideaCatalog.MimimumPrice;
                textBoxBarkod.Text = ideaCatalog.Barcode;


                uProductPictures.ClearImages();



                if (!string.IsNullOrEmpty(ideaCatalog.Picture1Path))
                {

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

                    webBrowserProduct.Navigate(pageUrl);
                }
                var cicekSepetiCategory = ideaCatalog.ProductAttributes.SingleOrDefault(s => s.AttributeName == "CicekSepetiCategory");

                cicekSepetiProductAttributes = ApiHelper.GetCicekSepetiProductAttribute(ideaCatalog.Id);
                if (cicekSepetiCategory != null)
                {
                    categoryView.SelectCategory(int.Parse(cicekSepetiCategory.AttributeValue));
                }

            }
            get {
                if (ideaCatalog == null)
                {
                    ideaCatalog = new IdeaCatalog();
                }
                ideaCatalog.Label = HelperXmlRead.ConvertHtmlCodesToTurkish(textBoxProductName.Text);


                ideaCatalog.Details = htmlTextboxDescription.Text;


                ideaCatalog.WebPrice = textBoxWebPrice.Text;


                return ideaCatalog;
            }
        }

        private void MenuItemSaveExport_Click(object sender, EventArgs e)
        {
            var textList = htmlTextboxDescription.PlainText;
            foreach (var yasak in yasakKelimeler)
            {
                if (textList.Contains(yasak))
                {
                    MessageBox.Show(yasak + " Kelimesi yasaklı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ideaCatalog.AddAttribute("CicekSepetiCategory", categoryView.SelectedCategory.Id.ToString());

            ApiHelper.InsertIdeaCatalog(SelectedProduct);
            List<CicekSepetiProductAttribute> lprodcutAttribute = new List<CicekSepetiProductAttribute>();

            foreach (var uCicekSepetiAttribute in uCicekSepetiAttributes)
            {
                lprodcutAttribute.Add(new CicekSepetiProductAttribute()
                {

                    ProductId = ideaCatalog.Id,
                    AttributeName = uCicekSepetiAttribute.Attribute.Name,
                    AttributeValue = int.Parse(uCicekSepetiAttribute.AttributeValue),
                    Attributeid = uCicekSepetiAttribute.Attribute.Attributeid,
                    AttributeCustomeValue = uCicekSepetiAttribute.AttributeValueText
                });
            }
            ApiHelper.SaveCicekSepetiProductAttribute(lprodcutAttribute);
            var export = CicekSepetiHelper.ExportProduct(ideaCatalog);
            if (export == "ok")
            {
                var apiReturn = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                {
                    Exported = true,
                    Id = ideaCatalog.Id,
                    ShopName = "CicekSepeti",
                    ShopPrice = textBoxWebPrice.Text
                });
                OnSaveAndNextDocument?.Invoke("CicekSepetiExport", ideaCatalog);
            }
            else
            {
                MessageBox.Show(export);
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
                    htmlTextboxDescription.Text = "<font size=\"5\">" + selectedProduct.Description + "</font>";
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

        private void MenuItemNext_Click(object sender, EventArgs e)
        {
            OnSaveAndNextDocument?.Invoke("CicekSepetiExport", ideaCatalog);
        }
    }
}
