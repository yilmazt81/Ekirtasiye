using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class ShopCreateImage
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ShopName { get; set; }

        public string PictureRemotePath { get; set; }

    }
}
