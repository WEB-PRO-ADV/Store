using System.Threading.Tasks;
using Store.SharedKernel;

namespace Store.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}