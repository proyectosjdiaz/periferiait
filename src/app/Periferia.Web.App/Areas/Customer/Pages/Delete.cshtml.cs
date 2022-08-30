using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Customer.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DeleteModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public CustomerModel CustomerModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customermodel = await _customerService.Detail(id.Value);

            if (customermodel == null)
            {
                return NotFound();
            }
            else
            {
                CustomerModel = customermodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _customerService.Delete(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
