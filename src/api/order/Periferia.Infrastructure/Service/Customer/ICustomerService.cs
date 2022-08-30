namespace Periferia.Infrastructure.Service.Customer
{
    public interface ICustomerService
    {
        Task<CustomerData?> Detail(int Id);
        Task<CustomerData> GetCustomerByIdentification(string identification);
        Task<CustomerData> CreateCustomer(CustomerData customer);
    }
}
