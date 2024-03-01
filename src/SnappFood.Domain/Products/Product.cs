using System.Security.AccessControl;
using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Products
{
    public class Product : AggregateRoot<Guid>
    {
        public string Title { get; set; } = null!;
        public int InventoryCount { get; set; }
        public long Price { get; set; }
        public int Discount { get; set; }
    }
}
