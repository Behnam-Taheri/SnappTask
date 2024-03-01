using Microsoft.Extensions.Caching.Memory;
using SnappFood.Application.Contract.Dtos.Products;
using SnappFood.Application.Contract.IServices;
using SnappFood.Domain.Products;
using SnappFood.Domain.Products.Contracts;

namespace SnappFood.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTitleDuplicateChecker _productTitleDuplicateChecker;
        private readonly IMemoryCache _cache;

        public ProductService(IProductRepository productRepository,
            IProductTitleDuplicateChecker productTitleDuplicateChecker,
            IMemoryCache cache)
        {
            _productRepository = productRepository;
            _productTitleDuplicateChecker = productTitleDuplicateChecker;
            _cache = cache;
        }


        public async Task CreateAsync(AddProductDto dto, CancellationToken cancellationToken)
        {
            var product = new Product(dto.ToArg(), _productTitleDuplicateChecker);
            await _productRepository.CreateAsync(product, cancellationToken);
        }

        public async Task ChangeInventoryCountAsync(ChangeInventoryCountDto dto, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(dto.ProductId, cancellationToken);
            product.ChangeInventoryCount(dto.Count);
            await _productRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = _cache.Get(id) as ProductDto;

            if (result is null)
            {
                var product = await _productRepository.GetAsync(id, cancellationToken);

                result = MapToDto(product);

                _cache.Set(id, result);
            }

            return result;
        }

        private static ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Discount = product.Discount,
                Price = product.CalculatePriceWithDiscount(),
                Title = product.Title.Value,
                InventoryCount = product.InventoryCount,
            };
        }
    }
}
