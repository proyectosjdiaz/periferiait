using Microsoft.EntityFrameworkCore;
using Periferia.Application.Common.Repository;
using Periferia.Domain.Entities;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _OrderDbContext;

        public OrderRepository(OrderDbContext OrderDbContext)
        {
            _OrderDbContext = OrderDbContext;
        }

        public async Task<bool> Create(Order order)
        {
            await _OrderDbContext.AddAsync(order);
            return true;
        }

        public async Task<IEnumerable<Order>> List()
        {
            return _OrderDbContext.Orders
                .Include(o => o.OrderProducts);
        }

        public async Task<Order?> Detail(int Id)
        {
            return await _OrderDbContext.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(c => c.Id.Equals(Id));
        }
    }
}
