using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;

namespace BadmintonRentingRazorWebApp.Pages.BookingBadmintonFieldSchedulePage
{
    public class IndexModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public IndexModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        public IList<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookingBadmintonFieldSchedules != null)
            {
                BookingBadmintonFieldSchedule = await _context.BookingBadmintonFieldSchedules
                .Include(b => b.BadmintonFieldNavigation)
                .Include(b => b.Booking)
                .Include(b => b.Schedule).ToListAsync();
            }
        }
    }
}
