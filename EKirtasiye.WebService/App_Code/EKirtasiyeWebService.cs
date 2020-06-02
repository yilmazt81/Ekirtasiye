using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EKirtasiye.DBLayer;

/// <summary>
/// Summary description for EKirtasiyeWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class EKirtasiyeWebService : System.Web.Services.WebService
{

    public EKirtasiyeWebService()
    {
        DBHelper.SqlConnectionStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public bool OpenConnection()
    {
        try
        {
            DBHelper.GetOpenConnection();

            return true;
        }
        catch (Exception ex)
        {

            return false;
        }
    }

    [WebMethod]
    public List<ProductCategory> GetProductCategories()
    {       

        return ProductCategoryRepository.GetProductCategories();
    }

    [WebMethod]
    public List<ProductCategory> GetProductCategoriesByUpId(int upId)
    {
        return ProductCategoryRepository.GetProductCategories(upId);
    }

    [WebMethod]
    public List<IdeaCatalogCategoryMatch> GetIdeaCatalogCategoryMatches()
    {

        return ProductCategoryRepository.GetIdeaCatalogCategoryMatches();
    }

    [WebMethod]
    public int InsertCategory(ProductCategory productCategory)
    {
        ProductCategoryRepository.InsertCategory(productCategory);

        return productCategory.Id;
    }

    [WebMethod]
    public void InsertIdeaCatalog (IdeaCatalog ideaCatalog)
    {
        IdeaCatalogRepository.InsertIdeaCatalog(ideaCatalog);
    }
       
    [WebMethod]
    public List<string>  GetWebExportStatus()
    {
       return IdeaCatalogRepository.GetWebExportStatus();
    }

    [WebMethod]
    public List<IdeaCatalog> FilterCatalog(string webExportState)
    {
      return  IdeaCatalogRepository.FilterCatalog(webExportState);
    }

    [WebMethod]
    public IdeaCatalog GetIdeaCatalogFromBarcode(string barcode, bool getFromBackup  )
    {
       return IdeaCatalogRepository.GetIdeaCatalogFromBarcode(barcode, getFromBackup);
    }



}
