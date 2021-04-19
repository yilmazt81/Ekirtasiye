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
    public class CicekSepetiCategoryRepository
    {

        public static void SaveCategory(CicekSepetiCategory nCategory)
        {
            DBHelper.ExecuteCommand("pSaveCicekSepetiCategory", new SqlParameter[]
            {
                new SqlParameter("@Id",nCategory.Id),
                new SqlParameter("@ParentCategoryId",nCategory.ParentCategoryId),
                new SqlParameter("@Name",nCategory.Name),

            });
        }

        public static List<CicekSepetiAttribute> GetCicekSepetiAttributes(int categoryId)
        {
            var dataAttributes = DBHelper.GetQuery($"SELECT   * FROM  CicekSepetiAttribute  WHERE CategoryId={categoryId}");

            return dataAttributes.Rows.Cast<DataRow>().Select(row => new CicekSepetiAttribute()
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
                AttributeValues = GetTrendyolAttributeValues(Convert.ToInt32(row["Id"]))
            }).ToList();

        }

        public static CicekSepetiAttributeValue[] GetTrendyolAttributeValues(int attributeId)
        {
            var dataAttributes = DBHelper.GetQuery($"SELECT   * FROM  CicekSepetiAttributeValue  WHERE AttributeId={attributeId}");

            return dataAttributes.Rows.Cast<DataRow>().Select(row => new CicekSepetiAttributeValue()
            {
                AttributeValue = row["AttributeValue"].ToString(),
                AttributeText = row["AttributeText"].ToString(),
                AttributeId = Convert.ToInt32(row["AttributeId"])
            }).ToArray();

        }

        public static CicekSepetiCategoryDefaultAttribute GetDefaultAttribute(int categoryId, int attributeId)
        {
            var datadefaultAttribute = DBHelper.GetQuery($"SELECT * FROM CicekSepetiCategoryDefaultAttribute WHERE CategoryId={categoryId} AND AttributeId={attributeId}");

            return (datadefaultAttribute.Rows.Count == 0 ? null : new CicekSepetiCategoryDefaultAttribute()
            {
                AttributeId = Convert.ToInt32(datadefaultAttribute.Rows[0]["AttributeId"]),
                AttributeName = datadefaultAttribute.Rows[0]["AttributeName"].ToString(),
                AttributeValue = Convert.ToInt32(datadefaultAttribute.Rows[0]["AttributeValue"]),
                CategoryId = Convert.ToInt32(datadefaultAttribute.Rows[0]["CategoryId"]),
                Id = Convert.ToInt32(datadefaultAttribute.Rows[0]["Id"]),
                AttributeValueText = datadefaultAttribute.Rows[0]["AttributeValueText"].ToString()
            });
        }

        public static List<CicekSepetiCategoryDefaultAttribute> GetCategoryDefaultAttributes(int categoryId)
        {
            var datadefaultAttribute = DBHelper.GetQuery($"SELECT * FROM CicekSepetiCategoryDefaultAttribute WHERE CategoryId={categoryId}  ");


            return datadefaultAttribute.Rows.Cast<DataRow>().Select(row => new CicekSepetiCategoryDefaultAttribute()
            {
                AttributeId = Convert.ToInt32(row["AttributeId"]),
                AttributeName = row["AttributeName"].ToString(),
                AttributeValue = Convert.ToInt32(row["AttributeValue"]),
                CategoryId = Convert.ToInt32(row["CategoryId"]),
                Id = Convert.ToInt32(row["Id"]),
                AttributeValueText = row["AttributeValueText"].ToString()

            }).ToList();

        }

        public static bool SaveCategoryDefaultAttribute(List<CicekSepetiCategoryDefaultAttribute> trendyolCategoryDefaultAttributes)
        {
            var categoryId = trendyolCategoryDefaultAttributes.FirstOrDefault().CategoryId;
            DBHelper.ExecuteCommand($"DELETE FROM  CicekSepetiCategoryDefaultAttribute WHERE CategoryId={categoryId}");
            foreach (var defaultAttribute in trendyolCategoryDefaultAttributes.Where(s => s.AttributeValue != 0))
            {


                DBHelper.ExecuteCommand("pSaveCicekSepetiDefaultAttribute", new SqlParameter[] {
                new SqlParameter("@CategoryId",defaultAttribute.CategoryId),
                new SqlParameter("@AttributeId",defaultAttribute.AttributeId),
                new SqlParameter("@AttributeName",defaultAttribute.AttributeName),
                new SqlParameter("@AttributeValue",defaultAttribute.AttributeValue),
                new SqlParameter("@AttributeValueText",defaultAttribute.AttributeValueText)
                });

            }
            return true;
        }


        public static bool SaveCreateRequest(CicekSepetiCreateRequest Create)
        {
            DBHelper.ExecuteCommand("pSaveCicekSepetiCreateRequest", new SqlParameter[]
            {
                new SqlParameter("@ProductId",Create.ProductId),
                new SqlParameter("@BatchRequest",Create.BatchRequest),
                new SqlParameter("@RequestType",Create.RequestType),
                new SqlParameter("@RequestStatus",(string.IsNullOrEmpty(Create.RequestStatus)?DBNull.Value:(object)Create.RequestStatus)),
                new SqlParameter("@ErrorMessage",(string.IsNullOrEmpty(Create.ErrorMessages)?DBNull.Value:(object)Create.ErrorMessages)),

            });

            return true;
        }

        public static List<CicekSepetiCategory> GetCategory()
        {

            var dtCategory = DBHelper.GetQuery("SELECT * FROM  CicekSepetiCategory");
            List<CicekSepetiCategory> nCategories = dtCategory.Rows.Cast<DataRow>().Select(s => new CicekSepetiCategory()
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s["Name"].ToString(),
                TargetCategory = (s["TargetCategory"] == DBNull.Value ? true : (bool)s["TargetCategory"]),
                ParentCategoryId = Convert.ToInt32(s["ParentCategoryId"])
            }).ToList();

            return nCategories;

        }

        public static List<CicekSepetiProductAttribute> GetCicekSepetiProductAttribute(int productId)
        {
            var dtProduct = DBHelper.GetQuery($"select * from CicekSepetiProductAttribute where ProductId={productId}");


            return dtProduct.Rows.Cast<DataRow>().Select(s => new CicekSepetiProductAttribute()
            {
                Id = Convert.ToInt32(s["Id"]),
                Attributeid = Convert.ToInt32(s["Attributeid"]),
                ProductId = Convert.ToInt32(s["ProductId"]),
                AttributeValue = Convert.ToInt32(s["AttributeValue"]),
                AttributeName = s["AttributeName"].ToString() 

            }).ToList();

        }


        public static void SaveCicekSepetiProductAttributes(List<CicekSepetiProductAttribute> cicekSepetiProductAttributes)
        {
            var firstAttribute = cicekSepetiProductAttributes.FirstOrDefault();
            DBHelper.ExecuteCommand($"DELETE FROM CicekSepetiProductAttribute WHERE ProductId={firstAttribute.ProductId}");

            foreach (var trendyolProductAttribute in cicekSepetiProductAttributes)
            {

                DBHelper.ExecuteCommand("pSaveCicekSepetiProductAttribute", new SqlParameter[]
                {
                    new SqlParameter("@ProductId",trendyolProductAttribute.ProductId),
                    new SqlParameter("@Attributeid",trendyolProductAttribute.Attributeid),
                    new SqlParameter("@AttributeName",trendyolProductAttribute.AttributeName),
                    new SqlParameter("@AttributeValue",trendyolProductAttribute.AttributeValue),
                    new SqlParameter("@AttributeCustomeValue",(string.IsNullOrEmpty(trendyolProductAttribute.AttributeCustomeValue)?DBNull.Value:(object)trendyolProductAttribute.AttributeCustomeValue))

                });
            }
        }
        /*
        public static bool SaveTrendyolCreateRequest(TrendyolCreateRequest trendyolCreate)
        {
            DBHelper.ExecuteCommand("pSaveTrendyolCreateRequest", new SqlParameter[]
            {
                new SqlParameter("@ProductId",trendyolCreate.ProductId),
                new SqlParameter("@BatchRequest",trendyolCreate.BatchRequest),
                new SqlParameter("@RequestType",trendyolCreate.RequestType)
            });

            return true;
        }*/
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
            DBHelper.ExecuteCommand($"DELETE FROM CicekSepetiProductAttribute WHERE ProductId={firstAttribute.ProductId}");

            foreach (var trendyolProductAttribute in trendyolProductAttributes)
            {

                DBHelper.ExecuteCommand("pSaveCicekSepetiProductAttribute", new SqlParameter[]
                {
                    new SqlParameter("@ProductId",trendyolProductAttribute.ProductId),
                    new SqlParameter("@Attributeid",trendyolProductAttribute.Attributeid),
                    new SqlParameter("@AttributeName",trendyolProductAttribute.AttributeName),
                    new SqlParameter("@AttributeValue",trendyolProductAttribute.AttributeValue),
                    new SqlParameter("@AttributeCustomeValue",(string.IsNullOrEmpty(trendyolProductAttribute.AttributeCustomeValue)?DBNull.Value:(object)trendyolProductAttribute.AttributeCustomeValue))

                });
            }
        }


        public static CicekSepetiCreateRequest[] GetCreateRequestList()
        {
            var dtRequest = DBHelper.GetQuery("SELECT * FROM CicekyolCreateRequest");

            return dtRequest.Rows.Cast<DataRow>().Select(s => new CicekSepetiCreateRequest()
            {
                BatchRequest = s["BatchRequest"].ToString(),
                Id = Convert.ToInt32(s["Id"]),
                ProductId = Convert.ToInt32(s["ProductId"]),
                RequestDate = (DateTime)s["RequestDate"],
                RequestType = s["RequestType"].ToString(),
                RequestStatus = s["RequestStatus"].ToString(),
                ErrorMessages = s["ErrorMessages"].ToString()
            }).ToArray();
        }
        public static void SaveCicekSepetiAttribute(CicekSepetiAttribute cicekSepetiAttribute)
        {
            using (SqlConnection connection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand sqlCommand = connection.CreateCommand())
                {
                    sqlCommand.CommandText = "pSaveCicekSepetiAttribute";
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", cicekSepetiAttribute.Id);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", cicekSepetiAttribute.CategoryId);

                    sqlCommand.Parameters.AddWithValue("@name", (string.IsNullOrEmpty(cicekSepetiAttribute.Name) ? DBNull.Value : (object)cicekSepetiAttribute.Name));
                    sqlCommand.Parameters.AddWithValue("@displayName", (string.IsNullOrEmpty(cicekSepetiAttribute.DisplayName) ? DBNull.Value : (object)cicekSepetiAttribute.DisplayName));
                    sqlCommand.Parameters.AddWithValue("@attributeid", cicekSepetiAttribute.Attributeid);
                    sqlCommand.Parameters.AddWithValue("@attributename", (string.IsNullOrEmpty(cicekSepetiAttribute.Attributename) ? DBNull.Value : (object)cicekSepetiAttribute.Attributename));

                    sqlCommand.Parameters.AddWithValue("@allowCustom", cicekSepetiAttribute.AllowCustom);
                    sqlCommand.Parameters.AddWithValue("@required", cicekSepetiAttribute.Required);
                    sqlCommand.Parameters.AddWithValue("@slicer", cicekSepetiAttribute.Slicer);
                    sqlCommand.Parameters.AddWithValue("@varianter", cicekSepetiAttribute.Varianter);


                    cicekSepetiAttribute.Id = (int)sqlCommand.ExecuteScalar();

                }

                if (cicekSepetiAttribute.AttributeValues != null)
                {
                    using (SqlCommand sqlCommand = connection.CreateCommand())
                    {
                        sqlCommand.CommandText = "DELETE FROM CicekSepetiAttributeValue WHERE AttributeId=" + cicekSepetiAttribute.Id;
                        sqlCommand.ExecuteNonQuery();
                    }

                    foreach (var attributeValue in cicekSepetiAttribute.AttributeValues)
                    {
                        using (SqlCommand sqlCommand = connection.CreateCommand())
                        {
                            sqlCommand.CommandText = "pSaveCicekSepetiAttributeValue";
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@AttributeId", cicekSepetiAttribute.Id);
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
