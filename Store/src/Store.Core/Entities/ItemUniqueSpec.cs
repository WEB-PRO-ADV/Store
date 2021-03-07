using Store.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.Entities
{
    public class ItemUniqueSpec : BaseEntity
    {
        public string Name { set; get; }
        public string Value { set; get; }
        public int ItemId { set; get; }
        public Item Item { set; get; }
    }
}
