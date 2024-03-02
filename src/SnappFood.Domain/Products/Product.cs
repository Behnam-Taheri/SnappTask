using System.Security.AccessControl;
using SnappFood.Domain.Products.Arguments;
using SnappFood.Domain.Products.Contracts;
using SnappFood.Domain.Products.ValueObjects;
using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Products
{
    public class Product : AggregateRoot<Guid>
    {
        private const uint DefaultInventoryCount = 3;
        private Product() { }

        public Product(CreateProductArgument arg, IProductTitleDuplicateChecker productTitleDuplicateChecker)
        {
            Id = Guid.NewGuid();
            Title = new Title(arg.Title, productTitleDuplicateChecker);
            Price = arg.Price;
            Discount = arg.Discount;
            SetInventoryCount(arg.InventoryCount);
        }

        public Title Title { get; private set; }
        public uint InventoryCount { get; private set; }
        public long Price { get; private set; }
        public uint Discount { get; private set; }

        public void DecreaseInventoryCount()
        {
            InventoryCount--;
            if (InventoryCount < 0) throw new ArgumentOutOfRangeException();
        }

        public long CalculatePriceWithDiscount() => (Price * Discount) / 100;
        public void ChangeInventoryCount(uint count) => InventoryCount = count;
        private void SetInventoryCount(uint? count) => InventoryCount = count.HasValue ? count.Value : DefaultInventoryCount;
    }
}
