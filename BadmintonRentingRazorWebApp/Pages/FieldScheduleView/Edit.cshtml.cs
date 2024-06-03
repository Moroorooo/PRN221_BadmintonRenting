using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;

namespace BadmintonRentingRazorWebApp.Pages.FieldScheduleView
{
    public class EditModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public EditModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        [BindProperty]
        public BookingBadmintonFieldSchedule BookingBadmintonFieldSchedule { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null || _business == null)
            {
                return NotFound();
            }

            var bookingbadmintonfieldschedule =  await _business.GetById(id);
            if (bookingbadmintonfieldschedule.Message == Const.FAIL_READ_MSG)
            {
                return NotFound();
            }
            BookingBadmintonFieldSchedule = (BookingBadmintonFieldSchedule)bookingbadmintonfieldschedule.Data;
           //ViewData["BadmintonField"] = new SelectList(_context.BadmintonFields, "BadmintonFieldId", "Address");
           //ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingType");
           //ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleName");
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

            _business.Update(BookingBadmintonFieldSchedule);
            return RedirectToPage("./Index");
        }
    }
}
