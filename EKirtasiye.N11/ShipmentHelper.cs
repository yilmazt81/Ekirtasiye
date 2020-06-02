using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EKirtasiye.N11.ShipService;

namespace EKirtasiye.N11
{
    public class ShipmentHelper
    {

        private string _appKey, _appSecret = string.Empty;
        private ShipService.ShipmentServicePortService shipmentServicePortService = null;
        public ShipmentHelper(string appKey, string appSecret)
        {
            shipmentServicePortService = new ShipService.ShipmentServicePortService();
            _appKey = appKey;
            _appSecret = appSecret;

        }

        public Authentication ShipAuthentication =>
            new Authentication()
            {
                appKey = _appKey,
                appSecret = _appSecret
            };

        public N11ShipmentTemplate[] GetShipmentTemplateList()
        {
            var shipmentList = shipmentServicePortService.GetShipmentTemplateList(new GetShipmentTemplateListRequest()
            {

                auth = ShipAuthentication,
            });

           return shipmentList.shipmentTemplates.Select(s => new N11ShipmentTemplate()
            {
               Name=s.templateName,
               
            }).ToArray();
        }
    }
}
