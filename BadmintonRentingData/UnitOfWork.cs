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

        private CustomerRepository _customerRepository;
        public UnitOfWork()
        {
            _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository();
            _customerRepository ??= new CustomerRepository();
        }

        public BookingBadmintonFieldScheduleRepository BookingBadmintonFieldScheduleRepository
        {
            get
            {
                return _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository(_context);
            }
        }

        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository ??= new CustomerRepository(_context);
            }
        }
    }
}
