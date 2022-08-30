using Periferia.Web.App.Model.Customer;

namespace Periferia.Web.App.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> List();
        Task<CustomerModel?> Detail(int Id);
        Task<CustomerModel?> Delete(int Id);
        Task<CustomerModel?> Create(CustomerModel customer);
        Task<CustomerModel?> Update(CustomerModel customer);
    }
}
