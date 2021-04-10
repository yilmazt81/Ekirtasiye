using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.DBLayer
{
    public class IdeaCatalogRepository
    {

        private static List<ProductCategory> productCategories = new List<ProductCategory>();

        public static void SaveProductUrl(ProductUrl url)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pSaveProductUrl";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;

                    scom.Parameters.AddWithValue("@ProductCategoryId", url.ProductCategoryId);
                    scom.Parameters.AddWithValue("@PageLink", url.ProductLink);
                    scom.Parameters.AddWithValue("@ProductName", (string.IsNullOrEmpty(url.ProductName) ? DBNull.Value : (object)url.ProductName));
                    scom.Parameters.AddWithValue("@ProductSource", (string.IsNullOrEmpty(url.ProductSource) ? DBNull.Value : (object)url.ProductSource));
                    scom.Parameters.AddWithValue("@ReadProductPage", url.ReadProductPage);
                    scom.Parameters.AddWithValue("@StockCode", url.StockCode);
                    scom.Parameters.AddWithValue("@StockState", url.StockState);


                    scom.ExecuteNonQuery();

                }
            }
        }

        public static List<IdeaCatalog> FilterCatalog(DocumentFilterRequest documentFilter)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {

                    string query = "";
                    if (!string.IsNullOrEmpty(documentFilter.WebExportState))
                    {
                        if (documentFilter.WebExportState != "Tümü")
                        {
                            query = $" WebExportStatus ='{documentFilter.WebExportState}' and ";
                        }

                    }
                    if (!string.IsNullOrEmpty(documentFilter.StokSource))
                    {
                        if (documentFilter.StokSource != "Tümü")
                        {
                            query += $" ProductSource ='{documentFilter.StokSource}' and ";
                        }
                    }
                    if (documentFilter.MainCategoryId > 0)
                    {
                        query += $" MainCategoryId ={documentFilter.MainCategoryId} and ";
                    }

                    if (documentFilter.SubCategoryId > 0)
                    {
                        query += $" SubCategoryId ={documentFilter.SubCategoryId} and ";
                    }


                    if (documentFilter.CategoryId > 0)
                    {
                        query += $" CategoryId ={documentFilter.CategoryId} and ";
                    }


                    if (!string.IsNullOrEmpty(documentFilter.StokCode))
                    {
                        query += $" ( StockCode  like N'%{documentFilter.StokCode}%'  or Barcode  like N'%{documentFilter.StokCode}%' or Label  like N'%{documentFilter.StokCode}%') and ";
                    }

                    if (documentFilter.ProductStatus != "Tümü")
                    {
                        var status = (documentFilter.ProductStatus == "Aktif" ? "1" : "0");
                        query += $" Status ={status} and ";
                    }

                    if (!string.IsNullOrEmpty(documentFilter.N11Export))
                    {
                        if (documentFilter.N11Export != "Tümü")
                        {

                            var status = (documentFilter.N11Export == "Hayır" ? "0" : "1");
                            query += $" isnull(ExportN11,0) ={status} and ";

                            if (status == "1")
                            {
                                string appStatus = "";
                                if (documentFilter.N11Export == "Aktif (Satışta)")
                                {
                                    appStatus = "1";
                                }
                                if (documentFilter.N11Export == "Beklemede")
                                {
                                    appStatus = "2";
                                }
                                if (documentFilter.N11Export == "Yasaklı")
                                {
                                    appStatus = "3";
                                }
                                if (documentFilter.N11Export == "Liste Dışı")
                                {
                                    appStatus = "4";
                                }
                                if (documentFilter.N11Export == "Onay bekleyen")
                                {
                                    appStatus = "5";
                                }
                                if (documentFilter.N11Export == "Reddedilen")
                                {
                                    appStatus = "6";
                                }

                                if (!string.IsNullOrEmpty(appStatus))
                                {
                                    query += $" ApprovalStatus ='{appStatus}' and ";
                                }
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(documentFilter.HepsiBuradaExport))
                    {
                        if (documentFilter.HepsiBuradaExport != "Tümü")
                        {
                            var status = (documentFilter.HepsiBuradaExport == "Evet" ? "1" : "0");
                            query += $" ExportHepsiBurada ={status} and ";
                        }
                    }


                    if (!string.IsNullOrEmpty(documentFilter.ExportTrendyol))
                    {
                        if (documentFilter.ExportTrendyol != "Tümü")
                        {
                            var status = (documentFilter.ExportTrendyol == "Evet" ? "1" : "0");
                            query += $" isnull(ExportTrendyol,0) ={status} and ";
                        }
                    }


                    if (!string.IsNullOrEmpty(documentFilter.IdeaExport))
                    {
                        if (documentFilter.IdeaExport != "Tümü")
                        {
                            var status = (documentFilter.IdeaExport == "Evet" ? "1" : "0");
                            query += $" ExportIdea ={status} and ";
                        }
                    }
                    if (!string.IsNullOrEmpty(documentFilter.HaveInternetPrice))
                    {
                        if (documentFilter.HaveInternetPrice != "Tümü")
                        {
                            if (documentFilter.HaveInternetPrice == "Var")
                            {
                                query += $" ISNULL(WebPrice,'')<>'' and ";
                            }
                            else if (documentFilter.HaveInternetPrice == "Yok")
                            {
                                query += $" ISNULL(WebPrice,'')='' and ";
                            }
                        }
                    }

                    if (documentFilter.StokCodeList.Length != 0)
                    {
                        string stokCode = string.Empty;
                        foreach (var oneStokCode in documentFilter.StokCodeList)
                        {
                            stokCode += "N'" + oneStokCode + "',";
                        }
                        stokCode = stokCode.Substring(0, stokCode.Length - 1);

                        query += $" StockCode in (" + stokCode + ") and ";
                    }
                    if (!string.IsNullOrEmpty(documentFilter.PriceFilterType) && (documentFilter.PriceFilterType != "Tümü"))
                    {
                        query += $" dbo.fConvertToPrice(MarketPrice) {documentFilter.PriceFilterType} '" + documentFilter.PriceFilter + "' and ";

                    }

                    if (documentFilter.CreatedDate != null)
                    {
                        
                        query += $" CAST(CreatedDate AS DATE) {documentFilter.DateFilterType} CAST('{documentFilter.CreatedDate.Value.ToString("yyyyMMdd")} 00:00:00' AS DATE) and ";
                    }

                    if (!string.IsNullOrEmpty(query))
                    {
                        query = " where " + query.Substring(0, query.Length - 4);
                    }

                    scom.CommandText = "SELECT  * ,dbo.fConvertTitleToUrl(ISNULL(Label,Title)) AS MyProductUrl  FROM  IdeaCatalog    " + query;

                    scom.CommandType = System.Data.CommandType.Text;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(scom);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ideaCatalogs.Add(ConvertToIdeaCatalog(row));
                    }

                    return ideaCatalogs;

                }
            }
        }

        public static List<IdeaCatalog> GetUpdatedExportCatalog(int targetExportId)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pGetUpdatedExports";
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@TargetExportId", targetExportId);
                    List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();
                    using (SqlDataReader reader = scom.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ideaC = GetProductWithId(Convert.ToInt32(reader["Id"]));
                            ideaCatalogs.Add(ideaC);
                        }
                    }

                    return ideaCatalogs;
                }
            }
        }

        public static bool AddProductToShopExport(int productId)
        {
            DBHelper.ExecuteCommand($"INSERT INTO ProductShopExport(ProductId) VALUES ({productId})");

            return true;
        }

        public static void UpdateProductPictures(UpdateProductPictureRequest updateProductPicture)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.CommandText = "pUpdateIdeaCatalogImage";

                    scom.Parameters.AddWithValue("@Id", updateProductPicture.ProductId);
                    scom.Parameters.AddWithValue("@ImagePath1", (string.IsNullOrEmpty(updateProductPicture.PicturePath1) ? DBNull.Value : (object)updateProductPicture.PicturePath1));
                    scom.Parameters.AddWithValue("@ImagePath2", (string.IsNullOrEmpty(updateProductPicture.PicturePath2) ? DBNull.Value : (object)updateProductPicture.PicturePath2));
                    scom.Parameters.AddWithValue("@ImagePath3", (string.IsNullOrEmpty(updateProductPicture.PicturePath3) ? DBNull.Value : (object)updateProductPicture.PicturePath3));
                    scom.Parameters.AddWithValue("@ImagePath4", (string.IsNullOrEmpty(updateProductPicture.PicturePath4) ? DBNull.Value : (object)updateProductPicture.PicturePath4));



                    scom.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateProductPrice(int productId, string webPrice)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.CommandText = "pUpdateIdeaCatalogWebPrice";

                    scom.Parameters.AddWithValue("@Id", productId);
                    scom.Parameters.AddWithValue("@WebPrice", webPrice);

                    scom.ExecuteNonQuery();
                }
            }
        }

        public static List<string> GetWebExportStatus()
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "SELECT * FROM vWebExportStatus  ";
                    scom.CommandType = System.Data.CommandType.Text;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(scom);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    List<string> ideaCatalogs = new List<string>()
                    {
                        "Tümü"
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ideaCatalogs.Add(row[0].ToString());
                    }

                    return ideaCatalogs;

                }
            }
        }

        public static List<string> GetStockSource()
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "SELECT * FROM vStockSource  ";
                    scom.CommandType = System.Data.CommandType.Text;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(scom);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    List<string> ideaCatalogs = new List<string>()
                    {
                        "Tümü"
                    };

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ideaCatalogs.Add(row[0].ToString());
                    }

                    return ideaCatalogs;

                }
            }
        }

        public static IdeaCatalog GetProductWithId(int id)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = $"SELECT * ,dbo.fConvertTitleToUrl(ISNULL(Label,Title)) AS MyProductUrl FROM dbo.IdeaCatalog WHERE Id={id}";
                    scom.CommandType = System.Data.CommandType.Text;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(scom);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    try
                    {
                        var ideaCatalogs = ConvertToIdeaCatalog(dataTable.Rows[0]);
                        return ideaCatalogs;
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }


                }
            }
        }
        public static List<IdeaCatalog> GetFindPictureIdeaCatalog(int lockedBy)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "pGetProductPicture";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@LockedBy", lockedBy);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(scom);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        ideaCatalogs.Add(ConvertToIdeaCatalog(row));
                    }

                    return ideaCatalogs;
                }
            }
        }

        public static IdeaExportTarget[] GetIdeaExportTargets()
        {
            var dtRows = DBHelper.GetQuery("select * from IdeaExportTarget");


            return dtRows.Rows.Cast<DataRow>().Select(s => new IdeaExportTarget() { Id = Convert.ToInt32(s["Id"]), Name = s["Name"].ToString(), ExcelExport=(bool)s["ExcelExport"] }).ToArray();
        }


        public static void SaveLastProductExportProperty(LastProductExportProperty lastProductExport)
        {
            DBHelper.ExecuteCommand("pSaveLastProductExportProperty", new SqlParameter[] {
                    new SqlParameter("@ProductId", lastProductExport.ProductId),
                    new SqlParameter("@IdeaExportTargetId",lastProductExport.IdeaExportTargetId),
                    new SqlParameter("@ProductPrice",lastProductExport.ProductPrice),
                    new SqlParameter("@ProductState",lastProductExport.ProductState),
                    new SqlParameter("@PicturePath1",(string.IsNullOrEmpty(lastProductExport.PicturePath1)?DBNull.Value:(object)lastProductExport.PicturePath1)),
                    new SqlParameter("@PicturePath2",(string.IsNullOrEmpty(lastProductExport.PicturePath2)?DBNull.Value:(object)lastProductExport.PicturePath2)),
                    new SqlParameter("@PicturePath3",(string.IsNullOrEmpty(lastProductExport.PicturePath3)?DBNull.Value:(object)lastProductExport.PicturePath3)),
                    new SqlParameter("@PicturePath4",(string.IsNullOrEmpty(lastProductExport.PicturePath4)?DBNull.Value:(object)lastProductExport.PicturePath4))


            });
        }

        private static IdeaCatalog ConvertToIdeaCatalog(DataRow row)
        {

            if (productCategories.Count == 0)
            {
                productCategories = ProductCategoryRepository.GetProductCategoriesAll();
            }
            var idep = new IdeaCatalog();
            idep.Title = row["Title"].ToString();
            idep.Picture1Path = row["Picture1Path"].ToString();
            idep.Barcode = row["Barcode"].ToString();
            idep.Brand = row["Brand"].ToString();
            idep.Category = row["Category"].ToString();
            idep.Description = row["Description"].ToString();
            idep.Details = row["Details"].ToString();
            idep.Keywords = row["Keywords"].ToString();
            idep.MainCategory = row["MainCategory"].ToString();
            idep.Picture2Path = row["Picture2Path"].ToString();
            idep.Picture3Path = row["Picture3Path"].ToString();
            idep.Picture4Path = row["Picture4Path"].ToString();
            idep.ProductSource = row["ProductSource"].ToString();
            idep.StockCode = row["StockCode"].ToString();
            idep.SubCategory = row["SubCategory"].ToString();
            idep.Price1 = row["Price1"].ToString();
            idep.Price2 = row["Price2"].ToString();
            idep.Price3 = row["Price3"].ToString();
            idep.Price4 = row["Price4"].ToString();
            idep.Price5 = row["Price5"].ToString();
            idep.StockType = row["StockType"].ToString();
            idep.Tax = row["Tax"].ToString();
            idep.Label = row["Label"].ToString();
            idep.CurrencyAbbr = row["CurrencyAbbr"].ToString();
            idep.Warrant = row["Warrant"].ToString();
            idep.MarketPrice = row["MarketPrice"].ToString();
            idep.WebExportStatus = row["WebExportStatus"].ToString();
            idep.CategoryId = (row["CategoryId"] == DBNull.Value ? 0 : (int)row["CategoryId"]);
            idep.MainCategoryId = (row["MainCategoryId"] == DBNull.Value ? 0 : (int)row["MainCategoryId"]);
            idep.Id = (int)row["Id"];
            idep.SubCategoryId = (row["SubCategoryId"] == DBNull.Value ? 0 : (int)row["SubCategoryId"]);
            idep.Status = (bool)row["Status"];
            idep.StockAmount = (row["StockAmount"] == DBNull.Value ? 0 : Convert.ToInt32(row["StockAmount"]));
            idep.WebPrice = row["WebPrice"].ToString();

            idep.LastEdited = row["LastEdited"].ToString();
            idep.MoneyOrderPercent = (row["MoneyOrderPercent"] == DBNull.Value ? 0 : Convert.ToInt32(row["MoneyOrderPercent"]));
            idep.Dm3 = (row["Dm3"] == DBNull.Value ? 0 : Convert.ToInt32(row["Dm3"]));
            idep.ProductUrl = row["ProductUrl"].ToString();
            idep.RebatePercent = (row["RebatePercent"] == DBNull.Value ? 0 : Convert.ToInt32(row["RebatePercent"]));
            idep.RootProductStockCode = row["RootProductStockCode"].ToString();
            idep.ApprovalStatusTrendYol = (row["ApprovalStatusTrendYol"] == DBNull.Value ? 0 : Convert.ToInt32(row["ApprovalStatusTrendYol"]));

            idep.Web_Category = (idep.CategoryId == 0 ? "" : ProductCategory(idep.CategoryId).CategoryName);
            idep.Web_MainCategory = (idep.MainCategoryId == 0 ? "" : ProductCategory(idep.MainCategoryId).CategoryName);
            idep.Web_SubCategory = (idep.SubCategoryId == 0 ? "" : ProductCategory(idep.SubCategoryId).CategoryName);
            idep.MyProductUrl = row["MyProductUrl"].ToString();
            idep.LastEditedDate = (row["LastEditedDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["LastEditedDate"]);
            idep.N11ProductId = (row["N11ProductId"] == DBNull.Value ? 0 : Convert.ToInt64(row["N11ProductId"]));
            idep.ExportN11 = (row["ExportN11"] == DBNull.Value ? false : (bool)row["ExportN11"]);
            idep.LastStockCheckDate = (row["LastStockCheckDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["LastStockCheckDate"]);
            idep.ApprovalStatus = row["ApprovalStatus"].ToString();
           
            return idep;
        }
        private static ProductCategory ProductCategory(int id)
        {
            var category = productCategories.SingleOrDefault(s => s.Id == id);

            if (category == null)
            {
                category = ProductCategoryRepository.GetProductCategori(id);
                productCategories.Add(category);
            }


            return category;
        }

        public static void UpdateProductUrl(int id, int state)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = $"UPDATE ProductUrl SET ReadProductPage={state},LockedBy=0 WHERE Id={id}";
                    scom.ExecuteNonQuery();

                }
            }
        }

        public static void UpdateCategoryId(int productId, int mainCategoryId, int categoryId, int subCategoryId)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pUpdateIdeaCategory";
                    scom.CommandType = CommandType.StoredProcedure;

                    scom.Parameters.AddWithValue("@Id", productId);
                    scom.Parameters.AddWithValue("@MainCategoryId", mainCategoryId);
                    scom.Parameters.AddWithValue("@CategoryId", categoryId);
                    scom.Parameters.AddWithValue("@SubCategoryId", subCategoryId);



                    scom.ExecuteNonQuery();

                }
            }
        }

        public static IdeaCatalog GetIdeaCatalogFromBarcode(string barcode, bool getFromBackup = false)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    string tableName = (getFromBackup ? "IdeaCatalog_backup" : "IdeaCatalog");
                    scom.CommandText = $"select * from {tableName} where Barcode='{barcode}'";

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(scom))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        if (dataTable.Rows.Count == 0)
                        {
                            return null;
                        }
                        else
                        {
                            return ConvertToIdeaCatalog(dataTable.Rows[0]);
                        }
                    }

                }
            }
        }

        public static List<ProductUrl> GetReadProductUrls(int lockedBy, string productSource)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pGetReadProductPages";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;

                    scom.Parameters.AddWithValue("@LockedBy", lockedBy);
                    scom.Parameters.AddWithValue("@ProductSource", productSource);
                    List<ProductUrl> productUrls = new List<ProductUrl>();
                    using (SqlDataReader reader = scom.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productUrls.Add(new ProductUrl()
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProductCategoryId = Convert.ToInt32(reader["ProductCategoryId"]),
                                ProductLink = reader["PageLink"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                ProductSource = reader["ProductSource"].ToString(),
                                StockCode = reader["StockCode"].ToString()

                            });
                        }
                    }

                    return productUrls;
                }
            }
        }
        public static void InsertIdeaCatalog(IdeaCatalog ideaCatalog)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "pInsertIdeaProduct";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@StockCode", (string.IsNullOrEmpty(ideaCatalog.StockCode) ? DBNull.Value : (object)ideaCatalog.StockCode));
                    scom.Parameters.AddWithValue("@Label", (string.IsNullOrEmpty(ideaCatalog.Label) ? DBNull.Value : (object)ideaCatalog.Label));
                    scom.Parameters.AddWithValue("@Status", ideaCatalog.Status);
                    scom.Parameters.AddWithValue("@Brand", (string.IsNullOrEmpty(ideaCatalog.Brand) ? DBNull.Value : (object)ideaCatalog.Brand));
                    scom.Parameters.AddWithValue("@MainCategory", (string.IsNullOrEmpty(ideaCatalog.MainCategory) ? DBNull.Value : (object)ideaCatalog.MainCategory));
                    scom.Parameters.AddWithValue("@MainCategoryId", ideaCatalog.MainCategoryId == 0 ? DBNull.Value : (object)ideaCatalog.MainCategoryId);

                    scom.Parameters.AddWithValue("@SubCategory", (string.IsNullOrEmpty(ideaCatalog.SubCategory) ? DBNull.Value : (object)ideaCatalog.SubCategory));
                    scom.Parameters.AddWithValue("@SubCategoryId", ideaCatalog.SubCategoryId == 0 ? DBNull.Value : (object)ideaCatalog.SubCategoryId);

                    scom.Parameters.AddWithValue("@Category", (string.IsNullOrEmpty(ideaCatalog.Category) ? DBNull.Value : (object)ideaCatalog.Category));
                    scom.Parameters.AddWithValue("@CategoryId", ideaCatalog.CategoryId == 0 ? DBNull.Value : (object)ideaCatalog.CategoryId);

                    scom.Parameters.AddWithValue("@RootProductStockCode", (string.IsNullOrEmpty(ideaCatalog.RootProductStockCode) ? DBNull.Value : (object)ideaCatalog.RootProductStockCode));

                    scom.Parameters.AddWithValue("@MarketPrice", (string.IsNullOrEmpty(ideaCatalog.MarketPrice) ? DBNull.Value : (object)ideaCatalog.MarketPrice));
                    scom.Parameters.AddWithValue("@Price1", (string.IsNullOrEmpty(ideaCatalog.Price1) ? DBNull.Value : (object)ideaCatalog.Price1));

                    scom.Parameters.AddWithValue("@Price2", (string.IsNullOrEmpty(ideaCatalog.Price2) ? DBNull.Value : (object)ideaCatalog.Price2));
                    scom.Parameters.AddWithValue("@Price3", (string.IsNullOrEmpty(ideaCatalog.Price3) ? DBNull.Value : (object)ideaCatalog.Price3));
                    scom.Parameters.AddWithValue("@Price4", (string.IsNullOrEmpty(ideaCatalog.Price4) ? DBNull.Value : (object)ideaCatalog.Price4));
                    scom.Parameters.AddWithValue("@Price5", (string.IsNullOrEmpty(ideaCatalog.Price5) ? DBNull.Value : (object)ideaCatalog.Price5));

                    scom.Parameters.AddWithValue("@Tax", (string.IsNullOrEmpty(ideaCatalog.Tax) ? DBNull.Value : (object)ideaCatalog.Tax));
                    scom.Parameters.AddWithValue("@CurrencyAbbr", (string.IsNullOrEmpty(ideaCatalog.CurrencyAbbr) ? DBNull.Value : (object)ideaCatalog.CurrencyAbbr));

                    scom.Parameters.AddWithValue("@RebatePercent", (ideaCatalog.RebatePercent == 0 ? DBNull.Value : (object)ideaCatalog.RebatePercent));

                    scom.Parameters.AddWithValue("@MoneyOrderPercent", (ideaCatalog.MoneyOrderPercent == 0 ? DBNull.Value : (object)ideaCatalog.MoneyOrderPercent));

                    scom.Parameters.AddWithValue("@StockAmount", (ideaCatalog.StockAmount == 0 ? DBNull.Value : (object)ideaCatalog.StockAmount));
                    scom.Parameters.AddWithValue("@StockType", (string.IsNullOrEmpty(ideaCatalog.StockType) ? DBNull.Value : (object)ideaCatalog.StockType));
                    scom.Parameters.AddWithValue("@Warrant", (string.IsNullOrEmpty(ideaCatalog.Warrant) ? DBNull.Value : (object)ideaCatalog.Warrant));

                    scom.Parameters.AddWithValue("@Picture1Path", (string.IsNullOrEmpty(ideaCatalog.Picture1Path) ? DBNull.Value : (object)ideaCatalog.Picture1Path));

                    scom.Parameters.AddWithValue("@Picture2Path", (string.IsNullOrEmpty(ideaCatalog.Picture2Path) ? DBNull.Value : (object)ideaCatalog.Picture2Path));
                    scom.Parameters.AddWithValue("@Picture3Path", (string.IsNullOrEmpty(ideaCatalog.Picture3Path) ? DBNull.Value : (object)ideaCatalog.Picture3Path));
                    scom.Parameters.AddWithValue("@Picture4Path", (string.IsNullOrEmpty(ideaCatalog.Picture4Path) ? DBNull.Value : (object)ideaCatalog.Picture4Path));

                    scom.Parameters.AddWithValue("@Dm3", (ideaCatalog.Dm3 == 0 ? DBNull.Value : (object)ideaCatalog.Dm3));

                    scom.Parameters.AddWithValue("@Details", (string.IsNullOrEmpty(ideaCatalog.Details) ? DBNull.Value : (object)ideaCatalog.Details));
                    scom.Parameters.AddWithValue("@Title", (string.IsNullOrEmpty(ideaCatalog.Title) ? DBNull.Value : (object)ideaCatalog.Title));
                    scom.Parameters.AddWithValue("@Keywords", (string.IsNullOrEmpty(ideaCatalog.Keywords) ? DBNull.Value : (object)ideaCatalog.Keywords));
                    scom.Parameters.AddWithValue("@Description", (string.IsNullOrEmpty(ideaCatalog.Description) ? DBNull.Value : (object)ideaCatalog.Description));

                    scom.Parameters.AddWithValue("@ProductSource", (string.IsNullOrEmpty(ideaCatalog.ProductSource) ? DBNull.Value : (object)ideaCatalog.ProductSource));
                    scom.Parameters.AddWithValue("@ProductUrl", (string.IsNullOrEmpty(ideaCatalog.ProductUrl) ? DBNull.Value : (object)ideaCatalog.ProductUrl));
                    scom.Parameters.AddWithValue("@Barcode", (string.IsNullOrEmpty(ideaCatalog.Barcode) ? DBNull.Value : (object)ideaCatalog.Barcode));

                    scom.Parameters.AddWithValue("@WebExportStatus", ideaCatalog.WebExportStatus);
                    scom.Parameters.AddWithValue("@LastEdited", (string.IsNullOrEmpty(ideaCatalog.LastEdited) ? DBNull.Value : (object)ideaCatalog.LastEdited));
                    scom.Parameters.AddWithValue("@LastEditedDate", (ideaCatalog.LastEditedDate == DateTime.MinValue ? DBNull.Value : (object)ideaCatalog.LastEditedDate));
                    scom.Parameters.AddWithValue("@WebPrice", (string.IsNullOrEmpty(ideaCatalog.WebPrice) ? DBNull.Value : (object)ideaCatalog.WebPrice));


                    var newId = scom.ExecuteScalar();

                    ideaCatalog.Id = Convert.ToInt32(newId);


                }

                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "delete from IdeaCatalog_Barcode where IdeaCatalogId=" + ideaCatalog.Id;
                    scom.ExecuteNonQuery();
                }

                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "delete from IdeaCatalog_Price where IdeaCatalogId=" + ideaCatalog.Id;
                    scom.ExecuteNonQuery();
                }

                foreach (var oneBarcode in ideaCatalog.Barcodes)
                {
                    using (SqlCommand scom = scon.CreateCommand())
                    {
                        scom.CommandText = "pSaveIdeaCatalog_Barcode";
                        scom.CommandType = CommandType.StoredProcedure;
                        scom.Parameters.AddWithValue("@IdeaCatalogId", ideaCatalog.Id);
                        scom.Parameters.AddWithValue("@Barcode", oneBarcode.Barcode);
                        scom.Parameters.AddWithValue("@StockType", (string.IsNullOrEmpty(oneBarcode.StockType) ? DBNull.Value : (object)oneBarcode.StockType));

                        scom.ExecuteNonQuery();
                    }
                }

                foreach (var oneBarcode in ideaCatalog.ProductPrices)
                {
                    using (SqlCommand scom = scon.CreateCommand())
                    {
                        scom.CommandText = "pSaveIdeaCatalog_Price";
                        scom.CommandType = CommandType.StoredProcedure;
                        scom.Parameters.AddWithValue("@IdeaCatalogId", ideaCatalog.Id);
                        scom.Parameters.AddWithValue("@Amount", oneBarcode.Amount);
                        scom.Parameters.AddWithValue("@Unit", (string.IsNullOrEmpty(oneBarcode.Unit) ? DBNull.Value : (object)oneBarcode.Unit));
                        scom.Parameters.AddWithValue("@Price", (string.IsNullOrEmpty(oneBarcode.Price) ? DBNull.Value : (object)oneBarcode.Price));

                        scom.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void UpdateImageState(IdeaCatalog ideaCatalog, int state)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = $"UPDATE IdeaCatalog SET GetProductPicture={state},Picture1Path='{ideaCatalog.Picture1Path}' WHERE Id={ideaCatalog.Id}";
                    scom.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateWebExportState(int id, string webExportState)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "pUpdateIdeaCatalog";
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@Id", id);
                    scom.Parameters.AddWithValue("@WebExportStatus", webExportState);

                    scom.ExecuteNonQuery();
                }
            }
        }

        public static void SaveProductWebSearchResult(ProductWebSearchResult productWebSearch)
        {

            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = $"DELETE FROM ProductWebSearchResult WHERE ProductId={productWebSearch.ProductId}";
                    scom.ExecuteNonQuery();
                }
            }
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "pSaveProductWebSearch";
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@Id", productWebSearch.Id);
                    scom.Parameters.AddWithValue("@ProductId", productWebSearch.ProductId);
                    scom.Parameters.AddWithValue("@LinkName", (string.IsNullOrEmpty(productWebSearch.LinkName) ? DBNull.Value : (object)productWebSearch.LinkName));
                    scom.Parameters.AddWithValue("@ProductUrl", (string.IsNullOrEmpty(productWebSearch.ProductUrl) ? DBNull.Value : (object)productWebSearch.ProductUrl));
                    scom.Parameters.AddWithValue("@ProductImage", (string.IsNullOrEmpty(productWebSearch.ProductImage) ? DBNull.Value : (object)productWebSearch.ProductImage));
                    scom.Parameters.AddWithValue("@ProductPrice", (string.IsNullOrEmpty(productWebSearch.ProductPrice) ? DBNull.Value : (object)productWebSearch.ProductPrice));
                    scom.Parameters.AddWithValue("@ProductSimilarity", productWebSearch.ProductSimilarity);

                    scom.ExecuteNonQuery();
                }
            }
        }

        public static List<IdeaCatalog> GetExportExternalShopExportProducts(string shopName)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = $"pGetExportExternalShopExportProducts";
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@ShopName", shopName);
                    List<IdeaCatalog> ideaCatalogs = new List<IdeaCatalog>();

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(scom))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        foreach (DataRow item in dataTable.Rows)
                        {
                            ideaCatalogs.Add(ConvertToIdeaCatalog(item));
                        }
                    }

                    return ideaCatalogs;

                }
            }
        }

        public static void UpdateProductShopId(int id, Int64 productId, string shopName, bool exported, string price)
        {
            DBHelper.ExecuteCommand("pUpdateProductShopId", new SqlParameter[] {
                new SqlParameter("@Id",id),
                new SqlParameter("@ProductId", productId),
                new SqlParameter("@ShopName",shopName),
                new SqlParameter("@Exported",exported),
                new SqlParameter("@Price",price)
            });
        }

        public static void UpdateShopProductState(int id, string shopName, string approvalStatus)
        {
            DBHelper.ExecuteCommand("pUpdateShopProductState", new SqlParameter[] {
                new SqlParameter("@Id",id),
                new SqlParameter("@ShopName",shopName),
                new SqlParameter("@SaleState",approvalStatus)
            });
        }
    }
}
