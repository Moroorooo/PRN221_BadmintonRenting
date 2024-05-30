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

        public UnitOfWork() { }

        public BookingBadmintonFieldScheduleRepository BookingBadmintonFieldScheduleRepository
        {
            get
            {
                return _bookingBadmintonFieldSchedule = new BookingBadmintonFieldScheduleRepository();
            }
        }
    }
}
