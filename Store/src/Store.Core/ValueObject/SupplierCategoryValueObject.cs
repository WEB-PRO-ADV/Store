using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ValueObject
{
    class SupplierCategoryValueObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Specifications { get; set; }
    }
}
