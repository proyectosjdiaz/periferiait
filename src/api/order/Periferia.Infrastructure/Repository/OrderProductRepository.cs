using Periferia.Application.Common.Repository;
using Periferia.Domain.Entities;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly OrderDbContext _OrderDbContext;

        public OrderProductRepository(OrderDbContext OrderDbContext)
        {
            _OrderDbContext = OrderDbContext;
        }

        public async Task<bool> Create(OrderProduct orderProduct)
        {
            await _OrderDbContext.AddAsync(orderProduct);
            return true;
        }

        public async Task<IEnumerable<OrderProduct>> OrderProductByOrderId(int orderId)
        {
            return _OrderDbContext.OrderProducts.Where(c => c.OrderId.Equals(orderId));
        }
    }
}
