using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ValueObject
{
    class SupplierProductValueObject
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string Factory { get; set; }
        public string Category { get; set; }

        public List<SupplierSpecificationValueObject> Specifications { get; set; }
    }
}
