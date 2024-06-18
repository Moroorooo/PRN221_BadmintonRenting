using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;

namespace BadmintonRentingRazorWebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomerBusiness _business;

        public LoginModel(ICustomerBusiness business)
        {
            _business = business;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Message { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_business == null)
            {
                return Page();
            }
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"appsettings.json", true, true)
                .Build();
            if (Email == config["Admin:Email"] && Password == config["Admin:Password"])
            {
                HttpContext.Session.SetString("Role", "Admin");

                return RedirectToPage("./Index");
            }
            else
            {
                Message = "Wrong Email Or Password!!!";
                return Page();
            }
        }
    }
}
