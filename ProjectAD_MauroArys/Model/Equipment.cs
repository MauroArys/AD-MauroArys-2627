namespace ProjectAD_MauroArys.Model
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;
    }
}
