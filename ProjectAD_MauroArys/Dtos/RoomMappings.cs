using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Dtos
{
    public static class RoomMappings
    {
        public static RoomDto ToDto(this Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Floor = room.Floor
            };
        }
        public static RoomDetailDto ToDetailDto(this Room room)
        {
            return new RoomDetailDto
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Floor = room.Floor,
                Bookings = room.Bookings.Select(b => b.ToDto()).ToList()
            };
        }

        public static Room ToEntity(this RoomInputDto dto)
        {
            return new Room
            {
                Name = dto.Name,
                Capacity = dto.Capacity,
                Floor = dto.Floor
            };
        }
    }
}
