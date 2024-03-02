using SnappFood.Application.Contract.Dtos.Orders;

namespace SnappFood.Application.Contract.IServices
{
    public interface IOrderService
    {
        Task SubmitAsync(SubmitOrderDto dto, CancellationToken cancellationToken);
    }
}
