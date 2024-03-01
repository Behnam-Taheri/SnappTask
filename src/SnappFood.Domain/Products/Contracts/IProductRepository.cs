namespace SnappFood.Domain.Products.Contracts
{
    public interface IProductRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task<Product> GetAsync(Guid id, CancellationToken cancellationToken);
        bool IsExist(string title);

    }
}
