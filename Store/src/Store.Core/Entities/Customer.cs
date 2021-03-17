using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Core.Entities
{
    public class Customer : BaseEntity
    {
        [DataType(DataType.Date)]
        [Display(Name = "Cart Date")]
        public DateTime JoinDate { set; get; }
        public ICollection<Order> Orders { set; get; }
    }
}
