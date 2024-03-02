using SnappFood.Domain.Products;

namespace SnappFood.Domain.Orders.Contracts
{
    public interface IOrderRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);

        Task CreateAsync(Order order, CancellationToken cancellationToken);
    }
}
