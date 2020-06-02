
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public partial class FormImportPreview : Form
    {
        List<MuhasebeDataStok> _muhasebeDataStoks = null;
        List<IdeaCatalogCategoryMatch> ideaCategegoryMatch = null;


        public FormImportPreview(List<MuhasebeDataStok> muhasebeDataStoks)
        {
            InitializeComponent();
            gridControlImport.DataSource = muhasebeDataStoks;
            _muhasebeDataStoks = muhasebeDataStoks;

            ideaCategegoryMatch = ApiHelper.GetIdeaCatalogCategoryMatches().ToList();
        }

        private void MenuItemExportExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "*.xlsx|Excel Dosyası";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                gridControlImport.ExportToXlsx(saveFileDialog.FileName, new DevExpress.XtraPrinting.XlsxExportOptions()
                {
                    ExportMode = DevExpress.XtraPrinting.XlsxExportMode.SingleFile,
                    ShowGridLines = true,
                    TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text,

                });
            }

        }

        private void SetCatalogMatch(IdeaCatalog ideaCatalog)
        {
            if (!string.IsNullOrEmpty(ideaCatalog.MainCategory))
            {
                var mainCategory = ideaCategegoryMatch.FirstOrDefault(s => s.ColumnName == "MainCategory" && s.ImportName == ideaCatalog.MainCategory);
                if (mainCategory != null)
                {
                    ideaCatalog.MainCategoryId = mainCategory.MainCategoryId;
                    ideaCatalog.CategoryId = mainCategory.SubCategoryId;
                    ideaCatalog.SubCategoryId = mainCategory.SubSubCategoryId;
                }
            }

            if (!string.IsNullOrEmpty(ideaCatalog.Category))
            {
                var subCategory = ideaCategegoryMatch.FirstOrDefault(s => s.ColumnName == "Category" && s.ImportName == ideaCatalog.Category);
                if (subCategory != null)
                {
                    if (ideaCatalog.MainCategoryId == 0)
                    {
                        ideaCatalog.MainCategoryId = subCategory.MainCategoryId;
                    }
                    if (ideaCatalog.CategoryId == 0)
                    {
                        ideaCatalog.CategoryId = subCategory.SubCategoryId;
                    }
                    if (subCategory.SubSubCategoryId == 0)
                    {
                        ideaCatalog.SubCategoryId = subCategory.SubSubCategoryId;
                    }
                }
            }

            if (!string.IsNullOrEmpty(ideaCatalog.SubCategory))
            {
                var subCategory = ideaCategegoryMatch.FirstOrDefault(s => s.ColumnName == "SubCategory" && s.ImportName == ideaCatalog.SubCategory);
                if (subCategory != null)
                {
                    if (ideaCatalog.MainCategoryId == 0)
                    {
                        ideaCatalog.MainCategoryId = subCategory.MainCategoryId;
                    }

                    if (ideaCatalog.CategoryId == 0)
                    {
                        ideaCatalog.CategoryId = subCategory.SubCategoryId;
                    }
                    if (subCategory.SubSubCategoryId == 0)
                    {
                        ideaCatalog.SubCategoryId = subCategory.SubSubCategoryId;
                    }
                }
            }
        }
        private void buttonStartImport_Click(object sender, EventArgs e)
        {
            if (_muhasebeDataStoks == null)
                return;
            try
            {
                if (MessageBox.Show("Kayıtları DB ye import etmek istediğinizden emin misiniz ? ", "Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;


                foreach (var muhasebeDataStok in _muhasebeDataStoks)
                {
                    try
                    {
                        IdeaCatalog ideaCatalog = new IdeaCatalog();
                        if (muhasebeDataStok.KatalogDurumu == "Yeni")
                        {
                            var namePart = muhasebeDataStok.ADI.Split(' ');
                            ideaCatalog.Barcode = muhasebeDataStok.BARKOD;
                            ideaCatalog.Title = muhasebeDataStok.ADI;
                            ideaCatalog.Label = muhasebeDataStok.ADI;

                            ideaCatalog.Status = true;
                            ideaCatalog.StockCode = muhasebeDataStok.KOD;
                            ideaCatalog.Brand = (namePart.Length > 1 ? namePart[0] : "");
                            ideaCatalog.MainCategory = muhasebeDataStok.OZELGRUP1;
                            ideaCatalog.Category = muhasebeDataStok.OZELGRUP2;
                            ideaCatalog.SubCategory = muhasebeDataStok.OZELGRUP3;
                            ideaCatalog.Price1 = muhasebeDataStok.SATISFIYAT;
                            ideaCatalog.MarketPrice = muhasebeDataStok.SATISFIYAT;
                            ideaCatalog.WebExportStatus = "Hazirlik";
                            ideaCatalog.StockType = muhasebeDataStok.BIRIMKOD1;
                            ideaCatalog.Tax = muhasebeDataStok.KDVORAN;
                            ideaCatalog.CurrencyAbbr = muhasebeDataStok.DOVIZSEMBOL;
                            ideaCatalog.StockAmount = (string.IsNullOrEmpty(muhasebeDataStok.Stok) ? 10 : int.Parse(muhasebeDataStok.Stok));
                            ideaCatalog.ProductSource = (ideaCatalog.StockCode.StartsWith("kk") ? "Kadioglu" : "Stok");
                            ideaCatalog.Details = muhasebeDataStok.Ozellik;
                            if (muhasebeDataStok.IdeaCatalog != null)
                            {
                                ideaCatalog.Picture1Path = muhasebeDataStok.IdeaCatalog.Picture1Path;
                                ideaCatalog.Picture2Path = muhasebeDataStok.IdeaCatalog.Picture2Path;
                                ideaCatalog.Picture3Path = muhasebeDataStok.IdeaCatalog.Picture3Path;
                                ideaCatalog.Picture4Path = muhasebeDataStok.IdeaCatalog.Picture4Path;
                            }


                            SetCatalogMatch(ideaCatalog);


                        }
                        else if (muhasebeDataStok.KatalogDurumu == "Backup")
                        {
                            ideaCatalog.Barcode = muhasebeDataStok.BARKOD;
                            ideaCatalog.Price1 = muhasebeDataStok.SATISFIYAT;
                            ideaCatalog.MarketPrice = muhasebeDataStok.SATISFIYAT;

                            ideaCatalog.Barcode = muhasebeDataStok.IdeaCatalog.Barcode;
                            ideaCatalog.Brand = muhasebeDataStok.IdeaCatalog.Brand;
                            ideaCatalog.Description = muhasebeDataStok.IdeaCatalog.Description;
                            ideaCatalog.Details = muhasebeDataStok.IdeaCatalog.Details;
                            ideaCatalog.Keywords = muhasebeDataStok.IdeaCatalog.Keywords;
                            ideaCatalog.Picture1Path = muhasebeDataStok.IdeaCatalog.Picture1Path;
                            ideaCatalog.Picture2Path = muhasebeDataStok.IdeaCatalog.Picture2Path;
                            ideaCatalog.Picture3Path = muhasebeDataStok.IdeaCatalog.Picture3Path;
                            ideaCatalog.Picture4Path = muhasebeDataStok.IdeaCatalog.Picture4Path;
                            ideaCatalog.ProductSource = muhasebeDataStok.IdeaCatalog.ProductSource;
                            ideaCatalog.StockCode = muhasebeDataStok.IdeaCatalog.StockCode;

                            ideaCatalog.Price2 = muhasebeDataStok.IdeaCatalog.Price2;
                            ideaCatalog.Price3 = muhasebeDataStok.IdeaCatalog.Price3;
                            ideaCatalog.Price4 = muhasebeDataStok.IdeaCatalog.Price4;
                            ideaCatalog.Price5 = muhasebeDataStok.IdeaCatalog.Price5;
                            ideaCatalog.StockType = muhasebeDataStok.IdeaCatalog.StockType;
                            ideaCatalog.Tax = muhasebeDataStok.IdeaCatalog.Tax;
                            ideaCatalog.Label = muhasebeDataStok.IdeaCatalog.Label;
                            ideaCatalog.CurrencyAbbr = muhasebeDataStok.IdeaCatalog.CurrencyAbbr;
                            ideaCatalog.Warrant = muhasebeDataStok.IdeaCatalog.Warrant;
                            ideaCatalog.Status = muhasebeDataStok.IdeaCatalog.Status;
                            ideaCatalog.StockAmount = muhasebeDataStok.IdeaCatalog.StockAmount;


                            ideaCatalog.MainCategory = muhasebeDataStok.OZELGRUP1;
                            ideaCatalog.Category = muhasebeDataStok.OZELGRUP2;
                            ideaCatalog.SubCategory = muhasebeDataStok.OZELGRUP3;

                            SetCatalogMatch(ideaCatalog);

                            if (string.IsNullOrEmpty(ideaCatalog.Picture1Path) || string.IsNullOrEmpty(ideaCatalog.Price1))
                            {
                                ideaCatalog.WebExportStatus = "Hazirlik";
                            }
                            else
                            {
                                ideaCatalog.WebExportStatus = "Hazir";
                            }

                        }
                        else if (muhasebeDataStok.KatalogDurumu == "Var")
                        {
                            ideaCatalog = muhasebeDataStok.IdeaCatalog;
                            ideaCatalog.MainCategory = muhasebeDataStok.OZELGRUP1;
                            ideaCatalog.Category = muhasebeDataStok.OZELGRUP2;
                            ideaCatalog.SubCategory = muhasebeDataStok.OZELGRUP3;


                            ideaCatalog.Barcode = muhasebeDataStok.BARKOD;
                            ideaCatalog.Price1 = muhasebeDataStok.SATISFIYAT;
                            ideaCatalog.MarketPrice = muhasebeDataStok.SATISFIYAT;

                            if (string.IsNullOrEmpty(ideaCatalog.Picture1Path) || string.IsNullOrEmpty(ideaCatalog.Price1))
                            {
                                ideaCatalog.WebExportStatus = "Hazirlik";
                            }
                            else
                            {
                                ideaCatalog.WebExportStatus = "Hazir";
                            }

                            SetCatalogMatch(ideaCatalog);

                        }

                        ApiHelper.InsertIdeaCatalog(ideaCatalog);
                        //System.Threading.Thread.Sleep(300);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Trace.WriteLine(ex);
                       // FormMain.ShowException(ex);
                      
                    }
                }
                MessageBox.Show("İşlem Bitti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                FormMain.ShowException(ex);
            }
        }
    }
}
