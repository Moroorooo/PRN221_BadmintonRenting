
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;


namespace BadmintonRentingData
{
    public class UnitOfWork
    {
        private BookingBadmintonFieldScheduleRepository _bookingBadmintonFieldSchedule;

        private BadmintonFieldReposiory _badmintonFieldReposiory;

        private ScheduleRepository _scheduleRepository;

        private BookingRepository _bookingRepository;


        private Net1702_PRN221_BadmintonRentingContext _context;


        private CustomerRepository _customerRepository;
        public UnitOfWork()
        {
            _badmintonFieldReposiory ??= new BadmintonFieldReposiory();
            _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository();
            _customerRepository ??= new CustomerRepository();
            _badmintonFieldReposiory ??= new BadmintonFieldReposiory();
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
                return _badmintonFieldReposiory ??= new BadmintonFieldReposiory(_context);
            }
        }

        public ScheduleRepository ScheduleRepository
        {
            get
            {
                return _scheduleRepository ??= new ScheduleRepository(_context);
            }
        }

        public BookingRepository BookingRepository
        {
            get
            {
                return _bookingRepository ??= new BookingRepository(_context);
            }
        }
    }
}
