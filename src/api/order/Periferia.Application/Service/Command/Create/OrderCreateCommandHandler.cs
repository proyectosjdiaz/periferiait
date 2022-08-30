using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Command.Create
{
    public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, OrderResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderResult?> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = request.Id,
                CustomerId = request.CustomerId,
                Total = request.Total,
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var requestProduct in request.OrderProducts)
            {
                OrderProduct orderProduct = new()
                {
                    Id = 0,
                    OrderId = 0,
                    ProductId = requestProduct.ProductId,
                    Quantity = requestProduct.Quantity,
                    Price = requestProduct.Price ?? 0,
                    Total = requestProduct.Total ?? 0
                };

                order.OrderProducts.Add(orderProduct);
            }

            var success = await _unitOfWork.OrderRepository.Create(order);

            if (!success)
            {
                return null;
            }

            await _unitOfWork.SaveChangesAsync();

            return new OrderResult
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Total = order.Total
            };
        }
    }
}
