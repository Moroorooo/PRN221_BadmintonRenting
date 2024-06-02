using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;
using BadmintonRentingData;
using BadmintonRentingData.DTO;
using BadmintonRentingBusiness;

namespace BadmintonRentingRazorWebApp.Pages
{
    public class FieldScheduleIndexModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public FieldScheduleIndexModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        public IList<FieldScheduleListViewDTO> BookingBadmintonFieldSchedule { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_business != null)
            {
                var result = await _business.GetAll();
                var data = (IList<BookingBadmintonFieldSchedule>)result.Data;
                foreach (var entity in data)
                {
                    var dto = new FieldScheduleListViewDTO()
                    {
                        OrderBadmintonFieldScheduleId = entity.OrderBadmintonFieldScheduleId,
                        BookingId = entity.BookingId,
                        StartDate = entity.StartDate,
                        EndDate = entity.EndDate,
                        BadmintonFieldName = null,
                        ScheduleName = null
                    };
                    BookingBadmintonFieldSchedule.Add(dto);
                }
            }
        }
    }
}
