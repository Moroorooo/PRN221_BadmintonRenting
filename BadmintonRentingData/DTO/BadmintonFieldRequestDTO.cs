namespace BadmintonRentingData.DTO
{
    public class BadmintonFieldRequestDTO
    {
        public string BadmintonFieldName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Boolean IsActive { get; set; }
    }
}
