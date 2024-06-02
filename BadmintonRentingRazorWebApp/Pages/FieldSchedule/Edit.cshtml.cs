using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;

namespace BadmintonRentingRazorWebApp.Pages.FieldSchedule
{
    public class EditModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public EditModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
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

            var bookingbadmintonfieldschedule =  await _context.BookingBadmintonFieldSchedules.FirstOrDefaultAsync(m => m.OrderBadmintonFieldScheduleId == id);
            if (bookingbadmintonfieldschedule == null)
            {
                return NotFound();
            }
            BookingBadmintonFieldSchedule = bookingbadmintonfieldschedule;
           ViewData["BadmintonField"] = new SelectList(_context.BadmintonFields, "BadmintonFieldId", "Address");
           ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingType");
           ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleName");
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

            _context.Attach(BookingBadmintonFieldSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingBadmintonFieldScheduleExists(BookingBadmintonFieldSchedule.OrderBadmintonFieldScheduleId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingBadmintonFieldScheduleExists(long id)
        {
          return (_context.BookingBadmintonFieldSchedules?.Any(e => e.OrderBadmintonFieldScheduleId == id)).GetValueOrDefault();
        }
    }
}
