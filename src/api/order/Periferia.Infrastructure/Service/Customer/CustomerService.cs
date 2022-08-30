using Newtonsoft.Json;
using System.Text;

namespace Periferia.Infrastructure.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("CustomerApi");
        }

        public async Task<CustomerData?> Detail(int Id)
        {
            using var response = await _httpClient.GetAsync($"customer/detail/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerData?>(responseString);
            return customers;
        }

        public async Task<CustomerData> CreateCustomer(CustomerData customer)
        {
            StringContent content = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync("customer", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerData?>(responseString);
            return customers;
        }

        public async Task<CustomerData> GetCustomerByIdentification(string identification)
        {
            using var response = await _httpClient.GetAsync($"customer/identification/{identification}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerData?>(responseString);
            return customers;
        }
    }
}
