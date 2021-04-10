using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProductCategory
{


    public int Id { get; set; }
    public int UpId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryUrl { get; set; }
    public int HepsiBuradaCategoryId { get; set; }
    public string HepsiBuradaCategoryName { get; set; }
    public int N11CategoryId { get; set; }
    public string N11CategoryName { get; set; }

    public bool TargetCategory { get; set; }

    public string N11ExportTemplateName { get; set; }

    public int N11ExportTemplateId { get; set; }

    public string TrendyolCategoryName { get; set; }

    public int TrendyolCategoryId { get; set; }

    public int CicekSepetiCategoryId { get; set; }

    public string CicekSepetiCategoryName { get; set; }



    public override string ToString()
    {
        return CategoryName + " - " + CategoryUrl;
    }
}

