using ProjectAD_MauroArys.Dtos;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync(RoomQueryDto query);
        Task<Room?> GetByIdAsync(int id);
        Task AddAsync(Room room);
        Task UpdateAsync(Room room);
        Task DeleteAsync(Room room);
        Task<bool> ExistsAsync(int id);
        Task<List<Booking>> GetBookingsAsync(int roomId);
        Task AddBookingAsync(Booking booking);

        Task<Booking?> GetBookingByIdAsync(int id);
        Task DeleteBookingAsync(Booking booking);

    }
}
