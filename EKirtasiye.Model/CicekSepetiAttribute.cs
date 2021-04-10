﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EKirtasiye.Model
{
    public class CicekSepetiAttribute
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public int Attributeid { get; set; }
        public string Attributename { get; set; }
        public bool AllowCustom { get; set; }
        public bool Required { get; set; }
        public bool Slicer { get; set; }
        public bool Varianter { get; set; }

        public CicekSepetiAttributeValue[] AttributeValues { get; set; }

    }
}