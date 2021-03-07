using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class ItemCart : BaseEntity
    {
        public int ItemId { set; get; }
        public int Quantity { set; get; }
        public int CartId { set; get; }
        public Cart Cart { set; get; }
        public Item Item { set; get; }
    }
}
