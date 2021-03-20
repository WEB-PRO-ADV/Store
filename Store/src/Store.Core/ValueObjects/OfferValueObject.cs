using Store.Core.Entities;
using Store.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Core.ValueObjects
{
    public class OfferValueObject
    {
        public Item Item { get; set; }
        public List<ItemValueObject> OfferItems { get; set; }
    }
}
