using SnappFood.Framework.Core.Abstractions;

namespace SnappFood.Framework.Domain.BuildingBlocks
{
    public class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    {
        public TKey Id { get; protected set; }

        public IList<IDomainEvent> domainEvents;

        public void QueueEvent<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> GetAllQueuedEvents()
        {
            throw new NotImplementedException();
        }
    }
}
