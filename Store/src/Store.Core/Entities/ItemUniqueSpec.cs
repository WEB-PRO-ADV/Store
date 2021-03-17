using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class ItemUniqueSpec : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Value is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Value")]
        public string Value { set; get; }
        public int ItemId { set; get; }
        public Item Item { set; get; }
    }
}
