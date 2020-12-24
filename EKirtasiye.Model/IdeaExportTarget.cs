using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class IdeaExportTarget
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public bool ExcelExport { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
