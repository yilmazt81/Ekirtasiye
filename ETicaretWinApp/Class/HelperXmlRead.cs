using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace ETicaretWinApp
{
    public static class HelperXmlRead
    {


        static HelperXmlRead()
        {

        }
        public static List<MuhasebeDataGroup> ProductCategories(string xmlFilePath)
        {
            XDocument xDocument = XDocument.Load(xmlFilePath);
            var list = new List<MuhasebeDataGroup>();
            foreach (var oneElement in xDocument.Root.Elements())
            {
                var tip = oneElement.Element("TIP").Value;
                var name = oneElement.Element("IZAH").Value;

                list.Add(new MuhasebeDataGroup()
                {
                    TIP = tip,
                    Name = ConvertHtmlCodesToTurkish(name)
                });
            }
            return list;

        }

        private static List<MuhasebeDataBarkod> GetMuhasebeDataBarkods(string barkodXmlPath)
        {
            XDocument xDocument = XDocument.Load(barkodXmlPath);
            var list = new List<MuhasebeDataBarkod>();
            foreach (var oneElement in xDocument.Root.Elements())
            {


                list.Add(new MuhasebeDataBarkod()
                {
                    BARDOD = oneElement.Element("BARKOD").Value,
                    STOKKOD = oneElement.Element("STOKKOD").Value
                });
            }
            return list;
        }
        private static List<MuhasebeDataFiyat> GetMuhasebeDataFiyats(string stokFiyatXml)
        {
            XDocument xDocument = XDocument.Load(stokFiyatXml);

            var list = new List<MuhasebeDataFiyat>();

            foreach (var oneElement in xDocument.Root.Elements())
            {

                try
                {
                    list.Add(new MuhasebeDataFiyat()
                    {
                        STOKKOD = oneElement.Element("STOKKOD").Value,
                        ADI = (oneElement.Element("ADI") == null ? "" : ConvertHtmlCodesToTurkish(oneElement.Element("ADI").Value)),
                        BIRIMKOD = (oneElement.Element("BIRIMKOD") == null ? "" : oneElement.Element("BIRIMKOD").Value),
                        BOLUMID = (oneElement.Element("BOLUMID") == null ? "" : oneElement.Element("BOLUMID").Value),
                        DOVIZSEMBOL = oneElement.Element("DOVIZSEMBOL").Value,
                        FIYAT = oneElement.Element("FIYAT").Value,
                        KDVDAHIL = oneElement.Element("KDVDAHIL").Value

                    });
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            //var ss= list.Select(s => s.STOKKOD).Distinct().ToArray();

            return list;
        }
        public static List<MuhasebeDataStok> GetMuhasebeDataStoks(string xmlFilePath, string stokFiyatXml, string stokBarkodXml)
        {
            XDocument xDocument = XDocument.Load(xmlFilePath);
            var list = new List<MuhasebeDataStok>();

            var stokFiyatList = GetMuhasebeDataFiyats(stokFiyatXml);
            var stokBarkodList = GetMuhasebeDataBarkods(stokBarkodXml);

            foreach (var oneElement in xDocument.Root.Elements())
            {

                try
                {


                    var urun = new MuhasebeDataStok();

                    urun.ADI = ConvertHtmlCodesToTurkish(oneElement.Element("ADI").Value);
                    urun.BIRIMKOD1 = oneElement.Element("BIRIMKOD1").Value;
                    urun.KDVORAN = (oneElement.Element("KDVORAN") == null ? "18" : oneElement.Element("KDVORAN").Value);
                    urun.KOD = oneElement.Element("KOD").Value;
                    urun.EKTARIH = DateTime.Parse(oneElement.Element("EKTARIH").Value);
                    urun.KARTTIPI = oneElement.Element("KARTTIPI").Value;
                    urun.KDVPERAKENDEORAN = (oneElement.Element("KDVPERAKENDEORAN") == null ? "18" : oneElement.Element("KDVPERAKENDEORAN").Value);
                    urun.OZELGRUP1 = (oneElement.Element("OZELGRUP1") == null ? "" : oneElement.Element("OZELGRUP1").Value);
                    urun.OZELGRUP2 = (oneElement.Element("OZELGRUP2") == null ? "" : oneElement.Element("OZELGRUP2").Value);
                    urun.OZELGRUP3 = (oneElement.Element("OZELGRUP3") == null ? "" : oneElement.Element("OZELGRUP3").Value);
                    urun.KatalogDurumu = "Yeni";


                    var muhasebeSatisFiyat = stokFiyatList.LastOrDefault(s => s.STOKKOD == urun.KOD && s.ADI == "SATIŞ FİYATI");
                    var stokBarcode = stokBarkodList.Where(s => s.STOKKOD == urun.KOD).Select(s => s.BARDOD).ToArray();
                    if (muhasebeSatisFiyat != null)
                    {
                        urun.SATISFIYAT = muhasebeSatisFiyat.FIYAT;
                        urun.DOVIZSEMBOL = muhasebeSatisFiyat.DOVIZSEMBOL;
                    }
                    else
                    {
                        var fiyatlar = stokFiyatList.Where(s => s.STOKKOD == urun.KOD).ToArray();
                        if (fiyatlar.Length != 0)
                        {
                            Trace.WriteLine("Fiyat Yok");
                            urun.SATISFIYAT = fiyatlar.FirstOrDefault().FIYAT;
                            urun.DOVIZSEMBOL = fiyatlar.FirstOrDefault().DOVIZSEMBOL;
                        }
                        else
                        {
                            Trace.WriteLine("Fiyat Yok");
                        }

                    }
                    if (stokBarcode.Length == 1)
                    {
                        urun.BARKOD = stokBarcode[0];
                    }
                    else
                    {
                        if (stokBarcode.Length != 0)
                        {
                            urun.BARKOD = stokBarcode.FirstOrDefault();
                        }

                        Trace.WriteLine("Barkod yok");
                    }

                    if (!string.IsNullOrEmpty(urun.BARKOD))
                    {

                        var catalog = ApiHelper.GetIdeaCatalogFromBarcode(urun.BARKOD, false);
                        if (catalog == null)
                        {
                            /*catalog = ApiHelper.GetIdeaCatalogFromBarcode(urun.BARKOD, true);
                            if (catalog != null)
                            {
                                catalog.Id = 0;
                                urun.KatalogDurumu = "Backup";
                                urun.IdeaCatalog = catalog;

                            }*/
                        }
                        else
                        {
                            urun.IdeaCatalog = catalog;
                            urun.KatalogDurumu = "Var";
                        }
                    }
                    list.Add(urun);
                }
                catch (Exception ex)
                {

                    Trace.WriteLine(ex);
                }
            }
            return list;
        }

        public static string ConvertHtmlCodesToTurkish(string _str)
        {
            if (string.IsNullOrEmpty(_str))
                return string.Empty;

            string tmpStr = _str;
            tmpStr = tmpStr.Replace("&#304;", "İ");

            tmpStr = tmpStr.Replace("&#305;", "ı");
            tmpStr = tmpStr.Replace("&#214;", "Ö");

            tmpStr = tmpStr.Replace("&#246;", "ö");
            tmpStr = tmpStr.Replace("&#220;", "Ü");
            tmpStr = tmpStr.Replace("&#252;", "ü");

            tmpStr = tmpStr.Replace("&#199;", "Ç");
            tmpStr = tmpStr.Replace("&#19;", "Ç");
            tmpStr = tmpStr.Replace("&#231;", "ç");
            tmpStr = tmpStr.Replace("&#286;", "Ğ");
            tmpStr = tmpStr.Replace("&#287;", "ğ");
            tmpStr = tmpStr.Replace("&#350;", "Ş");
            tmpStr = tmpStr.Replace("&#351;", "ş");

            // Mustafa Karaköse 09.04.2013
            tmpStr = tmpStr.Replace("&#222;", "Ş");
            tmpStr = tmpStr.Replace("&#208;", "Ğ");

            //Turk yilmaz 04.02.2019
            tmpStr = tmpStr.Replace("&#x1;", "A");
            tmpStr = tmpStr.Replace("&#x2;", "B");
            tmpStr = tmpStr.Replace("&#x3;", "C");
            tmpStr = tmpStr.Replace("&#x4;", "D");
            tmpStr = tmpStr.Replace("&#x5;", "E");
            tmpStr = tmpStr.Replace("&#x6;", "F");
            tmpStr = tmpStr.Replace("&#x7;", "G");
            tmpStr = tmpStr.Replace("&#x10;", " ");
            tmpStr = tmpStr.Replace("&#xF;", "O");
            tmpStr = tmpStr.Replace("&#x12;", "R");
            tmpStr = tmpStr.Replace("&amp;", "&");



            return tmpStr;
        }
        private static string ConvertStokType(string strStok)
        {
            if (strStok == "ADT")
                return "Adet";
            if (strStok == "PKT")
                return "Paket";
            if (strStok == "KOLİ")
                return "Koli";

            if (string.IsNullOrEmpty(strStok))
            {
                return "Boş";
            }
            else
            {
                return "No";
            }

        }
        public static List<MuhasebeDataStok> ReadKadioglu(string xmlFilePath)
        {

            try
            {

                XDocument xDocument = XDocument.Load(xmlFilePath);
                List<MuhasebeDataStok> muhasebeDataStoks = new List<MuhasebeDataStok>();
                foreach (XElement element in xDocument.Root.Elements("Urun"))
                {
                    try
                    {
                        var barkod = element.Element("_BARKOD");
                        MuhasebeDataStok muhasebeDataStok = new MuhasebeDataStok();
                        muhasebeDataStok.KOD = "kk_" + element.Element("CODE").Value;
                        muhasebeDataStok.ADI = element.Element("NAME").Value;
                        muhasebeDataStok.OZELGRUP1 = element.Element("UST_KAT").Value;
                        muhasebeDataStok.OZELGRUP2 = element.Element("ORTA_KAT").Value;
                        muhasebeDataStok.OZELGRUP3 = element.Element("ALT_KAT").Value;
                        muhasebeDataStok.SATISFIYAT = element.Element("FIYAT_HAM").Value;
                        muhasebeDataStok.KDVORAN = element.Element("VAT").Value;
                        muhasebeDataStok.KDVPERAKENDEORAN = muhasebeDataStok.KDVORAN;
                        muhasebeDataStok.DOVIZSEMBOL = "TL";
                        muhasebeDataStok.KatalogDurumu = "Yeni";
                        muhasebeDataStok.KARTTIPI = "KK";
                        muhasebeDataStok.BIRIMKOD1 = ConvertStokType(element.Element("_BARKOD").Element("BIRIM_1_ADI").Value);
                        muhasebeDataStok.BARKOD = element.Element("_BARKOD").Element("BIRIM_1_BARCODE").Value;
                        muhasebeDataStok.Stok = element.Element("STOK").Value;
                        muhasebeDataStok.Ozellik = (element.Element("OZELLIK_1") != null ? element.Element("OZELLIK_1").Value : "") + "<br> " +
                            (element.Element("OZELLIK_2") != null ? element.Element("OZELLIK_2").Value : "") + "<br>" +
                            (element.Element("OZELLIK_3") != null ? element.Element("OZELLIK_3").Value : "");

                        if (!string.IsNullOrEmpty(muhasebeDataStok.BARKOD))
                        {

                            var catalog = ApiHelper.GetIdeaCatalogFromBarcode(muhasebeDataStok.BARKOD, false);
                            if (catalog == null)
                            {
                                muhasebeDataStok.IdeaCatalog = new IdeaCatalog()
                                {
                                    Picture1Path = element.Element("RESIM1").Value,
                                    Picture2Path = (element.Element("RESIM2") != null ? element.Element("RESIM2").Value : ""),
                                    Picture3Path = (element.Element("RESIM3") != null ? element.Element("RESIM3").Value : ""),
                                    Picture4Path = (element.Element("RESIM4") != null ? element.Element("RESIM4").Value : ""),

                                };
                                /*catalog = ApiHelper.GetIdeaCatalogFromBarcode(urun.BARKOD, true);
                                if (catalog != null)
                                {
                                    catalog.Id = 0;
                                    urun.KatalogDurumu = "Backup";
                                    urun.IdeaCatalog = catalog;

                                }*/
                            }
                            else
                            {
                                muhasebeDataStok.IdeaCatalog = catalog;
                                muhasebeDataStok.KatalogDurumu = "Var";
                            }
                        }
                        muhasebeDataStoks.Add(muhasebeDataStok);
                    }
                    catch (Exception ex)
                    {

                        Trace.WriteLine(ex);
                    }

                }

                return muhasebeDataStoks;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
        }
    }
}
