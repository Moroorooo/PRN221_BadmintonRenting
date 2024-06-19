using BadmintonRentingBusiness;
using BadmintonRentingData;
using BadmintonRentingData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BadmintonRentingRazorWebApp.Pages.BadmintonFieldPage
{
    public class IndexModel : PageModel
    {
        private readonly IBadmintonFieldBusiness badmintonFieldBusiness;

        public IndexModel(UnitOfWork unitOfWork)
        {
            badmintonFieldBusiness ??= new BadmintonFieldBusiness(unitOfWork);
        }

        public IList<BadmintonField> BadmintonField { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchFieldName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchAddress { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchDescription { get; set; }
        [BindProperty(SupportsGet = true)]
        public TimeSpan? SearchStartTime { get; set; }
        [BindProperty(SupportsGet = true)]
        public TimeSpan? SearchEndTime { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool? SearchIsActive { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToPage("/Login");
            }
            else
            {
                var result = await badmintonFieldBusiness.GetAll();
                if (result != null && result.Status > 0 && result.Data != null)
                {
                    BadmintonField = result.Data as List<BadmintonField>;

                    if (!string.IsNullOrEmpty(SearchFieldName))
                    {
                        BadmintonField = BadmintonField.Where(f => f.BadmintonFieldName.Contains(SearchFieldName, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    if (!string.IsNullOrEmpty(SearchAddress))
                    {
                        BadmintonField = BadmintonField.Where(f => f.Address.Contains(SearchAddress, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    if (!string.IsNullOrEmpty(SearchDescription))
                    {
                        BadmintonField = BadmintonField.Where(f => f.Description.Contains(SearchDescription, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    if (SearchStartTime.HasValue)
                    {
                        BadmintonField = BadmintonField.Where(f => f.StartTime == SearchStartTime.Value).ToList();
                    }

                    if (SearchEndTime.HasValue)
                    {
                        BadmintonField = BadmintonField.Where(f => f.EndTime == SearchEndTime.Value).ToList();
                    }

                    if (SearchIsActive.HasValue)
                    {
                        BadmintonField = BadmintonField.Where(f => f.IsActive == SearchIsActive.Value).ToList();
                    }
                }
                return Page();
            }

        }
    }
}
