 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretWinApp
{
    public class MuhasebeDataGroup
    {

        public string TIP { get; set; }

        public string Name { get; set; }
        public override string ToString()
        {
            return TIP + " " + Name;
        }
    }

    public class MuhasebeDataFiyat
    {
        public string STOKKOD { get; set; }
        public string ADI { get; set; }

        public string BIRIMKOD { get; set; }

        public string FIYAT { get; set; }
        public string DOVIZSEMBOL { get; set; }

        public string KDVDAHIL { get; set; }

        public string BOLUMID { get; set; }


    }

    public class MuhasebeDataBarkod
    {

        public string STOKKOD { get; set; }
        public string BARDOD { get; set; }
    }
    public class MuhasebeDataStok
    {
        public string BARKOD { get; set; }
        public DateTime EKTARIH { get; set; }

        public string KARTTIPI { get; set; }

        public string KOD { get; set; }

        public string ADI { get; set; }

        public string KDVORAN { get; set; }

        public string KDVPERAKENDEORAN { get; set; }

        public string BIRIMKOD1 { get; set; }

        public string OZELGRUP1 { get; set; }
        public string OZELGRUP2 { get; set; }
        public string OZELGRUP3 { get; set; }

        public string SATISFIYAT { get; set; }

        public string DOVIZSEMBOL { get; set; }

        public string KatalogDurumu { get; set; }

        public string Ozellik { get; set; }
        public string Stok { get; set; }

        public IdeaCatalog IdeaCatalog { get; set; }



    }
}
