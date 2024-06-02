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

namespace BadmintonRentingRazorWebApp.Pages.CustomerView
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerBusiness _customerBusiness;

        public IndexModel(ICustomerBusiness customerBusiness)
        {
            _customerBusiness = customerBusiness;
        }

        public IList<Customer> Customer { get; set; } = new List<Customer>();

        public async Task OnGetAsync()
        {
            var result = await _customerBusiness.GetAll();
            if (result.Status == Const.SUCCESS_READ_CODE)
            {
                Customer = (List<Customer>)result.Data;
            }
            else
            {
                
            }
        }
    }
}
