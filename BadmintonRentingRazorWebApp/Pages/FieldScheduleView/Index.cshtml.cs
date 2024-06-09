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
using BadmintonRentingData.DTO;

namespace BadmintonRentingRazorWebApp.Pages.FieldScheduleView
{
    public class IndexModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public IndexModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        public IList<FieldScheduleListViewDTO> BookingBadmintonFieldSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_business != null)
            {
                var result = await _business.GetAll();
                if (result.Message != Const.FAIL_READ_MSG) 
                {
                    foreach (var item in (List<BookingBadmintonFieldSchedule>)result.Data)
                    {
                        var data = await _business.ConvertToDTO(item);
                        BookingBadmintonFieldSchedule.Add((FieldScheduleListViewDTO)data.Data);
                    }
                }
            }
        }
    }
}
