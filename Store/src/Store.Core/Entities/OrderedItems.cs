using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class OrderedItems : BaseEntity
    {
        public int Quantity { set; get; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public Order Order { set; get; }
    }
}
