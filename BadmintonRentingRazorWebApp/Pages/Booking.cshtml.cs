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
using BadmintonRentingBusiness.Business;

namespace BadmintonRentingRazorWebApp.Pages
{
    public class BookingModel : PageModel
    {
        private readonly IBookingBusiness _business;
        public BookingModel(IBookingBusiness business)
        {
            _business = business;
        }
        public string Message { get; set; } = default;
        [BindProperty]


        public IList<BookingDTO> Booking { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_business != null)
            {
                var result = await _business.GetAll();
                var data = (IList<BookingDTO>)result.Data;
                foreach (var entity in data)
                {
                    var dto = new BookingDTO()
                    {
                        BookingId = entity.BookingId,
                        CreatedAt = entity.CreatedAt,
                        TotalPrice = entity.TotalPrice,
                        BookingType = entity.BookingType,
                        CheckInStatus  = entity.CheckInStatus,
                        IsStatus = entity.IsStatus,
                        CustomerId = entity.CustomerId,
                        PaymentType = entity.PaymentType,
                    };
                    Booking.Add(dto);
                }
            }
        }

        public string GetWelcomeMsg()
        {
            return "Welcome Razor Page Web Application";
        }
    }
}
