using SnappFood.Application.Contract.Dtos.Orders;
using SnappFood.Application.Contract.IServices;
using SnappFood.Domain.Orders;
using SnappFood.Domain.Orders.Contracts;
using SnappFood.Domain.Products.Contracts;
using SnappFood.Framework.Core.Abstractions;

namespace SnappFood.Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository,
            IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task SubmitAsync(SubmitOrderDto dto, CancellationToken cancellationToken)
        {
            try
            {
                await _unitOfWork.BeginAsync(cancellationToken);

                var order = new Order(dto.UserId, dto.ProductId);

                var product = await _productRepository.GetAsync(dto.ProductId, cancellationToken);
                product.DecreaseInventoryCount();

                await _orderRepository.CreateAsync(order, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                await _unitOfWork.RolBackAsync(cancellationToken);
                throw ex; 
            }

        }
    }
}
