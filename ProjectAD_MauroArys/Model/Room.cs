namespace ProjectAD_MauroArys.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Capacity { get; set; }
        public int Floor { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Booking> Bookings { get; set; } = new();


    }
}
