using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class StoreUser : IdentityUser
    {
        public ICollection<Order> Orders { set; get; }
    }
}
