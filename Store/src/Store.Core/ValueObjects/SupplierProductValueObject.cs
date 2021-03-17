using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.ValueObject
{
    public class SupplierProductValueObject
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Code")]
        public string Code { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image")]
        public string ImgUrl { get; set; }
        [Display(Name = "Factory")]
        public string Factory { get; set; }
        [Display(Name = "Cateory")]
        public string Category { get; set; }
        public bool IsAdded { get; set; }

        public List<SupplierSpecificationValueObject> Specifications { get; set; }
    }
}
