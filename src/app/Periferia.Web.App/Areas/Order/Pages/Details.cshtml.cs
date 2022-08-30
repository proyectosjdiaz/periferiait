using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Order;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Order.Pages
{
    public class Details : PageModel
    {
        private readonly IOrderService _orderService;

        public Details(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordermodel = await _orderService.Detail(id.Value);
            if (ordermodel == null)
            {
                return NotFound();
            }
            else
            {
                OrderModel = ordermodel;
                OrderProductModel = ordermodel.OrderProducts.ToList();
            }
            return Page();
        }

        [BindProperty]
        public OrderModel OrderModel { get; set; } = default!;

        [BindProperty]
        public IList<OrderProductModel> OrderProductModel { get; set; } = null!;

    }
}
