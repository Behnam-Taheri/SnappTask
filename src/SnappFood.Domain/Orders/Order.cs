using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Orders
{
    public class Order : AggregateRoot<Guid>
    {
        public Order()
        {
            Id = Guid.NewGuid();
        }
        public Guid UserId { get; private set; }
        public Guid ProductId { get; private set; }
        public DateTime CreationDate { get; private set; }
    }
}
