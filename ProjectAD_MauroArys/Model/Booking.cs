namespace ProjectAD_MauroArys.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string BookedBy { get; set; } = "";

        public int RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
