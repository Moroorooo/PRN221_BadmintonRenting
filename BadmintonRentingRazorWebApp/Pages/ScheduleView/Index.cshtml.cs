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

namespace BadmintonRentingRazorWebApp.Pages.ScheduleView
{
    public class IndexModel : PageModel
    {
        private readonly IScheduleBusiness _scheduleBusiness;

        public IndexModel(IScheduleBusiness scheduleBusiness)
        {
            _scheduleBusiness = scheduleBusiness;
        }

        public IList<Schedule> Schedule { get; set; } = new List<Schedule>();

        public async Task OnGetAsync()
        {
            var result = await _scheduleBusiness.GetAll();
            if (result.Status == Const.SUCCESS_READ_CODE)
            {
                Schedule = (List<Schedule>)result.Data;
            }
        }
    }
}
