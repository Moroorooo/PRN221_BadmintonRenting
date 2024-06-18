using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;

namespace BadmintonRentingRazorWebApp.Pages.BookingView
{
    public class DetailsModel : PageModel
    {
        private readonly IBookingBusiness _business;

        public DetailsModel(IBookingBusiness business)
        {
            _business = business;
        }

      public Booking Booking { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _business == null)
            {
                return NotFound();
            }

            var booking = await _business.GetById((long)id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = (Booking)booking.Data;
            }
            return Page();
        }
    }
}
