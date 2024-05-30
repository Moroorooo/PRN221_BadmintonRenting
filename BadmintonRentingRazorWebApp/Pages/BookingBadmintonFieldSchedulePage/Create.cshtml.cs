using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadmintonRentingData.Model;

namespace BadmintonRentingRazorWebApp.Pages.BookingBadmintonFieldSchedulePage
{
    public class CreateModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public CreateModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BadmintonField"] = new SelectList(_context.BadmintonFields, "BadmintonFieldId", "Address");
        ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingType");
        ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleName");
            return Page();
        }

        [BindProperty]
        public BookingBadmintonFieldSchedule BookingBadmintonFieldSchedule { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BookingBadmintonFieldSchedules == null || BookingBadmintonFieldSchedule == null)
            {
                return Page();
            }

            _context.BookingBadmintonFieldSchedules.Add(BookingBadmintonFieldSchedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
