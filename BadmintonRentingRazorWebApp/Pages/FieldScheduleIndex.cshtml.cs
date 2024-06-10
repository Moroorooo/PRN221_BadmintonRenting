using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;
using BadmintonRentingData;
using BadmintonRentingData.DTO;
using BadmintonRentingBusiness;

namespace BadmintonRentingRazorWebApp.Pages
{
    public class FieldScheduleIndexModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

       
    }
}
