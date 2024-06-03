    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;

namespace BadmintonRentingRazorWebApp.Pages.FieldScheduleView
{
    public class IndexModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public IndexModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        public IList<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_business != null)
            {
                var result = await _business.GetAll();
                if (result != null)
                {
                    BookingBadmintonFieldSchedule = (List<BookingBadmintonFieldSchedule>)result.Data;
                }
            }
        }
    }
}
