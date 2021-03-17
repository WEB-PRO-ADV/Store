using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.ValueObject
{
    public class SupplierCategoryValueObject
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Specifications")]
        public List<string> Specifications { get; set; }
    }
}
