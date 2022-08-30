using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Product.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        public DetailsModel(IProductService customerService)
        {
            _productService = customerService;
        }

        public ProductModel ProductModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productmodel = await _productService.Detail(id.Value);
            if (productmodel == null)
            {
                return NotFound();
            }
            else
            {
                ProductModel = productmodel;
            }
            return Page();
        }
    }
}
