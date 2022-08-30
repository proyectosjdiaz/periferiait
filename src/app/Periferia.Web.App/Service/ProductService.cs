using Newtonsoft.Json;
using Periferia.Web.App.Model.Customer;
using System.Text;

namespace Periferia.Web.App.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            _httpClient = _httpClientFactory.CreateClient("GatewayWebApp");
        }

        public async Task<ProductModel?> Detail(int Id)
        {
            using var response = await _httpClient.GetAsync($"api/product/detail/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<ProductModel?>(responseString);
            return customers;
        }

        public async Task<IEnumerable<ProductModel>> List()
        {
            using var response = await _httpClient.GetAsync("api/product/list");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(responseString);
            return customers;
        }

        public async Task<ProductModel?> Create(ProductModel customer)
        {
            StringContent content = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync("api/product", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<ProductModel?>(responseString);
            return customers;
        }

        public async Task<ProductModel?> Delete(int Id)
        {
            using var response = await _httpClient.DeleteAsync($"api/product/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<ProductModel?>(responseString);
            return customers;
        }

        public async Task<ProductModel?> Update(ProductModel customer)
        {
            StringContent content = new(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PutAsync("api/product", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<ProductModel?>(responseString);
            return customers;
        }
    }
}
