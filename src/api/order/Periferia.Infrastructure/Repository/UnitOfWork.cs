using Periferia.Application.Common.Repository;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _orderDbContext;

        public UnitOfWork(OrderDbContext customerDbContext)
        {
            _orderDbContext = customerDbContext;
        }

        public IOrderRepository OrderRepository => new OrderRepository(_orderDbContext);
        public IOrderProductRepository OrderProductRepository => new OrderProductRepository(_orderDbContext);

        public void Dispose()
        {
            if (_orderDbContext != null)
            {
                _orderDbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _orderDbContext?.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _orderDbContext.SaveChangesAsync();
        }
    }
}
