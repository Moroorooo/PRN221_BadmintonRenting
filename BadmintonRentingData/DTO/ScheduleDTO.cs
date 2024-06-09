using System;

namespace BadmintonRentingData.DTO
{
    public class ScheduleDTO
    {
        public string ScheduleName { get; set; } = null!;
        public DateTime StartTimeFrame { get; set; }
        public DateTime EndTimeFrame { get; set; }
        public double Price { get; set; }
        public double TotalHours { get; set; }  
    }
}
