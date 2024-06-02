using BadmintonRentingData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BadmintonRentingRazorWebApp.Pages.BadmintonFieldPage
{
    public class CreateModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public CreateModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BadmintonField BadmintonField { get; set; } = new BadmintonField();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure BadmintonField is not null
            if (BadmintonField == null)
            {
                ModelState.AddModelError(string.Empty, "BadmintonField is null.");
                return Page();
            }

            // Define the allowed range for StartTime and EndTime
            var minHour = 4; // 6 AM
            var maxHour = 21; // 10 PM

            // Extract hour component of StartTime and EndTime
            var startHour = BadmintonField.StartTime.Hours;
            var endHour = BadmintonField.EndTime.Hours;

            // Check if StartTime and EndTime are within the allowed range
            if (startHour < minHour || startHour > maxHour)
            {
                ModelState.AddModelError("BadmintonField.StartTime", "Start Time must be between 4 AM and 9 PM.");
            }

            if (endHour < minHour || endHour > maxHour)
            {
                ModelState.AddModelError("BadmintonField.EndTime", "End Time must be between 4 AM and 9 PM.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BadmintonFields.Add(BadmintonField);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
