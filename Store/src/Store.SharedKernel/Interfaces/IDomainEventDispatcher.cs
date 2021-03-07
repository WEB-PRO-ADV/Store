using System.Threading.Tasks;
using Store.SharedKernel;

namespace Store.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}