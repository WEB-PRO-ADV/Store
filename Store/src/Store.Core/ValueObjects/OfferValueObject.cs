using Store.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ValueObjects
{
    public class OfferValueObject
    {
        public Item Item { get; set; }
        public List<Item> OfferItems { get; set; }
    }
}
