namespace ProjectAD_MauroArys.Dtos
{
    public class RoomDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public List<BookingDto> Bookings { get; set; } = new();
    }
}
