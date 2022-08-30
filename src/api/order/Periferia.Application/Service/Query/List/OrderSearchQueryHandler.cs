using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Query.List
{
    public class OrderSearchQueryHandler : IRequestHandler<OrderSearchQuery, IEnumerable<OrderResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderSearchQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderResult>> Handle(OrderSearchQuery request, CancellationToken cancellationToken)
        {
            var search = await _unitOfWork.OrderRepository.List();
            var orders = search.Select(s => new OrderResult
            {
                Id = s.Id,
                CustomerId = s.CustomerId,
                Total = s.Total,
                OrderProducts = s.OrderProducts.Select(d => new OrderProductResult
                {
                    Id = d.Id,
                    OrderId = d.OrderId,
                    ProductId = d.ProductId,
                    Quantity = d.Quantity,
                    Price = d.Price,
                    Total = d.Total
                }).ToList()
            });
            return orders;
        }
    }
}
