using Newtonsoft.Json;

namespace Periferia.Infrastructure.Service.Order
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("ProductApi");
        }

        public async Task<ProductData?> Detail(int Id)
        {
            using var response = await _httpClient.GetAsync($"product/detail/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<ProductData?>(responseString);
            return products;
        }
    }
}
