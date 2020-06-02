using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp.Class
{
    public class CerenProduct
    {
        public bool result { get; set; }
        public Data data { get; set; }
    }



    public class Data
    {
        [JsonProperty("a")]
        public string Id { get; set; }
        [JsonProperty("b")]
        public string StockCode { get; set; }
        [JsonProperty("c")]
        public string ProductName { get; set; }
        [JsonProperty("d")]
        public int MinAdet { get; set; }
        [JsonProperty("e")]
        public int BoxInsideCount { get; set; }
        [JsonProperty("f")]
        public StokDurum[] StokDurumu { get; set; }
        [JsonProperty("g")]
        public string BurutFiyat { get; set; }
        [JsonProperty("h")]
        public string Iskonto { get; set; }
        [JsonProperty("i")]
        public string Kdv { get; set; }
        [JsonProperty("j")]
        public string NetFiyat { get; set; }

        [JsonProperty("k")]
        public DigerFiyatlar[] DigerFiyatlars { get; set; }
        [JsonProperty("l")]
        public string MinumumBirim { get; set; }
        [JsonProperty("m")]
        public string MinimumAdet { get; set; }
        [JsonProperty("n")]
        public UrunBarkod[] Barkodlar { get; set; }
        [JsonProperty("o")]
        public UrunKategory[] UrunKategorys { get; set; }
        //public object[] p { get; set; }
        [JsonProperty("r")]
        public string ParaBirimi { get; set; }
        [JsonProperty("s")]
        public UrunResim[] UrunResimleri { get; set; }

        [JsonProperty("z")]
        public UrunOzellik[] UrunOzellikleri { get; set; }
        /* public string t { get; set; }
         public bool u { get; set; }
         public string v { get; set; }
         public string y { get; set; }
         public Z[] z { get; set; }
         public A1[] a1 { get; set; }
         public string a2 { get; set; }
         public string a3 { get; set; }
         public object[] b1 { get; set; }
         public B2 b2 { get; set; }
         public object[] c0 { get; set; }
         public string c1 { get; set; }
         public string c2 { get; set; }
         public C3 c3 { get; set; }
         public C4 c4 { get; set; }
         public string d0 { get; set; }
         public string d1 { get; set; }
         public string d2 { get; set; }
         public object[] d3 { get; set; }
         public object[] d4 { get; set; }
         public string d5 { get; set; }
         public bool d6 { get; set; }
         */
    }
    public class StokDurum
    {
        [JsonProperty("a")]
        public string StorageName { get; set; }

        [JsonProperty("b")]
        public string StokState { get; set; }

        [JsonProperty("c")]
        public string ColorCode { get; set; }
    }

    public class UrunResim
    {
        [JsonProperty("a")]
        public string DosyaAdi { get; set; }

        [JsonProperty("b")]
        public string DosyaSira { get; set; }

    }
    public class DigerFiyatlar
    {
        [JsonProperty("a")]
        public int MinAlimMiktari { get; set; }

        [JsonProperty("b")]
        public string StokTuru { get; set; }
        [JsonProperty("c")]
        public int Adet { get; set; }
        [JsonProperty("d")]
        public bool StokDurumu { get; set; }
        [JsonProperty("e")]
        public string BirimFiyat { get; set; }
        [JsonProperty("f")]
        public string KdvDahilFiyat { get; set; }
    }
    public class UrunOzellik
    {
        [JsonProperty("a")]
        public string OzellikAdi { get; set; }
        [JsonProperty("b")]
        public string Ozellik { get; set; }
        [JsonProperty("c")]
        public string Aktif { get; set; }
    }
    public class UrunBarkod
    {
        [JsonProperty("a")]
        public string Barkod { get; set; }

        [JsonProperty("b")]
        public string StokTuru { get; set; }
    }

    public class UrunKategory
    {
        [JsonProperty("a")]
        public string KategoryAdi { get; set; }
        [JsonProperty("b")]
        public string KategoryUrl { get; set; }
    }
    public class B2
    {
        public TL TL { get; set; }
        public USD USD { get; set; }
        public EUR EUR { get; set; }
    }

    public class TL
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class USD
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class EUR
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class C3
    {
        public TL1 TL { get; set; }
        public USD1 USD { get; set; }
        public EUR1 EUR { get; set; }
    }

    public class TL1
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class USD1
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class EUR1
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class C4
    {
        public TL2 TL { get; set; }
        public USD2 USD { get; set; }
        public EUR2 EUR { get; set; }
    }

    public class TL2
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class USD2
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }

    public class EUR2
    {
        public string net_price { get; set; }
        public float net_price_raw { get; set; }
        public string tax_rate { get; set; }
        public string tax_amount { get; set; }
        public float tax_amount_raw { get; set; }
        public string purchase_price { get; set; }
        public float purchase_price_raw { get; set; }
    }









  

    public class A1
    {
        public string a { get; set; }
        public string b { get; set; }
        public string c { get; set; }
    }

}
