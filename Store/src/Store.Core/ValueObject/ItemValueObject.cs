using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ValueObject
{
    class ItemValueObject
    {
        public Item Item { set; get; }
        public List<ItemUniqueSpec> ItemUniqueSpec { set; get; }
    }
}
