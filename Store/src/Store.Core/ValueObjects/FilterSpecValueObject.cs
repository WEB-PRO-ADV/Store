using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ValueObjects
{
    public class FilterSpecValueObject
    {
        public double Price_max { set; get; }
        public Item Item { set; get; }
        public List<Item> Items { set; get; }
        public List<string> ItemName { set; get; }
        public ItemUniqueSpec ItemUniqueSpec { set; get; }
        public List<ItemUniqueSpec> ItemUniqueSpecs { set; get; }
        public List<string> NameSpec { set; get; }
        public List<string> ValueSpec { set; get; }
        public string Namespecefication { set; get; }
    }
}
