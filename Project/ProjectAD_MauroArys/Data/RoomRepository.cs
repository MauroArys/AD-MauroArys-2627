using Microsoft.EntityFrameworkCore;
using ProjectAD_MauroArys.Dtos;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Data
{
    public class RoomRepository
    {
        private readonly AppDbContext _context = new();
        public async Task<List<Room>> GetAllAsync(RoomQueryDto query)
        {
            return await _context.Rooms
                                    .ApplyQuery(query)
                                    .ToListAsync();
        }
        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<Room?> GetByIdWithBookingsAsync(int id)
        {
            return await _context.Rooms
                                    .Include(r => r.Bookings)
                                    .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task AddAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Rooms.AnyAsync(r => r.Id == id);
        }

        public async Task<List<Booking>> GetBookingsAsync(int roomId)
        {
            return await _context.Bookings
                                 .Where(b => b.RoomId == roomId)
                                 .ToListAsync();
        }

        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
    }
