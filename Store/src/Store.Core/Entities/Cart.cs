using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class Cart : BaseEntity
    {
        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Cart Date")]
        public int StoreUserId { set; get; }
        public StoreUser StoreUser { set; get; }
        public ICollection<ItemCart> ItemCarts { set; get; }
    }
}
