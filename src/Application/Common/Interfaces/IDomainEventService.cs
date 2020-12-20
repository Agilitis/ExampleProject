using ExampleProject.Domain.Common;
using System.Threading.Tasks;

namespace ExampleProject.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
