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

namespace BadmintonRentingRazorWebApp.Pages.BookingView
{
    public class DeleteModel : PageModel
    {
        private readonly IBookingBusiness _business;

        public DeleteModel(IBookingBusiness business)
        {
            _business = _business;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        [BindProperty]
        public string Message { get; set; } = null;
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _business == null)
            {
                return NotFound();
            }

            var booking = await _business.GetById((long)id);

            if (booking.Message == Const.FAIL_READ_MSG)
            {
                return NotFound();
            }
            else 
            {
                Booking = (Booking)booking.Data;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _business == null)
            {
                return NotFound();
            }
            var result = await _business.DeleteById((long)id);
            if (result.Message == Const.SUCCESS_DELETE_MSG) 
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Message = "Delete fail!!!";
                return Page();
            }
        }
    }
}
