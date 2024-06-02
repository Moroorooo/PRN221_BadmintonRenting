using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData
{
    public class UnitOfWork
    {
        private BookingBadmintonFieldScheduleRepository _bookingBadmintonFieldSchedule;
        private Net1702_PRN221_BadmintonRentingContext _context;

        public UnitOfWork() 
        {
            _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository();
        }

        public BookingBadmintonFieldScheduleRepository BookingBadmintonFieldScheduleRepository
        {
            get
            {
                return _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository(_context);
            }
        }
    }
}
