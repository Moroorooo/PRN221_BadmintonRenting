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
                        // Nếu tìm kiếm thành công, gán kết quả vào biến Customer
                        Customer = (List<Customer>)result.Data;
                    }
                    else
                    {
                        // Nếu tìm kiếm thất bại, khởi tạo danh sách Customer rỗng.
                        Customer = new List<Customer>();
                    }
                }
                else
                {
                    var result = await _customerBusiness.GetAllPaged(PageNumber, PageSize);
                    if (result.Status == Const.SUCCESS_READ_CODE)
                    {
                        // Nếu thành công, gán kết quả vào biến pagedResult.
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
            // Kiểm tra xem chuỗi đầu vào có thể chuyển đổi thành kiểu int hay không.
            if (int.TryParse(phoneStr, out int phone))
            {
                return phone;
            }
            return null;
        }

    }
    
}
