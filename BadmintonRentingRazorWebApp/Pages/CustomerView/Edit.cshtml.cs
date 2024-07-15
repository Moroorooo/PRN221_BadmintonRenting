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

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class EditModel : PageModel
    {

        private readonly ICustomerBusiness _customerBusiness;
        public EditModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        public string ErrorMessage { get; set; } = string.Empty;
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _customerBusiness.GetById(id.Value);

            // Kiểm tra nếu trạng thái trả về là thành công và dữ liệu là một đối tượng Customer.
            if (result.Status == Const.SUCCESS_READ_CODE && result.Data is Customer customer)
            {
                Customer = customer;
            }
            else
            {
                ErrorMessage = result.Message ?? "Customer not found.";
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

            var customerDTO = new CustomerRequestDTO
            {
                CustomerName = Customer.CustomerName,
                Phone = Customer.Phone,
                Email = Customer.Email,
                IsStatus = Customer.IsStatus
            };

            var result = await _customerBusiness.Update(Customer.CustomerId, customerDTO);

            if (result.Status == Const.SUCCESS_UPDATE_CODE)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ErrorMessage = result.Message ?? "Error updating customer.";
                return Page();
            }
        }
    }
}
