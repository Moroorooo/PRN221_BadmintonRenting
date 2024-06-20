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
        [BindProperty]
        public string Message { get; set; } = null;
        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (HttpContext.Session.GetString("Role") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToPage("/Login");
            }
            else
            {
                if (id == null || _business == null)
                {
                    return NotFound();
                }

                var bookingbadmintonfieldschedule = await _business.GetById(id);
                if (bookingbadmintonfieldschedule.Message == Const.FAIL_READ_MSG)
                {
                    return NotFound();
                }
                BookingBadmintonFieldSchedule = (BookingBadmintonFieldSchedule)bookingbadmintonfieldschedule.Data;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var result = await _business.Update(BookingBadmintonFieldSchedule);
            if (result.Message == Const.FAIL_UPDATE_MSG)
            {
                Message = "Update Fail";
                return Page();
            }
            else
            {

                return RedirectToPage("./Index");
            }
        }
    }
}
