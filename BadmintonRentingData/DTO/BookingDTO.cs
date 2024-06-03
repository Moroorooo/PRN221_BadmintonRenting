using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmintonRentingData.DTO
{
    public class BookingDTO
    {
        public long BookingId { get; set; }
        public DateTime CreatAt { get; set; }
        public double TotalPrice { get; set; }
        public string BookingType { get; set; }
        public bool? CheckInStatus { get; set; }
        public string IsStatus { get; set; }
        public long CustomerId { get; set; }
        public string PaymentType { get; set; }
    }
}
