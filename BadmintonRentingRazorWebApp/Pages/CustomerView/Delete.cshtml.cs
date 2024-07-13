using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;
using Microsoft.AspNetCore.SignalR;

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;
        private readonly IHubContext<SignalRServer> _signalRHub;
        public DeleteModel(ICustomerBusiness customerBusiness, IHubContext<SignalRServer> signalRHub)
        {
            _customerBusiness = customerBusiness;
            _signalRHub = signalRHub;
        }

        [BindProperty]
      public Customer Customer { get; set; } = default!;

        public string ErrorMessage { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _customerBusiness.GetById(id.Value);

            if (result.Status == Const.SUCCESS_READ_CODE && result.Data is Customer customer)
            {
                Customer = customer;
            }
            else
            {
                ErrorMessage = result.Message ?? "Customer not found.";
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var result = await _customerBusiness.DeleteById(id);
            
            if (result.Status == Const.SUCCESS_DELETE_CODE)
            {
                await _signalRHub.Clients.All.SendAsync("LoadCustomer");
                return RedirectToPage("./Index");
            }
            else
            {
                ErrorMessage = result.Message ?? "Error deleting customer.";
                return Page();
            }
        }
    }
}
