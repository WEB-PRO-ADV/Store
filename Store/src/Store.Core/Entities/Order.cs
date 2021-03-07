using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class Order : BaseEntity
    {
        public string Details { set; get; }
        public int StatusId { set; get; }
        public int CustomerId { set; get; }
        public string Status { set; get; }
        public Customer Customer { set; get; }
        public ICollection<OrderedItems> OrderedItems { set; get; }
    }
}
