using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class IndexModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public IndexModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
        }
    }
}
