using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Query.Detail
{
    public class OrderDetailQueryHandler : IRequestHandler<OrderDetailQuery, OrderResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderResult?> Handle(OrderDetailQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.OrderRepository.Detail(request.Id) is not Order order)
                return null;

            return new OrderResult
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Total = order.Total,
                OrderProducts = order.OrderProducts.Select(d => new OrderProductResult
                {
                    Id = d.Id,
                    OrderId = d.OrderId,
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Price = d.Price,
                    Total = d.Total
                }).ToList()
            };
        }
    }
}
