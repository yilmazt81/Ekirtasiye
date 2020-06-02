using LiteDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETicaretWinApp
{
    public class LocalDBHelper
    {
        private static LiteDatabase GetLiteDatabase()
        {
            return new LiteDatabase(Path.Combine(Application.StartupPath, "ApplicationDB.db"));
        }

        public static void SaveSetting(AppSetting appSetting)
        {
            using (var db = GetLiteDatabase())
            {
                var col = db.GetCollection<AppSetting>("AppSetting");
                var oneSetting = col.FindOne(s => s.SectionName == appSetting.SectionName && s.SettingName == appSetting.SettingName);
                if (oneSetting == null)
                {
                    col.Insert(appSetting);
                }
                else
                {
                    oneSetting.SettingValue = appSetting.SettingValue;
                    col.Update(oneSetting);
                }
            }
        }

        public static AppSetting GetApplication(string sectionName,string settingName)
        {
            using (var db = GetLiteDatabase())
            {
                var col = db.GetCollection<AppSetting>("AppSetting");
                var oneSetting = col.FindOne(s => s.SectionName == sectionName && s.SettingName == settingName);

                return oneSetting;
            }
        }

    }
}
