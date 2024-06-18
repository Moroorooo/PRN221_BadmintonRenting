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
using BadmintonRentingData.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BadmintonRentingRazorWebApp.Pages.FieldScheduleView
{
    public class IndexModel : PageModel
    {
        private readonly IBookingBadmintonFieldScheduleBusiness _business;

        public IndexModel(IBookingBadmintonFieldScheduleBusiness business)
        {
            _business = business;
        }

        [BindProperty]
        public long BookingId { get; set; }
        [BindProperty]
        public long BadmintonFieldId { get; set; }
        [BindProperty]
        public long ScheduleId { get; set; }
        [BindProperty]
        public string Message { get; set; }

        public IList<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedule { get;set; } = default!;
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("Role") == null || HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToPage("/Login");
            }
            else
            {
                if (_business != null)
                {
                    var result = await _business.GetAll();
                    if (result.Message != Const.FAIL_READ_MSG)
                    {
                        BookingBadmintonFieldSchedule = (List<BookingBadmintonFieldSchedule>)result.Data;
                    }
                    var badmintonFieldResult = await _business.GetAllBadmintonField();
                    if (badmintonFieldResult.Message != Const.FAIL_READ_MSG)
                    {
                        ViewData["BadmintonField"] = new SelectList((List<BadmintonField>)badmintonFieldResult.Data, "BadmintonFieldId", "BadmintonFieldName");
                    }

                    var bookingResult = await _business.GetAllBooking();
                    if (bookingResult.Message != Const.FAIL_READ_MSG)
                    {
                        ViewData["Booking"] = new SelectList((List<Booking>)bookingResult.Data, "BookingId", "BookingId");
                    }

                    var scheduleResult = await _business.GetAllSchedule();
                    if (scheduleResult.Message != Const.FAIL_READ_MSG)
                    {
                        ViewData["Schedule"] = new SelectList((List<Schedule>)scheduleResult.Data, "ScheduleId", "ScheduleName");
                    }
                }

                return Page();
            }
        }

        public async Task OnPostAsync()
        {
            if (_business != null)
            {
                string action = Request.Form["action"];
                if (action == "Reset")
                {
                    var result = await _business.GetAll();
                    if (result.Message != Const.FAIL_READ_MSG)
                    {
                        BookingBadmintonFieldSchedule = (List<BookingBadmintonFieldSchedule>)result.Data;
                    }
                    var badmintonFieldResult = await _business.GetAllBadmintonField();
                    if (badmintonFieldResult.Message != Const.FAIL_READ_MSG)
                    {
                        ViewData["BadmintonField"] = new SelectList((List<BadmintonField>)badmintonFieldResult.Data, "BadmintonFieldId", "BadmintonFieldName");
                    }

                    var bookingResult = await _business.GetAllBooking();
                    if (bookingResult.Message != Const.FAIL_READ_MSG)
                    {
                        ViewData["Booking"] = new SelectList((List<Booking>)bookingResult.Data, "BookingId", "BookingId");
                    }

                    var scheduleResult = await _business.GetAllSchedule();
                    if (scheduleResult.Message != Const.FAIL_READ_MSG)
                    {
                        ViewData["Schedule"] = new SelectList((List<Schedule>)scheduleResult.Data, "ScheduleId", "ScheduleName");
                    }
                }
                else if (action == "Search")
                {
                    var list = new List<BookingBadmintonFieldSchedule>();
                    if (BookingId == 0 && BadmintonFieldId == 0 && ScheduleId == 0)
                    {
                        Message = "If you want to search, at least input the number on the search bar";
                        BookingBadmintonFieldSchedule = list;
                        var badmintonFieldResult = await _business.GetAllBadmintonField();
                        if (badmintonFieldResult.Message != Const.FAIL_READ_MSG)
                        {
                            ViewData["BadmintonField"] = new SelectList((List<BadmintonField>)badmintonFieldResult.Data, "BadmintonFieldId", "BadmintonFieldName");
                        }

                        var bookingResult = await _business.GetAllBooking();
                        if (bookingResult.Message != Const.FAIL_READ_MSG)
                        {
                            ViewData["Booking"] = new SelectList((List<Booking>)bookingResult.Data, "BookingId", "BookingId");
                        }

                        var scheduleResult = await _business.GetAllSchedule();
                        if (scheduleResult.Message != Const.FAIL_READ_MSG)
                        {
                            ViewData["Schedule"] = new SelectList((List<Schedule>)scheduleResult.Data, "ScheduleId", "ScheduleName");
                        }
                    }
                    else
                    {
                        var result = await _business.Search(BookingId, BadmintonFieldId, ScheduleId);
                        if (result.Message != Const.FAIL_READ_MSG)
                        {
                            list = (List<BookingBadmintonFieldSchedule>)result.Data;
                            if (list == null)
                            {
                                Message = "Search Fail";
                            }
                            else if (list.Count == 0)
                            {
                                Message = "Nothing here";
                                BookingBadmintonFieldSchedule = list;
                            }
                            else
                            {
                                Message = null;
                                BookingBadmintonFieldSchedule = list;
                            }
                        }
                        var badmintonFieldResult = await _business.GetAllBadmintonField();
                        if (badmintonFieldResult.Message != Const.FAIL_READ_MSG)
                        {
                            ViewData["BadmintonField"] = new SelectList((List<BadmintonField>)badmintonFieldResult.Data, "BadmintonFieldId", "BadmintonFieldName");
                        }

                        var bookingResult = await _business.GetAllBooking();
                        if (bookingResult.Message != Const.FAIL_READ_MSG)
                        {
                            ViewData["Booking"] = new SelectList((List<Booking>)bookingResult.Data, "BookingId", "BookingId");
                        }

                        var scheduleResult = await _business.GetAllSchedule();
                        if (scheduleResult.Message != Const.FAIL_READ_MSG)
                        {
                            ViewData["Schedule"] = new SelectList((List<Schedule>)scheduleResult.Data, "ScheduleId", "ScheduleName");
                        }
                    }
                }
            }
        }
    }
}
