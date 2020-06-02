using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class ShareType
    {
        public ShareType()
        {

        }
        public ShareType(int id,string name, ShareSize size)
        {
            this.Id = id;
            Name = name;
            ShareSize = size;
        }
        public int Id { get; set; }

        public string SosialMediaName { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
        public ShareSize ShareSize { get; set; }

    }

    public class ShareSize
    {
        public int With { get; set; }
        public int Heigth { get; set; }

    }

    public class ShareTypesTemplate
    {
        public int Id { get; set; }
        public int ShareTypeId { get; set; }
        public string FileName { get; set; }
        public string SampleFileName { get; set; }

        public string AnnotationFile { get; set; }

        public DateTime LastUpdateDate { get; set; }



    }
}
