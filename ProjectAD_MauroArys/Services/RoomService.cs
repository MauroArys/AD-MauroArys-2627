using ProjectAD_MauroArys.Data;
using ProjectAD_MauroArys.Dtos;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        // ---------------- ROOMS ----------------

        public async Task<List<RoomDto>> GetAllAsync(RoomQueryDto query)
        {
            var rooms = await _repository.GetAllAsync(query);
            return rooms.Select(r => r.ToDto()).ToList();
        }

        public async Task<RoomDetailDto?> GetByIdAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            return room?.ToDetailDto();
        }

        public async Task<RoomDto?> CreateAsync(RoomInputDto dto)
        {
            // Geen ExistsByNameAsync in jouw repository → verwijderen
            var room = dto.ToEntity();
            await _repository.AddAsync(room);
            return room.ToDto();
        }

        public async Task<bool> UpdateAsync(int id, RoomInputDto dto)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room is null)
                return false;

            room.Name = dto.Name;
            room.Capacity = dto.Capacity;
            room.Floor = dto.Floor;

            await _repository.UpdateAsync(room);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room is null)
                return false;

            await _repository.DeleteAsync(room);
            return true;
        }

        // ---------------- BOOKINGS ----------------

        public async Task<List<BookingDto>?> GetBookingsAsync(int roomId)
        {
            if (!await _repository.ExistsAsync(roomId))
                return null;

            var bookings = await _repository.GetBookingsAsync(roomId);
            return bookings.Select(b => b.ToDto()).ToList();
        }

        public async Task<BookingDto?> AddBookingAsync(int roomId, BookingInputDto dto)
        {
            // 1. Room moet bestaan
            if (!await _repository.ExistsAsync(roomId))
                return null;

            // 2. EndTime > StartTime
            if (dto.EndTime <= dto.StartTime)
                return null;

            // 3. Overlap-check
            var existing = await _repository.GetBookingsAsync(roomId);

            bool overlap = existing.Any(b =>
                dto.StartTime < b.EndTime &&
                b.StartTime < dto.EndTime);

            if (overlap)
                return null;

            // 4. Booking aanmaken
            var booking = dto.ToEntity();
            booking.RoomId = roomId;

            await _repository.AddBookingAsync(booking);
            return booking.ToDto();
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            // 1. Bestaat booking?
            var booking = await _repository.GetBookingByIdAsync(bookingId);

            if (booking is null)
                return false;

            // 2. Verwijderen
            await _repository.DeleteBookingAsync(booking);
            return true;
        }
    }
}
