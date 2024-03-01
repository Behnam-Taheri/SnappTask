namespace SnappFood.Application.Contract.Dtos.Products
{
    public sealed record ChangeInventoryCountDto(Guid ProductId, uint Count);
}
