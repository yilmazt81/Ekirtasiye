﻿using EKirtasiye.Model;
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
    public string MimimumPrice {
        get {
            try
            {
                if (ProductSource == "Kadioglu")
                {

                    return ((float.Parse(MarketPrice) * 1.18) * float.Parse("1,30") * float.Parse("1," + this.Tax)).ToString();
                }
                else
                {

                    return (float.Parse(MarketPrice) * float.Parse("1,30") * float.Parse("1," + this.Tax)).ToString();
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