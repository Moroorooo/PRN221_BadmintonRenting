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
    public class DeleteModel : PageModel
    {
        private readonly IScheduleBusiness _scheduleBusiness;

        public DeleteModel(IScheduleBusiness scheduleBusiness)
        {
            _scheduleBusiness = scheduleBusiness;
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _scheduleBusiness.GetById(id.Value);

            if (result.Status == Const.SUCCESS_READ_CODE && result.Data is Schedule schedule)
            {
                Schedule = schedule;
            }
            else
            {
                ErrorMessage = result.Message ?? "Schedule not found.";
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _scheduleBusiness.DeleteById(id);

            if (result.Status == Const.SUCCESS_DELETE_CODE)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ErrorMessage = result.Message ?? "Error deleting schedule.";
                return Page();
            }
        }
    }
}
