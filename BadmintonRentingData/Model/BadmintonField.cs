using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BadmintonRentingData.Model
{
    public partial class BadmintonField
    {
        public BadmintonField()
        {
            BookingBadmintonFieldSchedules = new HashSet<BookingBadmintonFieldSchedule>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BadmintonFieldId { get; set; }
        public string BadmintonFieldName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Boolean IsActive { get; set; }

        public virtual ICollection<BookingBadmintonFieldSchedule> BookingBadmintonFieldSchedules { get; set; }
    }
}
