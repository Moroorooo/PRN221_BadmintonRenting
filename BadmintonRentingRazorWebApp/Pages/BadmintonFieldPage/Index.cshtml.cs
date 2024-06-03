using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;

namespace BadmintonRentingRazorWebApp.Pages.BadmintonFieldPage
{
    public class IndexModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public IndexModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        public IList<BadmintonField> BadmintonField { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BadmintonFields != null)
            {
                BadmintonField = await _context.BadmintonFields.ToListAsync();
            }
        }
    }
}
