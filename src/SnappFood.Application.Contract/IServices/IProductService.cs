using SnappFood.Application.Contract.Dtos.Products;

namespace SnappFood.Application.Contract.IServices
{
    public interface IProductService
    {
        Task<ProductDto> GetAsync(Guid id, CancellationToken cancellationToken);
        Task CreateAsync(AddProductDto dto, CancellationToken cancellationToken);
        Task ChangeInventoryCountAsync(ChangeInventoryCountDto dto, CancellationToken cancellationToken);
    }
}
