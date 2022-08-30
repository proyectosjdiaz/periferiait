using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Product.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<ProductModel> ProductModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ProductModel = (IList<ProductModel>)(await _productService.List());
        }
    }
}
