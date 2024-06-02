using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingData.DTO;

namespace BadmintonRentingRazorWebApp.Pages.FieldSchedule
{
    public class IndexModel : PageModel
    {
        private readonly BookingBadmintonFieldScheduleBusiness _business;

        public IndexModel(BookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        public IList<FieldScheduleListViewDTO> BookingBadmintonFieldSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_business != null)
            {
                var list = await _business.GetAll();
            }
        }
    }
}
