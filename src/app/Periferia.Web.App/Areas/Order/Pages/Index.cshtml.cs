using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Order;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Order.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IList<OrderModel> OrderModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            OrderModel = (IList<OrderModel>)(await _orderService.List());
        }
    }
}
