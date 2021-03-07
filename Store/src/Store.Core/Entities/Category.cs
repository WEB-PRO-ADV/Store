using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public ICollection<Item> Items { set; get; }
    }
}
