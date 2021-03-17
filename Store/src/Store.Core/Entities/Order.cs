using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class Order : BaseEntity
    {
        [Required(ErrorMessage = "Details are required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Details")]
        public string Details { set; get; }
        [Required(ErrorMessage = "Status is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Status")]
        public string Status { set; get; }
        public int CustomerId { set; get; }
        public Customer Customer { set; get; }
        public ICollection<OrderedItems> OrderedItems { set; get; }
    }
}
