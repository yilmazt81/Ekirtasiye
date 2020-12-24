using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class LastProductExportProperty
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int IdeaExportTargetId { get; set; }

        public string ProductPrice { get; set; }

        public bool ProductState { get; set; }

        public string PicturePath1 { get; set; }

        public string PicturePath2 { get; set; }
        public string PicturePath3 { get; set; }
        public string PicturePath4 { get; set; }

    }
}
