using EKirtasiye.N11.ProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.N11
{
    public class ProductHelper
    {
        ProductService.ProductServicePortService productServicePortClient = null;
        private string _appKey, _appSecret = string.Empty;

        public ProductHelper(string appKey, string appSecret)
        {
            productServicePortClient = new ProductService.ProductServicePortService();
       
            _appKey = appKey;
            _appSecret = appSecret;
        }
        private Authentication GetAuthentication()
        {

            var authentication = new Authentication();
            authentication.appKey = _appKey;//"fe4ac85a-ee00-473f-873a-7b5c9de9f4e8";
            authentication.appSecret = _appSecret;// "jbIVyopbNtA98kot";

            return authentication;
        }

        public bool DeleteProductBySellerCode(string productCode)
        {
            
            var deleteResult = productServicePortClient.DeleteProductBySellerCode(new DeleteProductBySellerCodeRequest() {
                auth = GetAuthentication(),
                productSellerCode= productCode
            });
            return deleteResult.result.status == "success";

        }

        public bool UpdateProductPrice(long productId, decimal price, string currencyType = "TL")
        {
            var productUpdateReturn = productServicePortClient.UpdateProductPriceById(new UpdateProductPriceByIdRequest()
            {
                auth = GetAuthentication(),
                currencyType = currencyType,
                price = price,
                productId = productId,

            });
            return productUpdateReturn.result.status == "success";
        }
        public bool UpdateProductPriceSellerCode(string sellerCode, decimal price, string currencyType = "TL")
        {
            var productUpdateReturn = productServicePortClient.UpdateProductPriceBySellerCode(new UpdateProductPriceBySellerCodeRequest()
            {
                auth = GetAuthentication(),
                currencyType = currencyType,
                price = price,
                productSellerCode = sellerCode,

            });
            return productUpdateReturn.result.status == "success";
        }

        public void SaveProduct(N11Product n11Product)
        {
            var requestItem = new SaveProductRequest()
            {
                auth = GetAuthentication(),
                product = new ProductRequest()
                {
                    approvalStatus = n11Product.approvalStatus,
                    itemName = n11Product.itemName,
                    preparingDay = n11Product.preparingDay,
                    price = n11Product.Price,
                    groupAttribute = n11Product.groupAttribute,
                    currencyType = n11Product.CurrencyType,
                    description = n11Product.Description,
                    domestic = n11Product.Domestic,
                    expirationDate = n11Product.expirationDate,
                    groupItemCode = n11Product.GroupItemCode,
                    title = n11Product.Title,
                    productCondition = n11Product.productCondition,
                    productSellerCode = n11Product.ProductSellerCode,
                    saleEndDate = n11Product.saleEndDate,
                    saleStartDate = n11Product.saleStartDate,
                    subtitle = n11Product.Subtitle,
                    productionDate = n11Product.productionDate,
                    attributes = (!string.IsNullOrEmpty(n11Product.ProductBrand) ? new ProductAttributeRequest[] { new ProductAttributeRequest() {
                       name="Marka",
                       value=n11Product.ProductBrand
                    }} : null),
                    shipmentTemplate = n11Product.shipmentTemplate,
                    images = n11Product.ProductImages.Select(s => new ProductImage() { order = s.Order.ToString(), url = s.Url }).ToArray(),
                    category = new CategoryRequest()
                    {
                        id = n11Product.CategoryId
                    },
                    stockItems = new ProductSkuRequest[]
                    {
                        new ProductSkuRequest()
                        {
                            quantity="10",
                            gtin=n11Product.Barcode,
                            sellerStockCode=n11Product.ProductSellerCode ,
                            optionPrice=n11Product.Price
                        }
                    }

                }
            };
            var saveResult = productServicePortClient.SaveProduct(requestItem);

            if (saveResult.result.status == "success")
            {
                n11Product.Id = saveResult.product.id;
            }
            else
            {
                throw new Exception(saveResult.result.errorMessage);
            }



        }
        public void GetProductBySellerCode(string productCode)
        {
            var resulst = productServicePortClient.GetProductBySellerCode(new GetProductBySellerCodeRequest()
            {
                auth = GetAuthentication(),
                sellerCode = productCode
            });


        }

        public List<N11Product> GetProductList(out int maxPage, int pageSize = 50, int currentPage = 1)
        {
            var proceductList = productServicePortClient.GetProductList(new GetProductListRequest()
            {
                auth = GetAuthentication(),
                pagingData = new RequestPagingData()
                {
                    pageSize = pageSize,
                    currentPage = currentPage
                }
            });

            if (proceductList.result.status != "success")
            {
                maxPage = 0;
                throw new Exception(proceductList.result.errorMessage);
            }
            var productListConvert = proceductList.products.Select(s => new N11Product()
            {
                Id = s.id,
                approvalStatus = s.approvalStatus,
                ProductSellerCode = s.productSellerCode,
                Title = s.title,
                Subtitle = s.title,
                Domestic = s.isDomestic,
                Price = s.price,

            }).ToList();
            maxPage = proceductList.pagingData.pageCount.Value;


            return productListConvert;
        }
    }
}
