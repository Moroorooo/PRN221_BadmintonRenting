using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;

namespace BadmintonRentingRazorWebApp.Pages.FieldScheduleView
{
    public class DeleteModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public DeleteModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        [BindProperty]
      public BookingBadmintonFieldSchedule BookingBadmintonFieldSchedule { get; set; } = default!;

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
                else
                {
                    BookingBadmintonFieldSchedule = (BookingBadmintonFieldSchedule)bookingbadmintonfieldschedule.Data;
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (id == null || _business == null)
            {
                return NotFound();
            }

            var result = await _business.DeleteById(id);
            if (result.Message ==  Const.FAIL_DELETE_MSG) 
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
