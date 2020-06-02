using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.DBLayer
{
    public class HepsiBuradaCategoryRepository
    {

        public static List<HepsiBuradaCategory> GetHepsiBuradaCategories()
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = " SELECT* FROM HepsiBuradaCategory WHERE Status = 'ACTIVE' AND Available=1";
                    List<HepsiBuradaCategory> hepsiBuradaCategories = new List<HepsiBuradaCategory>();

                    using (SqlDataReader reader = scom.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            hepsiBuradaCategories.Add(new HepsiBuradaCategory()
                            {
                                Available = (bool)reader["Available"],
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                Leaf = (bool)reader["Leaf"],
                                Name = reader["Name"].ToString(),
                                ParentCategoryId = Convert.ToInt32(reader["ParentCategoryId"]),
                                Status = reader["Status"].ToString(),
                                TargetCategory=(bool)reader["TargetCategory"]
                            });
                        }
                    }

                    return hepsiBuradaCategories;
                }
            }
        }
        public static void SaveCategory(HepsiBuradaCategory hepsiBuradaCategory)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pSaveHepsiBuradaCategory";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@CategoryId", hepsiBuradaCategory.CategoryId);
                    scom.Parameters.AddWithValue("@Name", hepsiBuradaCategory.Name);
                    scom.Parameters.AddWithValue("@ParentCategoryId", hepsiBuradaCategory.ParentCategoryId);
                    scom.Parameters.AddWithValue("@Leaf", hepsiBuradaCategory.Leaf);
                    scom.Parameters.AddWithValue("@Status", hepsiBuradaCategory.Status);
                    scom.Parameters.AddWithValue("@Available", hepsiBuradaCategory.Available);
                    scom.ExecuteNonQuery();
                }
            }
        }
    }
}
