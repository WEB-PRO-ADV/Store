using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class OfferItems : BaseEntity
    {
        public int ItemId { set; get; }
        public int OfferItemId { get; set; }
        public int Quantity { set; get; }
        public Item Item { set; get; }
        public Item OfferItem { set; get; }
    }
}
