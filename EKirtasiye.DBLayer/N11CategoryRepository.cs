using EKirtasiye.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.DBLayer
{
    public class N11CategoryRepository
    {

        public static void SaveCategory(N11Category n11Category)
        {
            DBHelper.ExecuteCommand("pSaveN11Category", new SqlParameter[]
            {
                new SqlParameter("@Id",n11Category.Id),
                new SqlParameter("@ParentCategoryId",n11Category.ParentCategoryId),
                new SqlParameter("@Name",n11Category.Name),

            });
        }

        public static List<N11Category> GetN11Category()
        {

            var dtCategory = DBHelper.GetQuery("SELECT * FROM  N11Category");
            List<N11Category> n11Categories = dtCategory.Rows.Cast<DataRow>().Select(s => new N11Category()
            {
                Id = Convert.ToInt32(s["Id"]),
                Name = s["Name"].ToString(),
                TargetCategory = (s["TargetCategory"] == DBNull.Value ? true : (bool)s["TargetCategory"]),
                ParentCategoryId = Convert.ToInt32(s["ParentCategoryId"])
            }).ToList();


            return n11Categories;



        }
    }
}
