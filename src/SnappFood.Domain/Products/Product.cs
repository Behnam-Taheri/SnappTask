using System.Security.AccessControl;
using SnappFood.Domain.Products.Arguments;
using SnappFood.Domain.Products.Contracts;
using SnappFood.Domain.Products.ValueObjects;
using SnappFood.Framework.Domain.BuildingBlocks;

namespace SnappFood.Domain.Products
{
    public class Product : AggregateRoot<Guid>
    {
        public Product(CreateProductArgument arg, IProductTitleDuplicateChecker productTitleDuplicateChecker)
        {
            Title = new Title(arg.Title, productTitleDuplicateChecker);
            InventoryCount = arg.InventoryCount;
            Price = arg.Price;
            Discount = arg.Discount;
        }

        public Title Title { get; private set; }
        public uint InventoryCount { get; private set; }
        public long Price { get; private set; }
        public uint Discount { get; private set; }


        public void ChangeInventoryCount(uint count) => InventoryCount = count;
    }
}
