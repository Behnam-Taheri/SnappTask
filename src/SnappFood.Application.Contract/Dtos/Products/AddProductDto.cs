using SnappFood.Domain.Products.Arguments;

namespace SnappFood.Application.Contract.Dtos.Products
{
    public sealed record AddProductDto
    {
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public uint? InventoryCount { get; set; }
        public uint Discount { get; set; }

        public CreateProductArgument ToArg()
        {
            return new()
            {
                Title = Title,
                Price = Price,
                InventoryCount = InventoryCount,
                Discount = Discount
            };
        }
    }
}
