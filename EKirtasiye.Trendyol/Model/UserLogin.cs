using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKirtasiye.Trendyol
{
    class UserLogin
    {
        public string email { get; set; }
        public string password { get; set; }

    }

    class LoginReturn
    {

        public string refreshToken { get; set; }
        public string token { get; set; }
    }
}
