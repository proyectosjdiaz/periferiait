using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Product.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductModel ProductModel { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || ProductModel == null)
            {
                return Page();
            }

            await _productService.Create(ProductModel);

            return RedirectToPage("./Index");
        }
    }
}
