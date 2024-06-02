using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;

namespace BadmintonRentingRazorWebApp.Pages.FieldSchedule
{
    public class DetailsModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public DetailsModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

      public BookingBadmintonFieldSchedule BookingBadmintonFieldSchedule { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.BookingBadmintonFieldSchedules == null)
            {
                return NotFound();
            }

            var bookingbadmintonfieldschedule = await _context.BookingBadmintonFieldSchedules.FirstOrDefaultAsync(m => m.OrderBadmintonFieldScheduleId == id);
            if (bookingbadmintonfieldschedule == null)
            {
                return NotFound();
            }
            else 
            {
                BookingBadmintonFieldSchedule = bookingbadmintonfieldschedule;
            }
            return Page();
        }
    }
}
