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

namespace BadmintonRentingRazorWebApp.Pages.BookingView
{
    public class CreateModel : PageModel
    {
        private readonly IBookingBusiness _business;

        public CreateModel(IBookingBusiness business)
        {
            _business = business;
        }

        public async Task<IActionResult> OnGet()
        {
            var customerData = await _business.GetAllCustomer();
            if (customerData.Message == Const.FAIL_READ_MSG)
            {
                return NotFound();
            }
            else
            {
                ViewData["CustomerId"] = new SelectList((List<Customer>)customerData.Data, "CustomerName", "CustomerId");
            }
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        [BindProperty]
        public string Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _business == null || Booking == null)
            {
                return Page();
            }

            var result = await _business.Create(Booking);
            if (result.Message == Const.FAIL_READ_MSG)
            {
                Message = "Create Fail!!!";
                return Page();
            }
            else
            {
                return RedirectToPage("./Index");
            }
        }
    }
}
