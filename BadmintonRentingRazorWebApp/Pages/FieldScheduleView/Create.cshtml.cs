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

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("Role") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToPage("/Login");
            }
            else
            {
                var badmintonFieldResult = await _business.GetAllBadmintonField();
                if (badmintonFieldResult.Message != Const.FAIL_READ_MSG)
                {
                    ViewData["BadmintonField"] = new SelectList((List<BadmintonField>)badmintonFieldResult.Data, "BadmintonFieldId", "BadmintonFieldName");
                }

                var bookingResult = await _business.GetAllBooking();
                if (bookingResult.Message != Const.FAIL_READ_MSG)
                {
                    ViewData["Booking"] = new SelectList((List<Booking>)bookingResult.Data, "BookingId", "BookingId");
                }

                var scheduleResult = await _business.GetAllSchedule();
                if (scheduleResult.Message != Const.FAIL_READ_MSG)
                {
                    ViewData["Schedule"] = new SelectList((List<Schedule>)scheduleResult.Data, "ScheduleId", "ScheduleName");

                }

                return Page();
            }
        }

        [BindProperty]
        public BookingBadmintonFieldSchedule BookingBadmintonFieldSchedule { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_business == null || BookingBadmintonFieldSchedule == null)
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
