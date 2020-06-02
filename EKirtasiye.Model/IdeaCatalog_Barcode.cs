using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class IdeaCatalog_Barcode
{

    public int Id { get; set; }
    public int IdeaCatalogId { get; set; }

    public string Barcode { get; set; }
    public string StockType { get; set; }

}

public class ProductPrice
{
    public string Unit { get; set; }
    public int Amount { get; set; }

    public string Price { get; set; }

}

