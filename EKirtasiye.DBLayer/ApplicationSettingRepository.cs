using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.DBLayer
{
    public static class ApplicationSettingRepository
    {
        public static void SaveSetting(ApplicationSetting appSetting)
        {
            DBHelper.ExecuteCommand("pSaveApplicationSetting", new System.Data.SqlClient.SqlParameter[] {
                new System.Data.SqlClient.SqlParameter("@SectionName",appSetting.SectionName),
                new System.Data.SqlClient.SqlParameter("@SettingName",appSetting.SettingName),
                new System.Data.SqlClient.SqlParameter("@SettingValue",appSetting.SettingValue)
            });
        }

        public static ApplicationSetting GetApplication(string sectionName, string settingName)
        {

            using (var connection = DBHelper.GetOpenConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "pGetApplicationSetting";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SectionName", sectionName);
                    command.Parameters.AddWithValue("@SecttingName", settingName);
                    var value = command.ExecuteScalar();

                    return (value == null ? null : new ApplicationSetting()
                    {
                        SettingValue= value.ToString(),
                        SectionName=sectionName,
                        SettingName= settingName
                    });
                }
            }
        }
    }
}
