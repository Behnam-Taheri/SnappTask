
using SnappFood.Domain.Products.Contracts;

namespace SnappFood.DomainServices.Products
{
    public class ProductTitleDuplicateChecker : IProductTitleDuplicateChecker
    {
        private readonly IProductRepository _productRepository;

        public ProductTitleDuplicateChecker(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsExist(string title)
        {
            return _productRepository.IsExist(title); 
        }
    }
}
