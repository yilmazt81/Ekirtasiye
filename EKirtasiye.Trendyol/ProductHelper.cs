using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    public class ProductHelper
    {
        private string _supplierid, _userName,_password = string.Empty;
       
        public ProductHelper(string suplierId,string userName,string password)
        {
            _supplierid = suplierId;
            _userName = userName;
            _password = password;
        }

        public bool CreateProducts()
        {
            return true;
        }

    }
}
