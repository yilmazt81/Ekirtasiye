using EKirtasiye.DBLayer;
using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EKirtasiyeRestApi.Controllers
{
    [RoutePrefix("api/IdeaCatalog")]
    public class IdeaCatalogController : ApiController
    {

        public IdeaCatalogController()
        {
            DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        }
        // GET: api/IdeaCatalog
        public IEnumerable<IdeaCatalog> Get()
        {
            return IdeaCatalogRepository.FilterCatalog(new DocumentFilterRequest());
        }
        // GET: api/IdeaCatalog/5
        [Route("getProductWebWithStatus")]
        [HttpPost]
        public List<IdeaCatalog> GetProductWebWithStatus(DocumentFilterRequest documentFilterRequest)
        {
            try
            {
                return IdeaCatalogRepository.FilterCatalog(documentFilterRequest);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Route("GetIdeaCatalogFromBarcode/{barcode}/{getBackup}")]
        public IdeaCatalog GetIdeaCatalogFromBarcode(string barcode, bool getBackup)
        {
            return IdeaCatalogRepository.GetIdeaCatalogFromBarcode(barcode, getBackup);
        }

        [HttpGet]
        [Route("GetIdeaExportTargets")]
        public IdeaExportTarget[] GetIdeaExportTargets()
        {
            return IdeaCatalogRepository.GetIdeaExportTargets();
        }
        [HttpGet]
        [Route("getwebexportstatus")]
        public IEnumerable<string> GetWebExportStatus()
        {
            return IdeaCatalogRepository.GetWebExportStatus();
        }

        [HttpGet]
        [Route("GetStokSourceStatus")]
        public IEnumerable<string> GetStokSourceStatus()
        {
            return IdeaCatalogRepository.GetStockSource();
        }

        [HttpGet]
        [Route("GetUpdatedExportCatalog/{exportTargetId}")]
        public IdeaCatalog[] GetUpdatedExportCatalog(int exportTargetId)
        {
            return IdeaCatalogRepository.GetUpdatedExportCatalog(exportTargetId).ToArray();
        }

        [HttpPost]
        [Route("UpdateProductCategory")]
        public void UpdateProductCategory(UpdateProductGroupRequest updateProductGroupRequest)
        {
            foreach (var productId in updateProductGroupRequest.ProductIdList)
            {

                IdeaCatalogRepository.UpdateCategoryId(productId, updateProductGroupRequest.MainCategoryId, updateProductGroupRequest.CategoryId, updateProductGroupRequest.SubCategoryId);

            }
        }

        [HttpPost]
        [Route("UpdateProductPrice")]
        public void UpdateProductPrice(UpdateProductPriceRequest updateProductPriceRequest)
        {
            IdeaCatalogRepository.UpdateProductPrice(updateProductPriceRequest.ProductId, updateProductPriceRequest.WebPrice);

        }

        [HttpPost]
        [Route("UpdateProductPictures")]
        public void UpdateProductPictures(UpdateProductPictureRequest updateProductPicture)
        {
            IdeaCatalogRepository.UpdateProductPictures(updateProductPicture);

        }
        [HttpPost]
        [Route("UpdateProductWebExportStatus")]
        public void UpdateProductWebExportStatus(UpdateProductStatusRequest updateProductStatus)
        {
            foreach (var catalog in updateProductStatus.ProductIdList)
            {
                IdeaCatalogRepository.UpdateWebExportState(catalog.Id, updateProductStatus.WebStatus);
            }
        }

        [HttpPost]
        [Route("addproducttoshopexport")]
        public string AddProductToShopExport(AddProductToShopExportRequest addProduct)
        {
            try
            {
                IdeaCatalogRepository.AddProductToShopExport(addProduct.ProductId);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("SaveProductWebResult")]
        public void SaveProductWebResult(List<ProductWebSearchResult> productWebSearchResults)
        {
            foreach (ProductWebSearchResult productWeb in productWebSearchResults)
            {
                IdeaCatalogRepository.SaveProductWebSearchResult(productWeb);
            }
        }
        // POST: api/IdeaCatalog
        public void Post(IdeaCatalog value)
        {
            try
            {
                IdeaCatalogRepository.InsertIdeaCatalog(value);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("exportexternalshop/{shopName}")]
        public IdeaCatalog[] GetExportExternalShopExportProducts(string shopName)
        {

            return IdeaCatalogRepository.GetExportExternalShopExportProducts(shopName).ToArray();
        }

        [HttpPost]
        [Route("exportexternalshop/UpdateProductShop")]
        public string UpdateProductShop(UpdateProductShopRequest updateProductShopRequest)
        {
            try
            {
                IdeaCatalogRepository.UpdateProductShopId(updateProductShopRequest.Id, updateProductShopRequest.ProductId, updateProductShopRequest.ShopName, updateProductShopRequest.Exported, updateProductShopRequest.ShopPrice);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Route("SaveLastProductExportProperty")]
        public string SaveLastProductExportProperty(LastProductExportProperty lastProductExport)
        {
            try
            {
                IdeaCatalogRepository.SaveLastProductExportProperty(lastProductExport);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        [HttpPost]
        [Route("exportexternalshop/UpdateShopProductState")]
        public string UpdateShopProductState(UpdateProductShopSaleRequest updateProductShopRequest)
        {
            try
            {
                IdeaCatalogRepository.UpdateShopProductState(updateProductShopRequest.Id, updateProductShopRequest.ShopName, updateProductShopRequest.ApprovalStatus);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
