using Microsoft.EntityFrameworkCore;
using Periferia.Application.Common.Repository;
using Periferia.Domain.Entities;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerRepository(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<bool> Create(Customer customer)
        {
            await _customerDbContext.AddAsync(customer);
            return true;
        }

        public async Task<bool> Update(int Id, Customer customer)
        {
            if (await _customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id) is Customer origin)
            {
                origin.FirstName = customer.FirstName;
                origin.LastName = customer.LastName;
                origin.Phone = customer.Phone;
            }
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            if (await _customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id) is Customer customer)
            {
                _customerDbContext.Customers.Remove(customer);
            }
            return true;
        }

        public async Task<IEnumerable<Customer>> List()
        {
            return _customerDbContext.Customers;
        }

        public async Task<Customer?> Detail(int Id)
        {
            return await _customerDbContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(Id));
        }

        public async Task<Customer?> ByIdentification(string identification)
        {
            return await _customerDbContext.Customers.FirstOrDefaultAsync(c => c.Identification.Equals(identification));
        }
    }
}
