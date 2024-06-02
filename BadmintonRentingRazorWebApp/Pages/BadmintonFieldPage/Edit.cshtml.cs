using BadmintonRentingData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BadmintonRentingRazorWebApp.Pages.BadmintonFieldPage
{
    public class EditModel : PageModel
    {
        private readonly BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext _context;

        public EditModel(BadmintonRentingData.Model.Net1702_PRN221_BadmintonRentingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BadmintonField BadmintonField { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BadmintonField = await _context.BadmintonFields.FirstOrDefaultAsync(m => m.BadmintonFieldId == id);

            if (BadmintonField == null)
            {
                return NotFound();
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

            // Define the allowed range for StartTime and EndTime
            var minHour = 4; // Example: 6 AM
            var maxHour = 21; // Example: 10 PM

            // Extract hour component of StartTime and EndTime
            var startHour = BadmintonField.StartTime.Hours;
            var endHour = BadmintonField.EndTime.Hours;

            // Check if StartTime and EndTime are within the allowed range
            if (startHour < minHour || startHour > maxHour)
            {
                ModelState.AddModelError("BadmintonField.StartTime", "Start Time must be between 4 AM and 9 PM.");
                return Page();
            }

            if (endHour < minHour || endHour > maxHour)
            {
                ModelState.AddModelError("BadmintonField.EndTime", "End Time must be between 4 AM and 9 PM.");
                return Page();
            }

            _context.Attach(BadmintonField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BadmintonFieldExists(BadmintonField.BadmintonFieldId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BadmintonFieldExists(long id)
        {
            return _context.BadmintonFields.Any(e => e.BadmintonFieldId == id);
        }
    }
}
