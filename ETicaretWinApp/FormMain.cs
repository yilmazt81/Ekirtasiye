
using DevExpress.Export.Xl;
using EKirtasiye.Helper;
using EKirtasiye.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EKirtasiye.N11;
using ExcelDataReader;

namespace ETicaretWinApp
{
    public partial class FormMain : Form
    {
        List<IdeaCatalog> lSearchCatalogList = new List<IdeaCatalog>();
        FormProductEdit productEdit = null;
        FormExportSingleCicekSepeti formExportSingleCicekSepeti = null;
        private string _localWorkFolder = string.Empty;
        public FormMain()
        {
            InitializeComponent();
            /*
            EKirtasiye.N11.ProductHelper productHelper = new EKirtasiye.N11.ProductHelper();

            var lines = File.ReadLines(@"C:\Users\turkyilmaz.ozkan\Desktop\deleteList.txt");
            foreach (var item in lines)
            {
                if (!productHelper.DeleteProductBySellerCode(item))
                {
                    System.Diagnostics.Trace.WriteLine(item);
                }

            }

            */
            /*
            EKirtasiye.HepsiBurada.ApiHelper apiHelper = new EKirtasiye.HepsiBurada.ApiHelper("02879e22-0a4d-49be-8c54-6fca8c2ec8e3", "Kk12345!", "kirtasiyekurdu_dev", "https://mpop-sit.hepsiburada.com");

            var ss = apiHelper.Authenticate();
            var categoriesList = apiHelper.GetAllCategories(pageSize: 5);

            for (int i = 0; i < categoriesList.totalPages; i++)
            {
                var tempList = apiHelper.GetAllCategories(pageSize: 5, page: i);
                foreach (var oneCategory in tempList.data)
                {
                    var saveReturn = ApiHelper.SaveHepsiBuradaCategory(new HepsiBuradaCategory()
                    {
                        Available = oneCategory.available,
                        CategoryId = oneCategory.categoryId,
                        Leaf = oneCategory.leaf,
                        Name = oneCategory.name,
                        ParentCategoryId = oneCategory.parentCategoryId,
                        Status = oneCategory.status
                    });
                }
            }
            */
            // apiHelper.GetCategoriAttributeValues(fff.categoryId, attributes.data.attributes.FirstOrDefault().id);

            _localWorkFolder = System.Configuration.ConfigurationManager.AppSettings["LocalWorkFolder"];

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {

                uCategoryView1.RefreshMainGroup();

            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

        }



        private void comboBoxSubSubGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public static void ShowException(Exception ex)
        {
            MessageBox.Show($"Hata Mesajı : {ex.Message} \n Hata Trace : {ex.StackTrace} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void MenuItemMuhasebeImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Muhasebe programının xml çıktılarının klasörünü seçiniz.";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string urunGroupXmlPath = Path.Combine(folderBrowserDialog.SelectedPath, "StkGrup.Xml");
                string urunFiyatXmlPath = Path.Combine(folderBrowserDialog.SelectedPath, "StkSFiyat.Xml");
                string urunStokXmlPath = Path.Combine(folderBrowserDialog.SelectedPath, "Stok.Xml");
                string urunBarkodXmlPath = Path.Combine(folderBrowserDialog.SelectedPath, "StkBarkod.Xml");

                if (!File.Exists(urunGroupXmlPath))
                {
                    MessageBox.Show("StkGrup.Xml Dosyası bulunamadı eksik export", "Bilgi", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(urunFiyatXmlPath))
                {
                    MessageBox.Show("StkSFiyat.Xml Dosyası bulunamadı eksik export", "Bilgi", MessageBoxButtons.OK);
                    return;
                }
                if (!File.Exists(urunStokXmlPath))
                {
                    MessageBox.Show("Stok.Xml Dosyası bulunamadı eksik export", "Bilgi", MessageBoxButtons.OK);
                    return;
                }
                try
                {
                    //var groups = HelperXmlRead.ProductCategories(urunGroupXmlPath);
                    var muhasebeData = HelperXmlRead.GetMuhasebeDataStoks(urunStokXmlPath, urunFiyatXmlPath, urunBarkodXmlPath);

                    FormImportPreview formImportPreview = new FormImportPreview(muhasebeData);
                    formImportPreview.Show();

                }
                catch (Exception ex)
                {
                    ShowException(ex);
                }
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                  
                 */

                DocumentFilterRequest documentFilterRequest = uProductFilterCombo1.DocumentFilterRequest;


                documentFilterRequest.CategoryId = uCategoryView1.Category.Id;
                documentFilterRequest.MainCategoryId = uCategoryView1.MainCategory.Id;
                documentFilterRequest.SubCategoryId = uCategoryView1.SubCategory.Id;
                documentFilterRequest.StokCode = textBoxStokCode.Text;


                var catalog = ApiHelper.FilterCatalog(documentFilterRequest);
                lSearchCatalogList = catalog;
                gridControlProduct.DataSource = catalog;

                toolStripStatusLabelRecordCount.Text = $"Kayıt Sayısı : {catalog.Count}";
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenıItemExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel Dosyası|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                gridControlProduct.ExportToXlsx(saveFileDialog.FileName, new DevExpress.XtraPrinting.XlsxExportOptions()
                {
                    ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile,
                    ShowGridLines = true,
                    TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text,

                });
            }
        }


        private void MenuItemUpdateGroup_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            var ideaCatalog = e.Row as IdeaCatalog;
            if (ideaCatalog is null)
                return;
            try
            {
                if (ideaCatalog.WebExportStatus == "Hazir")
                {
                    ideaCatalog.WebExportStatus = "Update";
                }
                ApiHelper.InsertIdeaCatalog(ideaCatalog);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

        }

        private void MenuItemUpdateMainC_Click(object sender, EventArgs e)
        {

            try
            {
                List<IdeaCatalog> ideaCatalogs = (List<IdeaCatalog>)gridControlProduct.DataSource;
                /*for (int i = 0; i < gridView1.row; i++)
                {
                    int row = (gridView1.GetSelectedRows()[i]);
                    var obj = gridView1.GetRow(row) as IdeaCatalog;
                    ideaCatalogs.Add(obj);

                }
                */
                var distinctCategoryList = ideaCatalogs.Where(s => s.MainCategoryId == 0 && !string.IsNullOrEmpty(s.MainCategory)).Select(s => s.MainCategory).Distinct().OrderBy(s => s).ToArray();
                FormUpdateProductGroup formUpdateProductGroup = new FormUpdateProductGroup(distinctCategoryList, "MainCategory");
                formUpdateProductGroup.Show();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemSub_Click(object sender, EventArgs e)
        {

            try
            {
                List<IdeaCatalog> ideaCatalogs = (List<IdeaCatalog>)gridControlProduct.DataSource;
                /*for (int i = 0; i < gridView1.row; i++)
                {
                    int row = (gridView1.GetSelectedRows()[i]);
                    var obj = gridView1.GetRow(row) as IdeaCatalog;
                    ideaCatalogs.Add(obj);

                }
                */
                var distinctCategoryList = ideaCatalogs.Where(s => s.SubCategoryId == 0 && !string.IsNullOrEmpty(s.SubCategory)).Select(s => s.SubCategory).Distinct().Take(100).OrderBy(s => s).ToArray();
                FormUpdateProductGroup formUpdateProductGroup = new FormUpdateProductGroup(distinctCategoryList, "SubCategory");
                formUpdateProductGroup.Show();

            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemSubSubU_Click(object sender, EventArgs e)
        {
            try
            {
                List<IdeaCatalog> ideaCatalogs = (List<IdeaCatalog>)gridControlProduct.DataSource;
                /*for (int i = 0; i < gridView1.row; i++)
                {
                    int row = (gridView1.GetSelectedRows()[i]);
                    var obj = gridView1.GetRow(row) as IdeaCatalog;
                    ideaCatalogs.Add(obj);

                }
                */
                var distinctCategoryList = ideaCatalogs.Where(s => s.CategoryId == 0 && !string.IsNullOrEmpty(s.Category)).Select(s => s.Category).Distinct().Take(100).ToArray();
                FormUpdateProductGroup formUpdateProductGroup = new FormUpdateProductGroup(distinctCategoryList, "Category");
                formUpdateProductGroup.Show();

            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemUpdateSelected_Click(object sender, EventArgs e)
        {
            try
            {

                List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    int row = (gridView1.GetSelectedRows()[i]);
                    var obj = gridView1.GetRow(row) as IdeaCatalog;
                    ideaCatalogs.Add(obj);

                }

                FormEditSelectedProductGroup formEditSelectedProductGroup = new FormEditSelectedProductGroup(ideaCatalogs);
                formEditSelectedProductGroup.ShowDialog();
                gridControlProduct.RefreshDataSource();
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemGetInfoFromWeb_Click(object sender, EventArgs e)
        {
            try
            {
                FormSelectProductSource formSelectProductSource = new FormSelectProductSource();
                if (formSelectProductSource.ShowDialog() == DialogResult.Cancel)
                    return;




                var catalog = ApiHelper.FilterCatalog(formSelectProductSource.FilterRequest);

                FormProductWebBrowser formProductWebBrowser = new FormProductWebBrowser(catalog);
                formProductWebBrowser.Show();


            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemProductProperty_Click(object sender, EventArgs e)
        {
            IdeaCatalog ideaCatalog = null;
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                var obj = gridView1.GetRow(row) as IdeaCatalog;
                ideaCatalog = obj;
                break;

            }

            if (ideaCatalog != null)
            {
                productEdit = new FormProductEdit();
                productEdit.SelectedProduct = ideaCatalog;
                productEdit.OnSaveAndNextDocument += ProductEdit_OnSaveAndNextDocument;
                productEdit.ShowDialog();
            }
        }

        private void ProductEdit_OnSaveAndNextDocument(string formName, IdeaCatalog ideaCatalog)
        {
            try
            {
                var saveIndex = lSearchCatalogList.IndexOf(ideaCatalog);
                lSearchCatalogList[saveIndex] = ideaCatalog;
                var nextCatalog = lSearchCatalogList[saveIndex + 1];
                if (formName == "EditForm")
                {

                    productEdit.SelectedProduct = nextCatalog;
                }
                else if (formName == "CicekSepetiExport")
                {
                    formExportSingleCicekSepeti.SelectedProduct = nextCatalog;
                }
                gridControlProduct.RefreshDataSource();
            }
            catch (Exception ex)
            {
                // ShowException(ex);
            }

        }

        private void MenuItemKadiogluImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("KadiOglu Xml'i import etmek istediğinizden emin misiniz ? \n Bu işlem uzun sürebilir.", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Xml File|*.xml";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var muhasebeData = HelperXmlRead.ReadKadioglu(openFileDialog.FileName);

                    FormImportPreview formImportPreview = new FormImportPreview(muhasebeData);
                    formImportPreview.Show();
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }
        private void CreateCellWithValue(IXlRow xlRow, XlCellFormatting xlCellFormatting, string value)
        {

            using (var cell = xlRow.CreateCell())
            {

                cell.ApplyFormatting(xlCellFormatting);
                cell.Value = value;
            }

        }

        private void MenuItemImportCeren_Click(object sender, EventArgs e)
        {
            FormCerenImport frFormCerenImport = new FormCerenImport("Ceren");

            frFormCerenImport.Show();
        }

        private void CreateUpdateExport()
        {
            var exportTargets = ApiHelper.GetIdeaExportTargets();

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK)
                return;

            foreach (var exportTarget in exportTargets)
            {
                var updateExport = ApiHelper.GetUpdatedExportCatalog(exportTarget.Id);
                if (updateExport.Length == 0)
                    continue;
                var updateList = new UpdateProductStatusRequest()
                {
                    ProductIdList = new List<IdeaCatalog>(),
                    WebStatus = "Export Edildi"
                };

                if (exportTarget.ExcelExport)
                {
                    var files = Directory.GetFiles(folderBrowserDialog.SelectedPath, exportTarget.Name + "*.xls");
                    string saveFileName = Path.Combine(folderBrowserDialog.SelectedPath, exportTarget.Name + "_" + (files.Length + 1) + ".xls");


                    CreateIdeaExcelFile(updateExport, exportTarget.Id, saveFileName, updateList);

                    UpdateExportList(updateList, exportTarget);
                }
                else if (exportTarget.Name == "N11")
                {
                    if (bool.Parse(ApplicationSettingHelper.ReadValue("N11", "UseN11", "false")))
                    {
                        //N11 web servise gidecek
                        UpdateN11Product(updateExport, exportTarget.Id, updateList);

                        UpdateExportList(updateList, exportTarget);
                    }
                }
                else if (exportTarget.Name == "Trendyol")
                {
                    if (bool.Parse(ApplicationSettingHelper.ReadValue("Trendyol", "UseTrend", "false")))
                    {

                        UpdateTrendYolProduct(updateExport, exportTarget.Id, updateList);
                        UpdateExportList(updateList, exportTarget);
                    }
                }
                else if (exportTarget.Name == "CicekSepeti")
                {
                    if (bool.Parse(ApplicationSettingHelper.ReadValue("CicekSepeti", "UseCicekSepeti", "false")))
                    {
                        UpdateCicekSepetiProduct(updateExport, exportTarget.Id, updateList);
                        UpdateExportList(updateList, exportTarget);
                    }
                }
            } 

        }

        private void CheckBatchStatusList()
        {
            var cicekSepetiCreateRequest = ApiHelper.CicekSepetiGetCreateRequestList();

            foreach (var cicekSepeti in cicekSepetiCreateRequest.Where(s => string.IsNullOrEmpty(s.RequestStatus) || s.RequestStatus == "Processing" ||s.RequestStatus== "Pending"))
            {
                try
                {
                    var batchReturn = CicekSepetiHelper.GetBatchState(cicekSepeti.BatchRequest);
                    if (batchReturn.items[0].status == "Failed")
                    {
                        if (cicekSepeti.RequestType == "Create")
                        {
                            var apiReturn = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                            {
                                Exported = false,
                                Id = cicekSepeti.ProductId,
                                ShopName = "CicekSepeti",
                                ShopPrice = ""
                            });
                        }
                    }

                    cicekSepeti.RequestStatus = batchReturn.items[0].status;
                    cicekSepeti.ErrorMessages = "";
                    foreach (var failurereason in batchReturn.items[0].failureReasons)
                    {
                        cicekSepeti.ErrorMessages += failurereason.message + "\n";
                    }
                    ApiHelper.SaveCicekSepetiCreateRequest(cicekSepeti);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }

            }

        }
        private void UpdateExportList(UpdateProductStatusRequest updateList, IdeaExportTarget exportTarget)
        {
            foreach (var ideaCatalog in updateList.ProductIdList)
            {
                ApiHelper.SaveLastProductExportProperty(new LastProductExportProperty()
                {
                    ProductId = ideaCatalog.Id,
                    IdeaExportTargetId = exportTarget.Id,
                    ProductPrice = ideaCatalog.MarketPrice,
                    PicturePath1 = ideaCatalog.Picture1Path,
                    PicturePath2 = ideaCatalog.Picture2Path,
                    PicturePath3 = ideaCatalog.Picture3Path,
                    PicturePath4 = ideaCatalog.Picture4Path,
                    ProductState = ideaCatalog.Status
                });
            }

        }

        private void UpdateTrendYolProduct(IdeaCatalog[] ideaCatalogs, int exportTargetId, UpdateProductStatusRequest updateProductStatus)
        {
            var disableProducts = ideaCatalogs.Where(s => !s.Status && (s.ApprovalStatusTrendYol == 0 || s.ApprovalStatusTrendYol == 1)).ToArray();
            var requestBatchId = TrendyolHelper.CloseProductAccepted(disableProducts);

            foreach (var ideaCatalog in disableProducts)
            {
                updateProductStatus.ProductIdList.Add(ideaCatalog);
            }

            var enableProducts = ideaCatalogs.Where(s => s.Status).ToArray();

            var openRequestBatch = TrendyolHelper.OpenProductAccepted(enableProducts);


            foreach (var ideaCatalog in enableProducts)
            {
                updateProductStatus.ProductIdList.Add(ideaCatalog);
            }
        }

        private void UpdateCicekSepetiProduct(IdeaCatalog[] ideaCatalogs, int exportTargetId, UpdateProductStatusRequest updateProductStatus)
        {

            var batchReturn = CicekSepetiHelper.UpdateProducStockAndPrice(ideaCatalogs.ToList());
            foreach (var ideaCatalog in ideaCatalogs)
            {
                ApiHelper.SaveCicekSepetiCreateRequest(new CicekSepetiCreateRequest()
                {
                    BatchRequest = batchReturn,
                    ProductId = ideaCatalog.Id,
                    RequestType = "Update"
                });
                updateProductStatus.ProductIdList.Add(ideaCatalog);

            }

        }
        private void UpdateN11Product(IdeaCatalog[] ideaCatalogs, int exportTargetId, UpdateProductStatusRequest updateProductStatus)
        {
            var _apiKey = ApplicationSettingHelper.ReadValue("N11", "N11AppKey");
            var _secretKey = ApplicationSettingHelper.ReadValue("N11", "N11SecretKey");
            var productHelper = new ProductSaleService(_apiKey, _secretKey);
            var productHelperPrice = new ProductHelper(_apiKey, _secretKey);
            string idList = "";
            foreach (var product in ideaCatalogs)
            {
                if (!product.ExportN11)
                    continue;

                System.Threading.Thread.Sleep(new TimeSpan(0, 0, 2));
                if (!product.Status)
                {
                    if (product.ApprovalStatus == "1")
                    {
                        var disableStatus = productHelper.DisableProduct(product.N11ProductId);
                        if (disableStatus)
                        {
                            updateProductStatus.ProductIdList.Add(product);
                        }
                        else
                        {
                            disableStatus = productHelper.DisableProduct(product.StockCode);
                            if (disableStatus)
                            {
                                updateProductStatus.ProductIdList.Add(product);
                            }
                            else
                            {
                                idList += product.N11ProductId.ToString() + ",";

                                System.Diagnostics.Trace.WriteLine("ddd");
                            }
                        }
                    }
                    else
                    {
                        updateProductStatus.ProductIdList.Add(product);
                    }
                }
                else
                {
                    float price = float.Parse(product.MimimumPrice) * (float)1.15;
                    /*if (price > 150)
                    {
                        price = price + 20;
                    }*/
                    var updatePrice = productHelperPrice.UpdateProductPrice(product.N11ProductId, (decimal)price, product.CurrencyAbbr);
                    if (updatePrice)
                    {
                        updateProductStatus.ProductIdList.Add(product);
                    }
                    else
                    {
                        idList += product.N11ProductId.ToString() + ",";

                        System.Diagnostics.Trace.WriteLine("ddd");
                    }
                }
            }
            System.Diagnostics.Trace.WriteLine(idList);
        }
        private void CreateIdeaExcelFile(IdeaCatalog[] ideaCatalogs, int exportTargetId, string saveFileName, UpdateProductStatusRequest updateProductStatus)
        {
            IXlExporter exporter = XlExport.CreateExporter(XlDocumentFormat.Xls);

            var allCategory = ApiHelper.GetAllProductCategories();


            var columnHeaders = new string[] { "stockCode","label", "status","brand","brandDistCode","barcode",
                    "mainCategory", "mainCategoryDistCode","category","categoryDistCode",
                    "subCategory","subCategoryDistCode","rootProductStockCode","buyingPrice",
                    "price1","price2","price3","price4","price5","tax","currencyAbbr","stockAmount","stockType",
                    "warranty","picture1Path","picture2Path" ,"picture3Path","picture4Path","dm3","details","rebate","rebateType",
                    "variantName1","variantValue1","variantName2","variantValue2","variantName3","variantValue3","variantName4",
                    "variantValue4","variantName5","variantValue5"};

            using (FileStream stream = new FileStream(saveFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {

                XlCellFormatting cellFormatting = new XlCellFormatting();
                cellFormatting.Font = new XlFont();
                cellFormatting.Font.Name = "Century Gothic";
                cellFormatting.Font.SchemeStyle = XlFontSchemeStyles.None;

                XlCellFormatting headerRowFormatting = new XlCellFormatting();
                headerRowFormatting.CopyFrom(cellFormatting);
                headerRowFormatting.Font.Bold = true;
                headerRowFormatting.Font.Color = XlColor.FromTheme(XlThemeColor.Light1, 0.0);
                headerRowFormatting.Fill = XlFill.SolidFill(XlColor.FromTheme(XlThemeColor.Accent2, 0.0));


                using (IXlDocument document = exporter.CreateDocument(stream))
                {

                    using (IXlSheet sheet = document.CreateSheet())
                    {
                        sheet.Name = "Worksheet";
                        for (int i = 0; i < columnHeaders.Length; i++)
                        {
                            using (IXlColumn column = sheet.CreateColumn())
                            {
                                column.WidthInPixels = 200;

                            }
                        }

                        using (IXlRow row = sheet.CreateRow())
                        {
                            foreach (var oneHeader in columnHeaders)
                            {
                                using (IXlCell cell = row.CreateCell())
                                {
                                    cell.Value = oneHeader;
                                    cell.ApplyFormatting(headerRowFormatting);
                                }
                            }
                        }

                        foreach (var ideaCatalog in ideaCatalogs)
                        {

                            using (IXlRow row = sheet.CreateRow())
                            {

                                CreateCellWithValue(row, cellFormatting, ideaCatalog.StockCode);
                                CreateCellWithValue(row, cellFormatting, HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Label));
                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.Status ? "1" : "0"));
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Brand);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Brand);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Barcode);
                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.MainCategoryId == 0 ? string.Empty : allCategory.SingleOrDefault(s => s.Id == ideaCatalog.MainCategoryId).CategoryName));
                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.MainCategoryId == 0 ? "" : ideaCatalog.MainCategoryId.ToString()));

                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.CategoryId == 0 ? string.Empty : allCategory.SingleOrDefault(s => s.Id == ideaCatalog.CategoryId).CategoryName));
                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.CategoryId == 0 ? "" : ideaCatalog.CategoryId.ToString()));

                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.SubCategoryId == 0 ? string.Empty : allCategory.SingleOrDefault(s => s.Id == ideaCatalog.SubCategoryId).CategoryName));
                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.SubCategoryId == 0 ? "" : ideaCatalog.SubCategoryId.ToString()));

                                CreateCellWithValue(row, cellFormatting, ideaCatalog.RootProductStockCode);
                                if (exportTargetId == 1)
                                {

                                    CreateCellWithValue(row, cellFormatting, ideaCatalog.MarketPrice);
                                    CreateCellWithValue(row, cellFormatting, ideaCatalog.MimimumPrice);
                                }
                                else
                                {

                                    CreateCellWithValue(row, cellFormatting, ideaCatalog.MimimumSellerPrice);
                                    CreateCellWithValue(row, cellFormatting, "");
                                }
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Price2);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Price3);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Price4);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Price5);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Tax);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.CurrencyAbbr);

                                CreateCellWithValue(row, cellFormatting, ideaCatalog.StockAmount.ToString());
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.StockType);
                                CreateCellWithValue(row, cellFormatting, (string.IsNullOrEmpty(ideaCatalog.Warrant) ? "24" : ideaCatalog.Warrant));

                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Picture1Path);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Picture2Path);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Picture3Path);
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.Picture4Path);
                                CreateCellWithValue(row, cellFormatting, (ideaCatalog.Dm3 == 0 ? "5" : ideaCatalog.Dm3.ToString()));
                                CreateCellWithValue(row, cellFormatting, HelperXmlRead.ConvertHtmlCodesToTurkish(ideaCatalog.Details));
                                CreateCellWithValue(row, cellFormatting, ideaCatalog.RebatePercent.ToString());
                            }


                            updateProductStatus.ProductIdList.Add(ideaCatalog);

                        }
                    }
                }
            }

        }

        private void MenuItemIdeaExport_Click(object sender, EventArgs e)
        {


            try
            {
                FormSelectProductSource formSelectProductSource = new FormSelectProductSource();
                if (formSelectProductSource.ShowDialog() == DialogResult.Cancel)
                    return;



                var catalog = ApiHelper.FilterCatalog(formSelectProductSource.FilterRequest);

                if (catalog.Count == 0)
                {
                    MessageBox.Show("Export edilecek kayit bulunamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();
                if (!formSelectProductSource.WorkAllRecord)
                {
                    ideaCatalogs = catalog.Where(s => !string.IsNullOrEmpty(s.Picture1Path) && s.MainCategoryId > 0).ToList();
                }
                else
                {
                    ideaCatalogs = catalog;
                }



                //FileInfo fileInfo = new FileInfo(Path.Combine(Application.StartupPath, "STANDART_KATALOG.xltx"));
                //string sourceFile = Path.Combine(Application.StartupPath, "STANDART_KATALOG.xltx");
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "xls File|*.xls";
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                string saveFileName = saveFileDialog.FileName;
                var updateList = new UpdateProductStatusRequest()
                {
                    ProductIdList = new List<IdeaCatalog>(),
                    WebStatus = "Export Edildi"
                };
                var updatePriceListCheck = new UpdateProductStatusRequest()
                {
                    ProductIdList = new List<IdeaCatalog>(),
                    WebStatus = "Fiyat Kontrol"
                };

                //

                CreateIdeaExcelFile(ideaCatalogs.ToArray(), formSelectProductSource.ExportTarget.Id, saveFileName, updateList);

                //

                foreach (var ideaCatalog in updateList.ProductIdList)
                {
                    var updateDB = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                    {
                        Exported = true,
                        Id = ideaCatalog.Id,
                        ShopName = "Idea",
                        ShopPrice = ""
                    });

                }

                UpdateExportList(updateList, formSelectProductSource.ExportTarget);

                /*
                ApiHelper.UpdateProductWebExportState(updatePriceListCheck);

                if (!ApiHelper.UpdateProductWebExportState(updateList))
                {
                    MessageBox.Show("Idea Excel Dokümü Sırasında hata oluştu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Veriler Export Edildi {updateList.ProductIdList.Count} Adet Ürün ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                */
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemNewProduct_Click(object sender, EventArgs e)
        {
            FormProductEdit formProductEdit = new FormProductEdit();
            formProductEdit.ShowDialog();
        }

        private void MenuItemImportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PDF Dosyası|*.pdf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string targetFolder = Path.Combine(_localWorkFolder, "PDFExtract");
                    string targetTifFolder = Path.Combine(_localWorkFolder, "Tiff");

                    PDFHelper.ExtractPages(openFileDialog.FileName, targetFolder);

                    var pdfFiles = Directory.GetFiles(targetFolder, "*.pdf");
                    if (!Directory.Exists(targetTifFolder))
                        Directory.CreateDirectory(targetTifFolder);

                    foreach (var onePDFfile in pdfFiles)
                    {
                        string tiffFile = PDFHelper.ConverPDFToTif(onePDFfile);
                        string pdfText = PDFHelper.GetTextFromAllPages(onePDFfile);
                        string targetFile = Path.Combine(targetTifFolder, Path.GetFileNameWithoutExtension(onePDFfile) + Path.GetExtension(tiffFile));
                        string targettxtFile = Path.Combine(targetTifFolder, Path.GetFileNameWithoutExtension(onePDFfile) + ".txt");
                        File.WriteAllLines(targettxtFile, pdfText.Split('\n'));
                        File.Copy(tiffFile, targetFile, true);
                        File.Delete(tiffFile);
                        File.Delete(onePDFfile);
                    }
                    MessageBox.Show("Convert işlemi bitti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemIndexCatalog_Click(object sender, EventArgs e)
        {
            try
            {
                FormImageCatalogIndex formImageCatalogIndex = new FormImageCatalogIndex();
                formImageCatalogIndex.Show();

            }
            catch (Exception ex)
            {

                ShowException(ex);
            }
        }

        private void MenuItemShareInstagram_Click(object sender, EventArgs e)
        {
            IdeaCatalog ideaCatalog = null;
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                var obj = gridView1.GetRow(row) as IdeaCatalog;
                ideaCatalog = obj;
                break;

            }

            if (ideaCatalog != null)
            {
                FormShareIntegramView formShareIntegramView = new FormShareIntegramView(ideaCatalog);
                formShareIntegramView.Show();
            }

        }

        private void MenuItemHepsiBurada_Click(object sender, EventArgs e)
        {
            try
            {
                EKirtasiye.HepsiBurada.CatalogProductApiHelper apiHelper = new EKirtasiye.HepsiBurada.CatalogProductApiHelper("02879e22-0a4d-49be-8c54-6fca8c2ec8e3", "Kk12345!", "kirtasiyekurdu_dev", "https://mpop-sit.hepsiburada.com");
                apiHelper.Authenticate();

                apiHelper.TrackingIdHistory();


                var apiExportList = ApiHelper.GetExportExternalShopExportProducts("HepsiBurada");

                if (apiExportList.Length == 0)
                    return;

                var importList = apiExportList.Take(10).Select(s => new EKirtasiye.HepsiBurada.ImportProductRequest()
                {
                    categoryId = (s.SubCategoryId == 0 ? ApiHelper.GetCategory(s.CategoryId).HepsiBuradaCategoryId : ApiHelper.GetCategory(s.SubCategoryId).HepsiBuradaCategoryId),
                    merchant = apiHelper.MerchantId,
                    attributes = new EKirtasiye.HepsiBurada.ImportProductattribute()
                    {
                        Barcode = s.Barcode,
                        GarantiSuresi = "24",
                        Image1 = s.Picture1Path,
                        Image2 = s.Picture2Path,
                        Image3 = s.Picture3Path,
                        Image4 = s.Picture4Path,
                        Image5 = "",
                        ebatlar_variant_property = "Standart",
                        kg = "5",
                        renk_variant_property = "",
                        Marka = s.Brand,
                        merchantSku = s.StockCode,
                        UrunAciklamasi = s.Details,
                        UrunAdi = s.Label
                    }
                }).ToList();
                var importInfo = apiHelper.ImportProductList(importList);
                if (importInfo.success)
                {
                    //Update işlemleri

                    var track = apiHelper.CheckImportProductStatus(importInfo.data.trackingId);

                }
                else
                {
                    MessageBox.Show("Import Edilemedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                ShowException(ex);
            }

        }

        private void MenuItemShopSetting_Click(object sender, EventArgs e)
        {
            FormShopSetting formShopSetting = new FormShopSetting();
            formShopSetting.ShowDialog();
        }

        private void MenuItemN11Entegration_Click(object sender, EventArgs e)
        {
            FormShopManagerN11 formShop = new FormShopManagerN11();

            formShop.ShowDialog();

        }

        private void MenuItemExportN11_Click(object sender, EventArgs e)
        {
            try
            {
                FormN11Export formN11 = new FormN11Export();

                formN11.Show();


            }
            catch (Exception exception)
            {
                ShowException(exception);

            }

        }

        private void MenuItemTrendyol_Click(object sender, EventArgs e)
        {
            FormTrendyolExport formTrendyol = new FormTrendyolExport();
            formTrendyol.Show();
        }

        private void MenuItemCreateUpdateExport_Click(object sender, EventArgs e)
        {
            try
            {
                //CreateUpdateExport();
                CheckBatchStatusList();
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
        }

        private void MenuItemImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    Filter = "Excel File|*.xlsx"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        // Auto-detect format, supports:
                        //  - Binary Excel files (2.0-2003 format; *.xls)
                        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            // Choose one of either 1 or 2:

                            // 1. Use the reader methods
                            do
                            {
                                while (reader.Read())
                                {
                                    IdeaCatalog ideaCatalog = new IdeaCatalog();

                                    ideaCatalog.StockCode = reader[0].ToString();
                                    if (ideaCatalog.StockCode == "stockCode")
                                        continue;
                                    if (string.IsNullOrEmpty(ideaCatalog.StockCode))
                                        continue;


                                    var catalogs = ApiHelper.FilterCatalog(new EKirtasiye.Model.DocumentFilterRequest()
                                    {

                                        StokSource = "robotelektronik",
                                        ProductStatus = "Tümü",
                                        StokCodeList = new string[] { ideaCatalog.StockCode }
                                    });

                                    if (catalogs.Count == 1)
                                    {
                                        ideaCatalog = catalogs[0];
                                        ideaCatalog.MarketPrice = reader[15].ToString();
                                        ideaCatalog.Price1 = reader[15].ToString();
                                        ideaCatalog.Details = (reader[30] == null ? string.Empty : reader[30].ToString());
                                        ideaCatalog.StockAmount = int.Parse(reader[22].ToString());
                                        ideaCatalog.Status = (reader[2].ToString() == "1");
                                        ApiHelper.InsertIdeaCatalog(ideaCatalog);
                                    }
                                    else
                                    {



                                        ideaCatalog.Label = reader[1].ToString();
                                        ideaCatalog.Title = ideaCatalog.Label;
                                        ideaCatalog.Status = (reader[2].ToString() == "1");
                                        ideaCatalog.Brand = reader[3].ToString();
                                        ideaCatalog.Barcode = reader[6].ToString();
                                        ideaCatalog.MainCategory = reader[7].ToString();
                                        ideaCatalog.Category = (reader[9] == null ? string.Empty : reader[9].ToString());
                                        ideaCatalog.SubCategory = (reader[11] == null ? string.Empty : reader[11].ToString());
                                        ideaCatalog.RootProductStockCode = (reader[13] == null ? string.Empty : reader[13].ToString());
                                        ideaCatalog.MarketPrice = reader[15].ToString();
                                        ideaCatalog.Price1 = reader[15].ToString();
                                        ideaCatalog.CurrencyAbbr = reader[21].ToString();
                                        ideaCatalog.Tax = reader[20].ToString();
                                        ideaCatalog.StockAmount = int.Parse(reader[22].ToString());
                                        ideaCatalog.StockType = reader[23].ToString();
                                        ideaCatalog.Picture1Path = (reader[25] == null ? string.Empty : reader[25].ToString());
                                        ideaCatalog.Picture2Path = (reader[26] == null ? string.Empty : reader[26].ToString());
                                        ideaCatalog.Picture3Path = (reader[27] == null ? string.Empty : reader[27].ToString());
                                        ideaCatalog.Picture4Path = (reader[28] == null ? string.Empty : reader[28].ToString());
                                        ideaCatalog.Details = (reader[30] == null ? string.Empty : reader[30].ToString());
                                        ideaCatalog.RebatePercent = int.Parse(reader[31].ToString());
                                        ideaCatalog.Dm3 = (int)decimal.Parse(reader[29].ToString().Replace(",", "."));
                                        ideaCatalog.ProductSource = "robotelektronik";
                                        ideaCatalog.WebExportStatus = "Hazir";
                                        ApiHelper.InsertIdeaCatalog(ideaCatalog);

                                    }
                                }
                            } while (reader.NextResult());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void MenuItemExportTrendYol_Click(object sender, EventArgs e)
        {

        }

        private void MenuItemTedarikciPasswords_Click(object sender, EventArgs e)
        {
            FormProviderPassword formProvider = new FormProviderPassword();
            formProvider.ShowDialog();
        }

        private void MenuItemDerya_Click(object sender, EventArgs e)
        {
            FormCerenImport frFormCerenImport = new FormCerenImport("Derya");

            frFormCerenImport.Show();
        }

        private void MenuItemExportCicekSepeti_Click(object sender, EventArgs e)
        {
            try
            {
                var exportProductList = ApiHelper.GetExportExternalShopExportProducts("CicekSepeti").ToList();

                foreach (var catalog in exportProductList)
                {

                    try
                    {
                        var exportReturn = CicekSepetiHelper.ExportProduct(catalog);

                        if (exportReturn == "ok")
                        {
                            var apiReturn = ApiHelper.UpdateProductShopId(new EKirtasiye.Model.UpdateProductShopRequest()
                            {
                                Exported = true,
                                ProductId = catalog.Id,
                                ShopName = "CicekSepeti"
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }

            }
            catch (Exception ex)
            {

                ShowException(ex);
            }

        }

        private void MenuItemExportSingleCicekSepeti_Click(object sender, EventArgs e)
        {



            IdeaCatalog ideaCatalog = null;
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                var obj = gridView1.GetRow(row) as IdeaCatalog;
                ideaCatalog = obj;
                break;

            }

            if (ideaCatalog != null)
            {
                formExportSingleCicekSepeti = new FormExportSingleCicekSepeti();
                formExportSingleCicekSepeti.SelectedProduct = ideaCatalog;
                formExportSingleCicekSepeti.OnSaveAndNextDocument += ProductEdit_OnSaveAndNextDocument;
                formExportSingleCicekSepeti.Show();
            }
        }
    }
}
