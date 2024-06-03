
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;


namespace BadmintonRentingData
{
    public class UnitOfWork
    {
        private BookingBadmintonFieldScheduleRepository _bookingBadmintonFieldSchedule;

        private BadmintonFieldReposiory _BadmintonFieldReposiory;

        private Net1702_PRN221_BadmintonRentingContext _context;


        private CustomerRepository _customerRepository;
        private BookingRepository _bookingRepository;
        public UnitOfWork()
        {
            _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository();
            _customerRepository ??= new CustomerRepository();
            _bookingRepository ??= new BookingRepository();
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
        public BadmintonFieldReposiory BadmintonFieldReposiory
        {
            get
            {
                return _BadmintonFieldReposiory = new BadmintonFieldReposiory();
            }
        }
        public BookingRepository BookingRepository
        {
            get
            {
                //return _booking ??= new Repository.BookingRepository();
                return _bookingRepository ??= new BookingRepository(_context);
            }
        }
    }
}
