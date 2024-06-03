using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;

namespace BadmintonRentingRazorWebApp.Pages.FieldScheduleView
{
    public class CreateModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public CreateModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        //public IActionResult OnGet()
        //{
        //ViewData["BadmintonField"] = new SelectList(_context.BadmintonFields, "BadmintonFieldId", "Address");
        //ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingType");
        //ViewData["ScheduleId"] = new SelectList(_context.Schedules, "ScheduleId", "ScheduleName");
        //    return Page();
        //}

        [BindProperty]
        public BookingBadmintonFieldSchedule BookingBadmintonFieldSchedule { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _business == null || BookingBadmintonFieldSchedule == null)
            {
                return Page();
            }

            var result = await _business.Create(BookingBadmintonFieldSchedule);
            if (result.Message == Const.FAIL_CREATE_MSG)
            {
                return NotFound();
            }
            return RedirectToPage("./Index");
        }
    }
}
