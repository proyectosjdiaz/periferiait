using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Customer.Pages
{
    public class DetailModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DetailModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

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
    }
}
