using Newtonsoft.Json;
using Periferia.Web.App.Model.Order;
using System.Text;

namespace Periferia.Web.App.Service
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

            _httpClient = _httpClientFactory.CreateClient("GatewayWebApp");
        }

        public async Task<OrderModel?> Detail(int Id)
        {
            using var response = await _httpClient.GetAsync($"api/order/detail/{Id}");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<OrderModel?>(responseString);
            return orders;
        }

        public async Task<IEnumerable<OrderModel>> List()
        {
            using var response = await _httpClient.GetAsync("api/order/list");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<OrderModel>>(responseString);
            return orders;
        }

        public async Task<OrderModel?> Create(OrderModel order)
        {
            StringContent content = new(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json");
            using var response = await _httpClient.PostAsync("api/order", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<OrderModel?>(responseString);
            return orders;
        }
    }
}
