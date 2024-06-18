using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingBusiness;
using BadmintonRentingCommon;
using System.Drawing.Printing;
using BadmintonRentingData.DTO;

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;

        public IndexModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchEmail { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchPhone { get; set; }

        public IList<Customer> Customer { get; set; } = new List<Customer>();
                [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;
        public int TotalCount { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToPage("../Index");
            }
            else
            {
                if (!string.IsNullOrEmpty(SearchName) || !string.IsNullOrEmpty(SearchEmail) || !string.IsNullOrEmpty(SearchPhone))
                {
                    var result = await _customerBusiness.SearchByNameByEmailByPhone(SearchName, SearchEmail, ParsePhone(SearchPhone));
                    if (result.Status == Const.SUCCESS_READ_CODE)
                    {
                        Customer = (List<Customer>)result.Data;
                    }
                    else
                    {
                        Customer = new List<Customer>(); // Handle if search fails
                    }
                }
                else
                {
                    var result = await _customerBusiness.GetAllPaged(PageNumber, PageSize);
                    if (result.Status == Const.SUCCESS_READ_CODE)
                    {
                        var pagedResult = result.Data as PagedResult<Customer>;
                        if (pagedResult != null)
                        {
                            Customer = pagedResult.Items;
                            TotalCount = pagedResult.TotalCount;
                        }
                    }
                    else
                    {
                        Customer = new List<Customer>(); // Handle if GetAll fails
                    }
                }
                 return Page();
            }           
        }

        private int? ParsePhone(string phoneStr)
        {
            if (int.TryParse(phoneStr, out int phone))
            {
                return phone;
            }
            return null;
        }

    }
    
}
