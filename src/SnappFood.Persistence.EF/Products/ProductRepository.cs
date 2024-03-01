using Microsoft.EntityFrameworkCore;
using SnappFood.Domain.Products;
using SnappFood.Domain.Products.Contracts;

namespace SnappFood.Persistence.EF.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly SnappContext _context;
        public ProductRepository(SnappContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public bool IsExist(string title)
        {
            return _context.Products.Any(x => x.Title.Value == title);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateAsync(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
