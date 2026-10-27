namespace ProjectAD_MauroArys.Dtos
{
    public class BookingDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BookedBy { get; set; } = "";
    }
}
