using Periferia.Application.Common.Repository;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerDbContext _customerDbContext;

        public UnitOfWork(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public ICustomerRepository CustomerRepository => new CustomerRepository(_customerDbContext);

        public void Dispose()
        {
            if (_customerDbContext != null)
            {
                _customerDbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _customerDbContext?.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _customerDbContext.SaveChangesAsync();
        }
    }
}
