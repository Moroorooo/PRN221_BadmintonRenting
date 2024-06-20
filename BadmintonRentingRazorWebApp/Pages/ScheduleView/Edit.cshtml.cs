using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;
using BadmintonRentingData.DTO;

namespace BadmintonRentingRazorWebApp.Pages.ScheduleView
{
    public class EditModel : PageModel
    {
        private readonly IScheduleBusiness _scheduleBusiness;
        public EditModel(IScheduleBusiness scheduleBusiness)
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
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            float totalHours = (float)(Schedule.EndTimeFrame - Schedule.StartTimeFrame).TotalHours;
            var scheduleDTO = new ScheduleDTO
            {
                // Mapping DTO to Model

                ScheduleName = Schedule.ScheduleName,
                StartTimeFrame = Schedule.StartTimeFrame,
                EndTimeFrame = Schedule.EndTimeFrame,
                Price = Schedule.Price,
                TotalHours = totalHours // Thêm TotalHours vào DTO        
            };
            var result = await _scheduleBusiness.Update(Schedule.ScheduleId, scheduleDTO);
            if (result.Status == Const.SUCCESS_UPDATE_CODE)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ErrorMessage = result.Message ?? "Error updating schedule.";
                return Page();
            }
        }
    }
}
