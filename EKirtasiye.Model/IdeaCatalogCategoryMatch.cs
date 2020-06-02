using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
    public class IdeaCatalogCategoryMatch
    {

        public int Id { get; set; }
        public string ColumnName { get; set; }
        public string ImportName { get; set; }
        public int MainCategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int SubSubCategoryId { get; set; }
        public string SelectedFullName { get; set; }


    }
 