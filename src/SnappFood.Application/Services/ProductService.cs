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

        public ProductService(IProductRepository productRepository,
            IProductTitleDuplicateChecker productTitleDuplicateChecker)
        {
            _productRepository = productRepository;
            _productTitleDuplicateChecker = productTitleDuplicateChecker;
        }


        public async Task CreateAsync(AddProductDto dto, CancellationToken cancellationToken)
        {
            var product = new Product(dto.ToArg(), _productTitleDuplicateChecker);
            await _productRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task ChangeInventoryCountAsync(ChangeInventoryCountDto dto, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(dto.ProductId, cancellationToken);
            product.ChangeInventoryCount(dto.Count);
        }

        public async Task<ProductDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(id, cancellationToken);


            return null;
        }
    }
}
