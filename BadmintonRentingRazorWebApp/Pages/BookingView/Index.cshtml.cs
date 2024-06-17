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
    public class IndexModel : PageModel
    {
        private readonly IBookingBusiness _business;

        public IndexModel(IBookingBusiness business)
        {
            _business = business;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_business != null)
            {
                var result = await _business.GetAll();
                if (result.Message == Const.SUCCESS_READ_MSG)
                {
                    Booking = (List<Booking>)result.Data;
                }
            }
        }
    }
}
