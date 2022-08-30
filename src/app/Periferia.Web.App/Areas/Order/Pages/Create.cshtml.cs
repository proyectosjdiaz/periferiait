using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Periferia.Web.App.Model.Order;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Order.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public CreateModel(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public IActionResult OnGet()
        {
            var products = _productService.List().Result;

            OrderProductModel = products.Select(p => new OrderProductModel(
                Id: 0,
                OrderId: 0,
                ProductId: p.Id,
                ProductName: p.Name,
                Quantity: 0,
                Price: p.Price,
                Total: 0
                )).ToList();

            var quantity = Enumerable.Range(0, 10);

            SelectListQuantity = new SelectList(quantity);

            return Page();
        }

        [BindProperty]
        public OrderModel OrderModel { get; set; } = default!;

        [BindProperty]
        public IList<OrderProductModel> OrderProductModel { get; set; } = null!;

        public SelectList SelectListQuantity { get; set; } = null!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || OrderModel == null || OrderProductModel == null)
            {
                return Page();
            }

            await _orderService.Create(new OrderModel(Id: OrderModel.Id,
                                                      CustomerId: OrderModel.CustomerId,
                                                      Identification: OrderModel.Identification,
                                                      FirstName: OrderModel.FirstName,
                                                      LastName: OrderModel.LastName,
                                                      Phone: OrderModel.Phone,
                                                      Total: OrderModel.Total,
                                                      OrderProducts: OrderProductModel.ToList()));

            return RedirectToPage("./Index");
        }
    }
}
