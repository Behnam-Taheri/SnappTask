using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Orders
{
    public class Order : AggregateRoot<Guid>
    {
       
        public DateTime CreationDate { get; set; }
    }
}
