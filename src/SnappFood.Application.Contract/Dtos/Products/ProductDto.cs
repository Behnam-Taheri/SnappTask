namespace SnappFood.Application.Contract.Dtos.Products
{
    public sealed record ProductDto
    {
        public string Title { get; set; } = null!;
        public long Price { get; set; }
        public uint InventoryCount { get; set; } = 3;
        public uint Discount { get; set; }
    }
}
