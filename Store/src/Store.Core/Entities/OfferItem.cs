using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class OfferItem : BaseEntity
    {
        public int ItemId { set; get; }
        public int ContainedItemId { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int Quantity { set; get; }
        public Item Item { set; get; }
        public Item ContainedItem { set; get; }
    }
}
