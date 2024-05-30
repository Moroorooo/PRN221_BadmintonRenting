using System;
using System.Collections.Generic;

namespace BadmintonRentingData.Model
{
    public partial class Schedule
    {
        public Schedule()
        {
            BookingBadmintonFieldSchedules = new HashSet<BookingBadmintonFieldSchedule>();
        }

        public long ScheduleId { get; set; }
        public string ScheduleName { get; set; } = null!;
        public TimeSpan StartTimeFrame { get; set; }
        public TimeSpan EndTimeFrame { get; set; }
        public double Price { get; set; }
        public TimeSpan TotalHours { get; set; }

        public virtual ICollection<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; }
    }
}
