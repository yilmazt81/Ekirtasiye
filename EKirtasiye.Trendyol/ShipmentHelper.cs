using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class ShipmentHelper
    {
        HttpClient client = new HttpClient();

        string _endPoint = "";
        public ShipmentHelper(string endpoint)
        {
            _endPoint = "https://api.trendyol.com/sapigw/";
        }
        public TrendyolCargo[] GetShipMentCompany()
        {
            string serviceUrl = $"{_endPoint}shipment-providers";

            var result = client.GetAsync(serviceUrl).Result;
            TrendyolCargo[] trendyolCargos = null;
            if (result.IsSuccessStatusCode)
            {
                var str = result.Content.ReadAsStringAsync().Result;
                trendyolCargos = JsonConvert.DeserializeObject<TrendyolCargo[]>(str);
            }

            return trendyolCargos;
        }
    }
}
