using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class ItemCart : BaseEntity
    {
        public int ItemId { set; get; }
        [Required(ErrorMessage = "Quantity is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int Quantity { set; get; }
        public int CartId { set; get; }
        public Cart Cart { set; get; }
        public Item Item { set; get; }
    }
}
