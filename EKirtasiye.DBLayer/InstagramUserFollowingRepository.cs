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
    public class InstagramUserFollowingRepository
    {

        public static void SaveInstagram(InstagramUserFollowing instagramUser)
        {
            using (SqlConnection sqlConnection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = sqlConnection.CreateCommand())
                {
                    scom.CommandText = "pSaveInstagramUserFollowing";
                    scom.CommandType = System.Data.CommandType.StoredProcedure;

                    scom.Parameters.AddWithValue("@UserPK", instagramUser.UserPK);
                    scom.Parameters.AddWithValue("@UserName", instagramUser.UserName);
                    scom.Parameters.AddWithValue("@ProfilePicture", instagramUser.ProfilePicture);
                    scom.Parameters.AddWithValue("@Fallower", instagramUser.Fallower);
                    scom.Parameters.AddWithValue("@Fallowing", instagramUser.Fallowing);


                    scom.ExecuteNonQuery();
                }
            }
        }

        public static List<InstagramUserFollowing> GetInstagramUserFollowing()
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "SELECT * FROM InstagramUserFollowing ";

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(scom);
                    sqlDataAdapter.Fill(dataTable);

                    List<InstagramUserFollowing> instagramUsers = new List<InstagramUserFollowing>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        instagramUsers.Add(ConvertToRow(row));
                    }

                    return instagramUsers;
                }
            }
        }

   

        private static InstagramUserFollowing ConvertToRow(DataRow dataRow)
        {
            return new InstagramUserFollowing()
            {
                Fallower = Convert.ToBoolean(dataRow["Fallower"]),
                Fallowing = Convert.ToBoolean(dataRow["Fallowing"]),
                Id = Convert.ToInt32(dataRow["Id"]),
                ProfilePicture = dataRow["ProfilePicture"].ToString(),
                UserName = dataRow["UserName"].ToString(),
                UserPK = dataRow["UserPK"].ToString()
            };
        }

        public static List<ShareType> GetShareTypes()
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "SELECT * FROM ShareTypes ";

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(scom);
                    sqlDataAdapter.Fill(dataTable);

                    List<ShareType> shareTypes = new List<ShareType>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var shareType = new ShareType()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Name = row["TypeName"].ToString(),
                            SosialMediaName = row["SosialMediaName"].ToString(),
                            ShareSize = new ShareSize()
                            {
                                Heigth = Convert.ToInt32(row["SizeHeight"]),
                                With = Convert.ToInt32(row["SizeWith"])
                            }
                        };
                        shareTypes.Add(shareType);
                    }

                    return shareTypes;
                }
            }
        }

        public static List<ShareTypesTemplate> GetShareTypesTemplates(int shareTypeId)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = $"SELECT * FROM  ShareTypesTemplate WHERE ShareTypeId={shareTypeId}";

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(scom);
                    sqlDataAdapter.Fill(dataTable);

                    List<ShareTypesTemplate> shareTypesTemplates = new List<ShareTypesTemplate>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        shareTypesTemplates.Add(ConvertToTemplate(row));
                    }
                    return shareTypesTemplates;
                }
            }
        }

        public static  ShareTypesTemplate  GetShareTypesTemplate(int id)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = $"SELECT * FROM  ShareTypesTemplate WHERE Id={id}";

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(scom);
                    sqlDataAdapter.Fill(dataTable);
                    DataRow row = dataTable.Rows[0];
                    

                    return ConvertToTemplate(row);
                }
            }
        }

        public static void SaveShareTypesTemplate(ShareTypesTemplate shareTypesTemplate)
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = "pSaveShareTypesTemplate";
                    scom.CommandType = CommandType.StoredProcedure;
                    scom.Parameters.AddWithValue("@Id", shareTypesTemplate.Id);
                    scom.Parameters.AddWithValue("@ShareTypeId", shareTypesTemplate.ShareTypeId);
                    scom.Parameters.AddWithValue("@FileName", shareTypesTemplate.FileName);
                    scom.Parameters.AddWithValue("@SampleFileName", (string.IsNullOrEmpty(shareTypesTemplate.SampleFileName) ? DBNull.Value : (object)shareTypesTemplate.SampleFileName));
                    scom.Parameters.AddWithValue("@AnnotationFile", (string.IsNullOrEmpty(shareTypesTemplate.AnnotationFile) ? DBNull.Value : (object)shareTypesTemplate.AnnotationFile));


                    shareTypesTemplate.Id = Convert.ToInt32(scom.ExecuteScalar());

                }
            }
        }


        public static List<ShareTypesTemplate> GetShareTypesTemplateLastUpdate()
        {
            using (SqlConnection scon = DBHelper.GetOpenConnection())
            {
                using (SqlCommand scom = scon.CreateCommand())
                {
                    scom.CommandText = $"SELECT * FROM  ShareTypesTemplate ";

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(scom);
                    sqlDataAdapter.Fill(dataTable);
                   

                    List<ShareTypesTemplate> shareTypesTemplates = new List<ShareTypesTemplate>();

                    foreach (DataRow row in dataTable.Rows)
                    {
                        shareTypesTemplates.Add(ConvertToTemplate(row));
                    }

                    return shareTypesTemplates;
                }
            }
        }

        private static ShareTypesTemplate ConvertToTemplate(DataRow row)
        {
            ShareTypesTemplate shareTypesTemplate = new ShareTypesTemplate()
            {
                FileName = row["FileName"].ToString(),
                Id = Convert.ToInt32(row["Id"]),
                SampleFileName = row["SampleFileName"].ToString(),
                ShareTypeId = Convert.ToInt32(row["ShareTypeId"]),
                LastUpdateDate=(DateTime)row["LastUpdateDate"],
                AnnotationFile=row["AnnotationFile"].ToString()
            };

            return shareTypesTemplate;
        }

    }
}
