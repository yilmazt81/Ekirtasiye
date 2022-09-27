using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    public class N11MagazamBrand
    {
        public N11MagazamBrand(string fullLine)
        {
           var array= fullLine.Split(',');

            Name = array[4].Replace('"',' ').Trim();
            Code = array[3].Replace('"', ' ').Trim();
        }
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
