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

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;

        public CreateModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerDTO = new CustomerRequestDTO
            {
                CustomerName = Customer.CustomerName,
                Phone = Customer.Phone,
                Email = Customer.Email,
                IsStatus = Customer.IsStatus
            };

            var result = await _customerBusiness.Create(customerDTO);

            if (result.Status == Const.SUCCESS_CREATE_CODE)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, result.Message ?? "Error creating customer.");
                return Page();
            }
        }
    }
}
