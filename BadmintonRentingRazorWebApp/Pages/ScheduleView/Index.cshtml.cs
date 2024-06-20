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

namespace BadmintonRentingRazorWebApp.Pages.ScheduleView
{
    public class IndexModel : PageModel
    {
        private readonly IScheduleBusiness _scheduleBusiness;

        public IndexModel(IScheduleBusiness scheduleBusiness)
        {
            _scheduleBusiness = scheduleBusiness;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchScheduleName { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? SearchStartTime { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime? SearchEndTime { get; set; }

        public IList<Schedule> Schedules { get; set; } = new List<Schedule>();

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;

        public int TotalCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                if (HttpContext.Session.GetString("Role") == null || HttpContext.Session.GetString("Role") != "Admin")
                {
                    return RedirectToPage("../Index");
                }
                else
                {
                    if (!string.IsNullOrEmpty(SearchScheduleName) || SearchStartTime != null || SearchEndTime != null)
                    {
                        var result = await _scheduleBusiness.SearchByScheduleNameAndTimeFrame(SearchScheduleName, SearchStartTime, SearchEndTime, PageNumber, PageSize);
                        if (result.Status == Const.SUCCESS_READ_CODE)
                        {
                            var pagedResult = result.Data as PagedResultSchedule<Schedule>;
                            if (pagedResult != null)
                            {
                                Schedules = pagedResult.Items;
                                TotalCount = pagedResult.TotalCount;
                            }
                        }
                        else
                        {
                            Schedules = new List<Schedule>(); // Handle if search fails
                        }
                    }
                    else
                    {
                        var result = await _scheduleBusiness.GetAllPaged(PageNumber, PageSize);
                        if (result.Status == Const.SUCCESS_READ_CODE)
                        {
                            var pagedResult = result.Data as PagedResultSchedule<Schedule>;
                            if (pagedResult != null)
                            {
                                Schedules = pagedResult.Items;
                                TotalCount = pagedResult.TotalCount;
                            }
                        }
                        else
                        {
                            Schedules = new List<Schedule>(); // Handle if GetAll fails
                        }
                    }

                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
                return RedirectToPage("/Error"); // Redirect to error page or handle error appropriately
            }
        }
    }
}
