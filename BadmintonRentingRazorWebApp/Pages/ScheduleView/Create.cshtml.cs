using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;
using BadmintonRentingData.DTO;

namespace BadmintonRentingRazorWebApp.Pages.ScheduleView
{
    public class CreateModel : PageModel
    {
        private readonly IScheduleBusiness _scheduleBusiness;

        public CreateModel(IScheduleBusiness scheduleBusiness)
        {
            _scheduleBusiness = scheduleBusiness;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public Schedule Schedule { get; set; } = new Schedule();



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Tính toán TotalHours
           double totalHours = (double)(Schedule.EndTimeFrame - Schedule.StartTimeFrame).TotalHours;

            // Mapping DTO to Model
            var scheduleDTO = new ScheduleDTO
            {
                ScheduleName = Schedule.ScheduleName,
                StartTimeFrame = Schedule.StartTimeFrame,
                EndTimeFrame = Schedule.EndTimeFrame,
                Price = Schedule.Price,
                TotalHours = totalHours // Thêm TotalHours vào DTO
            };

            var result = await _scheduleBusiness.Create(scheduleDTO);

            if (result.Status == Const.SUCCESS_CREATE_CODE)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "Error creating schedule.");
                return Page();
            }
        }
    }
}
