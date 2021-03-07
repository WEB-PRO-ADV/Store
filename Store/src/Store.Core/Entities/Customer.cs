using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class Customer : BaseEntity
    {
        public DateTime JoinDate { set; get; }
        public ICollection<Order> Orders { set; get; }
    }
}
