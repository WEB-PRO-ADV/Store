using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class Item : BaseEntity
    {
        public string Name { set; get; }
        public double Price { set; get; }
        public string Image { set; get; }
        public string Factory { set; get; }
        public string Description { set; get; }
        public bool IsOffer { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }
        public ICollection<ItemUniqueSpec> ItemUniqueSpecs { set; get; }
    }
}
