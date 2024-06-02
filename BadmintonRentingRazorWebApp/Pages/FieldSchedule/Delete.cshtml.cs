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
    public class DeleteModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public DeleteModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.BookingBadmintonFieldSchedules == null)
            {
                return NotFound();
            }
            var bookingbadmintonfieldschedule = await _context.BookingBadmintonFieldSchedules.FindAsync(id);

            if (bookingbadmintonfieldschedule != null)
            {
                BookingBadmintonFieldSchedule = bookingbadmintonfieldschedule;
                _context.BookingBadmintonFieldSchedules.Remove(BookingBadmintonFieldSchedule);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
