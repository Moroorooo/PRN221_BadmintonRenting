using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadmintonRentingData.Model;
using BadmintonRentingData;

namespace BadmintonRentingRazorWebApp.Pages
{
    public class FieldScheduleIndexCreateModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public FieldScheduleIndexCreateModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
        ViewData["BadmintonField"] = new SelectList(_unitOfWork.BookingBadmintonFieldScheduleRepository.BadmintonFields, "BadmintonFieldId", "Address");
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
