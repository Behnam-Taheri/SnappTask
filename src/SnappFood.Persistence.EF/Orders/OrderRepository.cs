using SnappFood.Domain.Orders;
using SnappFood.Domain.Orders.Contracts;

namespace SnappFood.Persistence.EF.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SnappContext _context;
        public OrderRepository(SnappContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order order, CancellationToken cancellationToken)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
