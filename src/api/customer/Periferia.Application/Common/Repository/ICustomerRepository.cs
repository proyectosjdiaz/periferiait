using Periferia.Domain.Entities;

namespace Periferia.Application.Common.Repository
{
    public interface ICustomerRepository
    {
        Task<bool> Create(Customer customer);
        Task<bool> Update(int Id, Customer customer);
        Task<bool> Delete(int Id);
        Task<IEnumerable<Customer>> List();
        Task<Customer?> Detail(int Id);
        Task<Customer?> ByIdentification(string identification);
    }
}
