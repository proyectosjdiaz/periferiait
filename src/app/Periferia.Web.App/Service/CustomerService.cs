using Newtonsoft.Json;
using Periferia.Web.App.Model.Customer;
using System.Text;

namespace Periferia.Web.App.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            _httpClient = _httpClientFactory.CreateClient("GatewayWebApp");
        }

        public async Task<CustomerModel?> Detail(int Id)
        {
            using var response = await _httpClient.GetAsync($"api/customer/detail/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerModel?>(responseString);
            return customers;
        }

        public async Task<IEnumerable<CustomerModel>> List()
        {
            using var response = await _httpClient.GetAsync("api/customer/list");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomerModel>>(responseString);
            return customers;
        }

        public async Task<CustomerModel?> Create(CustomerModel customer)
        {
            StringContent content = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync("api/customer", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerModel?>(responseString);
            return customers;
        }

        public async Task<CustomerModel?> Delete(int Id)
        {
            using var response = await _httpClient.DeleteAsync($"api/customer/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerModel?>(responseString);
            return customers;
        }

        public async Task<CustomerModel?> Update(CustomerModel customer)
        {
            StringContent content = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync("api/customer", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomerModel?>(responseString);
            return customers;
        }
    }
}
