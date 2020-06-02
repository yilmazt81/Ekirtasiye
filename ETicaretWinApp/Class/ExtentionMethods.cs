using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    public static class ApplicationSettingHelper
    {


        public static string ReadValue( string section, string key, string defaultValue = "")
        {

            var readV = LocalDBHelper.GetApplication(section, key);

            return (readV == null ? defaultValue : readV.SettingValue);

        }

        public static void AddValue( string section, string key, string value)
        {
            LocalDBHelper.SaveSetting(new AppSetting()
            {
                SectionName = section,
                SettingName = key,
                SettingValue = value
            });

        }
    }
}
