using SnappFood.Domain.Products.ValueObjects;

namespace SnappFood.Domain.Products.Arguments
{
    public record CreateProductArgument
    {
        public string Title { get; set; } = null!;
        public uint? InventoryCount { get; set; }
        public long Price { get; set; }
        public uint Discount { get; set; }
    }
}
