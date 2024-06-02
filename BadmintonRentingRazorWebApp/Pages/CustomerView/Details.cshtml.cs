using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class DetailsModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        private readonly ICustomerBusiness customerBusiness;

        public DetailsModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

      public Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await customerBusiness.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = (Customer)customer;
            }
            return Page();
        }
    }
}
