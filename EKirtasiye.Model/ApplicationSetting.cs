using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class ApplicationSetting
    {
        public int Id { get; set; }
        public string SectionName { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
