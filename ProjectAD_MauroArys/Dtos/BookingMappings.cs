using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Dtos
{
    public static class BookingMappings
    {
        public static BookingDto ToDto(this Booking b)
        {
            return new BookingDto
            {
                Id = b.Id,
                Title = b.Title,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                BookedBy = b.BookedBy
            };
        }

        public static Booking ToEntity(this BookingInputDto dto)
        {
            return new Booking
            {
                Title = dto.Title,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                BookedBy = dto.BookedBy
            };
        }
    }

}
