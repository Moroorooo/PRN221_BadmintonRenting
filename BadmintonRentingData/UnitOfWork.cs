using BadmintonRentingData.Repository;

namespace BadmintonRentingData
{
    public class UnitOfWork
    {
        private BookingBadmintonFieldScheduleRepository _bookingBadmintonFieldSchedule;
        private BadmintonFieldReposiory _BadmintonFieldReposiory;

        public UnitOfWork() { }

        public BookingBadmintonFieldScheduleRepository BookingBadmintonFieldScheduleRepository
        {
            get
            {
                return _bookingBadmintonFieldSchedule = new BookingBadmintonFieldScheduleRepository();
            }
        }
        public BadmintonFieldReposiory BadmintonFieldReposiory
        {
            get
            {
                return _BadmintonFieldReposiory = new BadmintonFieldReposiory();
            }
        }
    }
}
