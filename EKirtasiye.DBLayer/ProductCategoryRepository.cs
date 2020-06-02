using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.DBLayer
{
    public class ProductCategoryRepository
    {

        public static List<ProductCategory> GetProductCategories()
        {
            return GetProductCategories(0);
        }

        public static List<ProductCategory> GetProductCategories(int upCategory)
        {
            var dtTable = DBHelper.GetQuery($"SELECT * FROM dbo.ProductCategory where UpId={upCategory}");

            return dtTable.Rows.Cast<DataRow>().Select(s => ConvertCategory(s)).ToList();
        }

        private static ProductCategory ConvertCategory(DataRow reader)
        {
          return  new ProductCategory()
            {
                CategoryName = reader["CategoryName"].ToString(),
                CategoryUrl = reader["CategoryUrl"].ToString(),
                Id = Convert.ToInt32(reader["Id"]),
                UpId = (reader["UpId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["UpId"])),
                HepsiBuradaCategoryId = (reader["HepsiBuradaCategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["HepsiBuradaCategoryId"])),
                N11CategoryId = (reader["N11CategoryId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["N11CategoryId"])),
                HepsiBuradaCategoryName = reader["HepsiBuradaCategoryName"].ToString(),
                N11CategoryName = reader["N11CategoryName"].ToString(),
                N11ExportTemplateId = reader["N11ExportTemplateId"] == DBNull.Value ? 0 : Convert.ToInt32(reader["N11ExportTemplateId"]),
                N11ExportTemplateName = reader["N11ExportTemplateName"].ToString() 
            };
        }
        public static List<ProductCategory> GetProductCategoriesAll()
        {
            var dtTable = DBHelper.GetQuery($"SELECT * FROM dbo.ProductCategory ");


            return dtTable.Rows.Cast<DataRow>().Select(s => ConvertCategory(s)).ToList();


        }
        public static ProductCategory GetProductCategori(int id)
        {
            var dtTable = DBHelper.GetQuery("SELECT * FROM dbo.ProductCategory where Id={id}");


            return dtTable.Rows.Cast<DataRow>().Select(s => ConvertCategory(s)).FirstOrDefault();
        }

        public static void InsertCategory(ProductCategory productCategory)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pInsertProductProcedure";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;

                    scom.Parameters.AddWithValue("@UpCategroyId", productCategory.UpId);
                    scom.Parameters.AddWithValue("@Name", productCategory.CategoryName);
                    scom.Parameters.AddWithValue("@CategoryUrl", (string.IsNullOrEmpty(productCategory.CategoryUrl) ? DBNull.Value : (object)productCategory.CategoryUrl));
                    scom.Parameters.AddWithValue("@N11CategoryId", productCategory.N11CategoryId);
                    scom.Parameters.AddWithValue("@HepsiBuradaCategoryId", productCategory.HepsiBuradaCategoryId);
                    scom.Parameters.AddWithValue("@N11CategoryName", (string.IsNullOrEmpty(productCategory.N11CategoryName) ? DBNull.Value : (object)productCategory.N11CategoryName));
                    scom.Parameters.AddWithValue("@HepsiBuradaCategoryName", (string.IsNullOrEmpty(productCategory.HepsiBuradaCategoryName) ? DBNull.Value : (object)productCategory.HepsiBuradaCategoryName));

                    productCategory.Id = Convert.ToInt32(scom.ExecuteScalar());
                }
            }
        }

        public static List<IdeaCatalogCategoryMatch> GetIdeaCatalogCategoryMatches()
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "SELECT * FROM  IdeaCatalogCategoryMatch";
                    List<IdeaCatalogCategoryMatch> ideaCatalogCategoryMatches = new List<IdeaCatalogCategoryMatch>();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(scom))
                    {

                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ideaCatalogCategoryMatches.Add(new IdeaCatalogCategoryMatch()
                            {
                                ColumnName = row["ColumnName"].ToString(),
                                Id = (int)row["Id"],
                                ImportName = row["ImportName"].ToString(),
                                MainCategoryId = (row["MainCategoryId"] == DBNull.Value ? 0 : (int)row["MainCategoryId"]),
                                SubCategoryId = (row["SubCategoryId"] == DBNull.Value ? 0 : (int)row["SubCategoryId"]),
                                SubSubCategoryId = (row["SubSubCategoryId"] == DBNull.Value ? 0 : (int)row["SubSubCategoryId"]),
                                SelectedFullName = row["SelectedFullName"].ToString()

                            });
                        }
                    }

                    return ideaCatalogCategoryMatches;
                }
            }
        }
        public static void SaveIdeaCatalogCategoryMatch(IdeaCatalogCategoryMatch catalogCategoryMatch)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "pSaveIdeaCatalogCategoryMatch";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@ColumnName", catalogCategoryMatch.ColumnName);
                    scom.Parameters.AddWithValue("@ImportName", catalogCategoryMatch.ImportName);
                    scom.Parameters.AddWithValue("@MainCategoryId", catalogCategoryMatch.MainCategoryId);
                    scom.Parameters.AddWithValue("@SubCategoryId", catalogCategoryMatch.SubCategoryId);
                    scom.Parameters.AddWithValue("@SubSubCategoryId", catalogCategoryMatch.SubSubCategoryId);
                    scom.Parameters.AddWithValue("@SelectedFullName", catalogCategoryMatch.SelectedFullName);

                    scom.ExecuteNonQuery();
                }
            }
        }
    }
}
