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
                TrendyolAttributes= GetTrendyolAttributeValues(Convert.ToInt32(row["Id"]))

            }).ToList();

        }

        public static TrendyolAttributeValue[] GetTrendyolAttributeValues(int attributeId)
        {
            var dataAttributes = DBHelper.GetQuery($"SELECT   * FROM  TrendyolAttributeValue  WHERE TrendyolAttributeId={attributeId}");

            return dataAttributes.Rows.Cast<DataRow>().Select(row => new TrendyolAttributeValue()
            {
                AttributeValue=Convert.ToInt32(row["AttributeValue"]),
                AttributeText=row["AttributeText"].ToString()

            }).ToArray();

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
