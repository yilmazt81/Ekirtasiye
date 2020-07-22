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
    public class TrendyolCategoryRepository
    {

        public static void SaveCategory(TrendyolCategory nCategory)
        {
            DBHelper.ExecuteCommand("pSaveTrendyolCategory", new SqlParameter[]
            {
                new SqlParameter("@Id",nCategory.Id),
                new SqlParameter("@ParentCategoryId",nCategory.ParentCategoryId),
                new SqlParameter("@Name",nCategory.Name),

            });
        }

        public static List<TrendyolAttribute> GetTrendyolAttributes(int categoryId)
        {
            var dataAttributes = DBHelper.GetQuery($"SELECT   * FROM  TrendyolAttribute  WHERE CategoryId={categoryId}");

            return dataAttributes.Rows.Cast<DataRow>().Select(row => new TrendyolAttribute()
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["name"].ToString(),
                DisplayName = row["displayName"].ToString(),
                AllowCustom = Convert.ToBoolean(row["allowCustom"]),
                Attributeid = Convert.ToInt32(row["attributeid"]),
                Attributename = row["attributename"].ToString(),
                CategoryId = Convert.ToInt32(row["categoryId"]),
                Required = Convert.ToBoolean(row["required"]),
                Slicer = Convert.ToBoolean(row["slicer"]),
                Varianter = Convert.ToBoolean(row["varianter"]),
                TrendyolAttributes = GetTrendyolAttributeValues(Convert.ToInt32(row["Id"]))

            }).ToList();

        }

        public static TrendyolAttributeValue[] GetTrendyolAttributeValues(int attributeId)
        {
            var dataAttributes = DBHelper.GetQuery($"SELECT   * FROM  TrendyolAttributeValue  WHERE TrendyolAttributeId={attributeId}");

            return dataAttributes.Rows.Cast<DataRow>().Select(row => new TrendyolAttributeValue()
            {
                AttributeValue = Convert.ToInt32(row["AttributeValue"]),
                AttributeText = row["AttributeText"].ToString()

            }).ToArray();

        }

        public static TrendyolCategoryDefaultAttribute GetDefaultAttribute(int categoryId, int attributeId)
        {
            var datadefaultAttribute = DBHelper.GetQuery($"SELECT * FROM TrendyolCategoryDefaultAttribute WHERE CategoryId={categoryId} AND AttributeId={attributeId}");

            return (datadefaultAttribute.Rows.Count == 0 ? null : new TrendyolCategoryDefaultAttribute()
            {
                AttributeId = Convert.ToInt32(datadefaultAttribute.Rows[0]["AttributeId"]),
                AttributeName = datadefaultAttribute.Rows[0]["AttributeName"].ToString(),
                AttributeValue = Convert.ToInt32(datadefaultAttribute.Rows[0]["AttributeValue"]),
                CategoryId = Convert.ToInt32(datadefaultAttribute.Rows[0]["CategoryId"]),
                Id = Convert.ToInt32(datadefaultAttribute.Rows[0]["Id"])
            });
        }

        public static List<TrendyolCategoryDefaultAttribute> GetCategoryDefaultAttributes(int categoryId)
        {
            var datadefaultAttribute = DBHelper.GetQuery($"SELECT * FROM TrendyolCategoryDefaultAttribute WHERE CategoryId={categoryId}  ");


            return datadefaultAttribute.Rows.Cast<DataRow>().Select(row => new TrendyolCategoryDefaultAttribute()
            {
                AttributeId = Convert.ToInt32(row["AttributeId"]),
                AttributeName = row["AttributeName"].ToString(),
                AttributeValue = Convert.ToInt32(row["AttributeValue"]),
                CategoryId = Convert.ToInt32(row["CategoryId"]),
                Id = Convert.ToInt32(row["Id"])

            }).ToList();

        }

        public static bool SaveCategoryDefaultAttribute(List<TrendyolCategoryDefaultAttribute> trendyolCategoryDefaultAttributes)
        {
            var categoryId = trendyolCategoryDefaultAttributes.FirstOrDefault().CategoryId;
            DBHelper.ExecuteCommand($"DELETE FROM  TrendyolCategoryDefaultAttribute WHERE CategoryId={categoryId}");
            foreach (var defaultAttribute in trendyolCategoryDefaultAttributes.Where(s => s.AttributeValue != 0))
            {


                DBHelper.ExecuteCommand("pSaveTrendyolDefaultAttribute", new SqlParameter[] {
                new SqlParameter("@CategoryId",defaultAttribute.CategoryId),
                new SqlParameter("@AttributeId",defaultAttribute.AttributeId),
                new SqlParameter("@AttributeName",defaultAttribute.AttributeName),
                new SqlParameter("@AttributeValue",defaultAttribute.AttributeValue)
                });

            }
            return true;
        }

        public static List<TrendyolCategory> GetCategory()
        {

            var dtCategory = DBHelper.GetQuery("SELECT * FROM  TrendyolCategory");
            List<TrendyolCategory> nCategories = dtCategory.Rows.Cast<DataRow>().Select(s => new TrendyolCategory()
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s["Name"].ToString(),
                TargetCategory = (s["TargetCategory"] == DBNull.Value ? true : (bool)s["TargetCategory"]),
                ParentCategoryId = Convert.ToInt32(s["ParentCategoryId"])
            }).ToList();

            return nCategories;

        }

        public static bool SaveTrendyolCreateRequest(TrendyolCreateRequest trendyolCreate)
        {
            DBHelper.ExecuteCommand("pSaveTrendyolCreateRequest", new SqlParameter[]
            {
                new SqlParameter("@ProductId",trendyolCreate.ProductId),
                new SqlParameter("@BatchRequest",trendyolCreate.BatchRequest)
            });

            return true;
        }
        /*
        public static void SaveTrendyolDefaulAttribute(TrendyolCategoryDefaultAttribute defaultAttribute)
        {
            using (SqlConnection connection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "pSaveTrendyolCategoryDefaultAttribute";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", defaultAttribute.Id);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", defaultAttribute.CategoryId);
                    sqlCommand.Parameters.AddWithValue("@AttributeId", defaultAttribute.AttributeId);
                    sqlCommand.Parameters.AddWithValue("@AttributeName", (string.IsNullOrEmpty(defaultAttribute.AttributeName) ? DBNull.Value : (object)defaultAttribute.AttributeName));
                    sqlCommand.Parameters.AddWithValue("@AttributeValue", (string.IsNullOrEmpty(defaultAttribute.AttributeValue) ? DBNull.Value : (object)defaultAttribute.AttributeValue));

                    defaultAttribute.Id = (int)sqlCommand.ExecuteScalar();

                }
            }
        }*/

        public static void SaveTrendyolProductAttributes(List<TrendyolProductAttribute> trendyolProductAttributes)
        {
            var firstAttribute = trendyolProductAttributes.FirstOrDefault();
            DBHelper.ExecuteCommand($"DELETE FROM TrendyolProductAttribute WHERE ProductId={firstAttribute.ProductId}");

            foreach (var trendyolProductAttribute in trendyolProductAttributes)
            {

                DBHelper.ExecuteCommand("pSaveTrendyolProductAttribute", new SqlParameter[]
                {
                    new SqlParameter("@ProductId",trendyolProductAttribute.ProductId),
                    new SqlParameter("@Attributeid",trendyolProductAttribute.Attributeid),
                    new SqlParameter("@AttributeName",trendyolProductAttribute.AttributeName),
                    new SqlParameter("@AttributeValue",trendyolProductAttribute.AttributeValue),
                    new SqlParameter("@AttributeCustomeValue",(string.IsNullOrEmpty(trendyolProductAttribute.AttributeCustomeValue)?DBNull.Value:(object)trendyolProductAttribute.AttributeCustomeValue))

                });
            }
        }
        public static void SaveTrendyolAttribute(TrendyolAttribute trendyolAttribute)
        {
            using (SqlConnection connection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "pSaveTrendyolAttribute";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", trendyolAttribute.Id);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", trendyolAttribute.CategoryId);

                    sqlCommand.Parameters.AddWithValue("@name", (string.IsNullOrEmpty(trendyolAttribute.Name) ? DBNull.Value : (object)trendyolAttribute.Name));
                    sqlCommand.Parameters.AddWithValue("@displayName", (string.IsNullOrEmpty(trendyolAttribute.DisplayName) ? DBNull.Value : (object)trendyolAttribute.DisplayName));
                    sqlCommand.Parameters.AddWithValue("@attributeid", trendyolAttribute.Attributeid);
                    sqlCommand.Parameters.AddWithValue("@attributename", (string.IsNullOrEmpty(trendyolAttribute.Attributename) ? DBNull.Value : (object)trendyolAttribute.Attributename));

                    sqlCommand.Parameters.AddWithValue("@allowCustom", trendyolAttribute.AllowCustom);
                    sqlCommand.Parameters.AddWithValue("@required", trendyolAttribute.Required);
                    sqlCommand.Parameters.AddWithValue("@slicer", trendyolAttribute.Slicer);
                    sqlCommand.Parameters.AddWithValue("@varianter", trendyolAttribute.Varianter);



                    trendyolAttribute.Id = (int)sqlCommand.ExecuteScalar();

                }

                if (trendyolAttribute.TrendyolAttributes != null)
                {
                    using (SqlCommand sqlCommand = connection.CreateCommand())
                    {
                        sqlCommand.CommandText = "DELETE FROM TrendyolAttributeValue WHERE TrendyolAttributeId=" + trendyolAttribute.Id;
                        sqlCommand.ExecuteNonQuery();
                    }

                    foreach (var attributeValue in trendyolAttribute.TrendyolAttributes)
                    {
                        using (SqlCommand sqlCommand = connection.CreateCommand())
                        {
                            sqlCommand.CommandText = "pSaveTrendyolAttributeValue";
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@TrendyolAttributeId", trendyolAttribute.Id);
                            sqlCommand.Parameters.AddWithValue("@AttributeValue", attributeValue.AttributeValue);
                            sqlCommand.Parameters.AddWithValue("@AttributeText", (string.IsNullOrEmpty(attributeValue.AttributeText) ? DBNull.Value : (object)attributeValue.AttributeText));

                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

    }
}
