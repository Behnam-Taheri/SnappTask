using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Orders
{
    public class Order : AggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
