using System.Threading.Tasks;
using Store.SharedKernel.Interfaces;
using Store.SharedKernel;

namespace Store.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
