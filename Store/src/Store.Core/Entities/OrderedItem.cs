using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class OrderedItem : BaseEntity
    {
        [Required(ErrorMessage = "Quantity are required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int Quantity { set; get; }
        public String ItemName { get; set; }
        public int OrderId { get; set; }
        public Order Order { set; get; }
    }
}
