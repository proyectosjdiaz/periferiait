using Microsoft.AspNetCore.Mvc.RazorPages;
using Periferia.Web.App.Model.Customer;
using Periferia.Web.App.Service;

namespace Periferia.Web.App.Areas.Customer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IList<CustomerModel> CustomerModel { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CustomerModel = (IList<CustomerModel>)(await _customerService.List());
        }
    }
}
