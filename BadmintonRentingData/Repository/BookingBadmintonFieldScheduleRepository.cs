using BadmintonRentingData.Base;
using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.Repository
{
    public class BookingBadmintonFieldScheduleRepository : GenericRepository<BookingBadmintonFieldSchedule>
    {
        public BookingBadmintonFieldScheduleRepository()
        {
        }

        public BookingBadmintonFieldScheduleRepository(Net1702_PRN221_BadmintonRentingContext context) => _context = context;

        public async Task<List<BookingBadmintonFieldSchedule>> Search (long? BookingId, long? BadmintonFieldId, long? ScheduleId)
        {
            var context = new Net1702_PRN221_BadmintonRentingContext();
            var list = new List<BookingBadmintonFieldSchedule>();   
            if (BookingId != 0 && BadmintonFieldId != 0 && ScheduleId != 0)
            {
                list = context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.BookingId == BookingId && x.BadmintonField == BadmintonFieldId && x.ScheduleId == ScheduleId).ToList();
            }
            else if (BookingId == 0)
            {
                list = context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.BadmintonField == BadmintonFieldId && x.ScheduleId == ScheduleId).ToList();
            }
            else if (BadmintonFieldId == 0)
            {
                list =  context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.BookingId == BookingId && x.ScheduleId == ScheduleId).ToList();
            }
            else if (ScheduleId == 0f)
            {
                list = context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.BookingId == BookingId && x.BadmintonField == BadmintonFieldId).ToList();
            }
            else if (BookingId == 0 && BadmintonFieldId == 0)
            {
                list = context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.ScheduleId == ScheduleId).ToList();
            }
            else if (BookingId == 0 && ScheduleId == 0)
            {
                list = context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.BadmintonField == BadmintonFieldId).ToList();
            }
            else if (BadmintonFieldId == 0 && ScheduleId == 0)
            {
                list = context.BookingBadmintonFieldSchedules.Where<BookingBadmintonFieldSchedule>(
                    x => x.BadmintonField == BadmintonFieldId).ToList();
            }
            return list;
        }
    }
}
