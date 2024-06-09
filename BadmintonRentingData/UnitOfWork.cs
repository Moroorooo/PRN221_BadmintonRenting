
using BadmintonRentingData.Model;
using BadmintonRentingData.Repository;


namespace BadmintonRentingData
{
    public class UnitOfWork
    {
        private BookingBadmintonFieldScheduleRepository _bookingBadmintonFieldSchedule;

        private BadmintonFieldReposiory _BadmintonFieldReposiory;

        private Net1702_PRN221_BadmintonRentingContext _context;
        private ScheduleRepository _scheduleRepository;

        private CustomerRepository _customerRepository;
        public UnitOfWork()
        {
            _bookingBadmintonFieldSchedule ??= new BookingBadmintonFieldScheduleRepository();
            _customerRepository ??= new CustomerRepository();
            _scheduleRepository ??= new ScheduleRepository();
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
        public ScheduleRepository ScheduleRepository
        {
            get
            {
                return _scheduleRepository ??= new ScheduleRepository(_context);
            }
        }
    }
}
