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

namespace BadmintonRentingRazorWebApp.Pages.BookingView
{
    public class EditModel : PageModel
    {
        private readonly IBookingBusiness _business;

        public EditModel(IBookingBusiness business)
        {
            _business = business;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        [BindProperty]
        public string Message { get; set; } = null;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _business.GetById((long)id);
            if (result.Message == Const.FAIL_READ_MSG)
            {
                return NotFound();
            }
            Booking = (Booking)result.Data;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = await _business.Update(Booking);
            if (result.Message == Const.FAIL_UPDATE_MSG)
            {
                Message = "Update Fail";
                return Page();
            } 
            else
            {

                return RedirectToPage("./Index");
            }
        }
    }
}
