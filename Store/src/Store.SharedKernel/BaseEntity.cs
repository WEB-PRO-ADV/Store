using System;
using System.Collections.Generic;

namespace Store.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationTime { set; get; }
        public DateTime UpdateTime { set; get; }
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}