using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.N11
{
    public class ProductSaleService
    {

        private string _appKey, _appSecret = string.Empty;
        ProductSellingService.ProductSellingServicePortService productSellingService = null;
        public ProductSaleService(string appKey, string appSecret)
        {
            productSellingService = new ProductSellingService.ProductSellingServicePortService();
            _appKey = appKey;
            _appSecret = appSecret;
        }

        public ProductSellingService.Authentication GetAuthentication()
        {
            return new ProductSellingService.Authentication()
            {
                appKey = _appKey,
                appSecret = _appSecret
            };
        }
        public bool DisableProduct(long productId)
        {
            var productUpdateReturn = productSellingService.StopSellingProductByProductId(new ProductSellingService.StopSellingProductByProductIdRequest()
            {
                auth = GetAuthentication(),
                productId = productId
            });
            return productUpdateReturn.result.status == "success";
        }

        public bool DisableProduct(string sellerCode)
        {
            var productUpdateReturn = productSellingService.StopSellingProductBySellerCode(new ProductSellingService.StopSellingProductBySellerCodeRequest()
            {
                auth = GetAuthentication(),
                productSellerCode = sellerCode
            });
            return productUpdateReturn.result.status == "success";
        }

        public bool StartProduct(long productId)
        {
            var productUpdateReturn = productSellingService.StartSellingProductByProductId(new ProductSellingService.StartSellingProductByProductIdRequest()
            {
                auth = GetAuthentication(),
                productId = productId
            });
            return productUpdateReturn.result.status == "success";
        }

        public bool StartProduct(string sellerCode)
        {
            var productUpdateReturn = productSellingService.StartSellingProductBySellerCode(new ProductSellingService.StartSellingProductBySellerCodeRequest()
            {
                auth = GetAuthentication(),
                productSellerCode = sellerCode
            });
            return productUpdateReturn.result.status == "success";
        }
    }
}
