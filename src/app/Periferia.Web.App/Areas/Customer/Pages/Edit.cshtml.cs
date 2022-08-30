using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Customer.Pages
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel(ICustomerService customerService)
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
            CustomerModel = customermodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerService.Update(CustomerModel);

            return RedirectToPage("./Index");
        }
    }
}
