using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class IdeaCatalog
{
    public IdeaCatalog()
    {
        Barcodes = new IdeaCatalog_Barcode[0];
        ProductPrices = new ProductPrice[0];
        ShopCreateImages = new ShopCreateImage[0];

    }
    public int Id { get; set; }
    public string StockCode { get; set; }

    public string Label { get; set; }
    public bool Status { get; set; }

    public string Brand { get; set; }
    public string MainCategory { get; set; }

    public string Web_MainCategory { get; set; }

    public int MainCategoryId { get; set; }
    public string Category { get; set; }
    public string Web_Category { get; set; }

    public int CategoryId { get; set; }
    public string SubCategory { get; set; }

    public string Web_SubCategory { get; set; }
    public int SubCategoryId { get; set; }
    public string RootProductStockCode { get; set; }

    public string WebPrice { get; set; }

    public string MarketPrice { get; set; }
    public string Price1 { get; set; }
    public string Price2 { get; set; }
    public string Price3 { get; set; }
    public string Price4 { get; set; }
    public string Price5 { get; set; }
    public string Tax { get; set; }
    public string CurrencyAbbr { get; set; }
    public int RebatePercent { get; set; }
    public int MoneyOrderPercent { get; set; }
    public int StockAmount { get; set; }
    public string StockType { get; set; }
    public string Warrant { get; set; }
    public string Picture1Path { get; set; }
    public string Picture2Path { get; set; }
    public string Picture3Path { get; set; }
    public string Picture4Path { get; set; }
    public int Dm3 { get; set; }
    public string Details { get; set; }
    public string Title { get; set; }
    public string Keywords { get; set; }
    public string Description { get; set; }
    public string ProductSource { get; set; }
    public string ProductUrl { get; set; }

    public string Barcode { get; set; }

    public string WebExportStatus { get; set; }

    public string LastEdited { get; set; }

    public DateTime LastEditedDate { get; set; }


    public string WebPrice_old { get; set; }

    public string MyProductUrl { get; set; }


    public string ApprovalStatus { get; set; }

    public int ApprovalStatusTrendYol { get; set; }

    public List<ProductAttribute> ProductAttributes { get; set; }

    public void AddAttribute(string name, string value)
    {
        var attrib = ProductAttributes.FirstOrDefault(s => s.AttributeName == name);
        if (attrib == null)
        {
            ProductAttributes.Add(new ProductAttribute() { AttributeName = name, AttributeValue = value });
        }
        else
        {
            attrib.AttributeValue = value;
        }
    }

    public string ReadAttribute(string name, string defaultValue="")
    {
        var attrib = ProductAttributes.FirstOrDefault(s => s.AttributeName == name);

        return (attrib == null ? defaultValue : attrib.AttributeValue);
    }


    public ShopCreateImage[] ShopCreateImages { get; set; }


    public string MimimumPrice {
        get {
            try
            {
                float price = 0;
                if (ProductSource == "Kadioglu")
                {

                    price = ((float.Parse(MarketPrice) * (float)1.18) * float.Parse("1,15") * float.Parse("1," + this.Tax));
                }
                else
                {

                    price = (float.Parse(MarketPrice) * float.Parse("1,15") * float.Parse("1," + this.Tax));
                }

                if (price > 150)
                {
                    price += 10;
                }
                return price.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
    public string MimimumSellerPrice {
        get {
            try
            {
                if (ProductSource == "Kadioglu")
                {

                    return ((float.Parse(MarketPrice) * 1.18) * float.Parse("1,30") * float.Parse("1," + this.Tax)).ToString();
                }
                else
                {

                    return (float.Parse(MarketPrice) * float.Parse("1,1") * float.Parse("1," + this.Tax)).ToString();
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }

    public IdeaCatalog_Barcode[] Barcodes { get; set; }

    public ProductPrice[] ProductPrices { get; set; }
    public Int64 N11ProductId { get; set; }

    public bool ExportN11 { get; set; }

    public DateTime LastStockCheckDate { get; set; }


}
