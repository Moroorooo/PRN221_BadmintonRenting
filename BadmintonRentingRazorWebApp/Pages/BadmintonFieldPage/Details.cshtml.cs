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
    public class DetailsModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public DetailsModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

      public BadmintonField BadmintonField { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.BadmintonFields == null)
            {
                return NotFound();
            }

            var badmintonfield = await _context.BadmintonFields.FirstOrDefaultAsync(m => m.BadmintonFieldId == id);
            if (badmintonfield == null)
            {
                return NotFound();
            }
            else 
            {
                BadmintonField = badmintonfield;
            }
            return Page();
        }
    }
}
