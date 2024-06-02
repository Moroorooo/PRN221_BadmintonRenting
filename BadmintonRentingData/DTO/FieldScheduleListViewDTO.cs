using BadmintonRentingData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.DTO
{
    public class FieldScheduleListViewDTO
    {
        public long OrderBadmintonFieldScheduleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long BookingId { get; set; }
        public string BadmintonFieldName { get; set; }
        public string ScheduleName { get; set; }
    }
}
