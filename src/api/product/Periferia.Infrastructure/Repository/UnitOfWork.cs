using Periferia.Application.Common.Repository;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _productDbContext;

        public UnitOfWork(ProductDbContext customerDbContext)
        {
            _productDbContext = customerDbContext;
        }

        public IProductRepository ProductRepository => new ProductRepository(_productDbContext);

        public void Dispose()
        {
            if (_productDbContext != null)
            {
                _productDbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _productDbContext?.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _productDbContext.SaveChangesAsync();
        }
    }
}
