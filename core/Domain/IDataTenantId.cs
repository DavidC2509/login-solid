using MediatR;

namespace Core.Domain
{
    public interface IDataTenantId
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }
        IReadOnlyCollection<INotification> DomainEventsAwait { get; }

        void ClearDomainEvents();
        void ClearDomainEventsAwait();

    }
}
