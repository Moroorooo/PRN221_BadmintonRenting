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

        private CustomerRepository _customerRepository;

        public UnitOfWork() { }

        public BookingBadmintonFieldScheduleRepository BookingBadmintonFieldScheduleRepository
        {
            get
            {
                return _bookingBadmintonFieldSchedule = new BookingBadmintonFieldScheduleRepository();
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ??= new CustomerRepository();
            }
        }
    }
}
