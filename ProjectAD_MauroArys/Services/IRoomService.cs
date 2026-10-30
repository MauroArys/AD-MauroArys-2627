using ProjectAD_MauroArys.Dtos;

namespace ProjectAD_MauroArys.Services
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetAllAsync(RoomQueryDto query);
        Task<RoomDetailDto?> GetByIdAsync(int id);
        Task<RoomDto?> CreateAsync(RoomInputDto dto);
        Task<bool> UpdateAsync(int id, RoomInputDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<BookingDto>?> GetBookingsAsync(int roomId);
        Task<BookingDto?> AddBookingAsync(int roomId, BookingInputDto dto);
        Task<bool> DeleteBookingAsync(int bookingId);

    }
}
