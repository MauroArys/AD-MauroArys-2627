using Microsoft.AspNetCore.Mvc;
using ProjectAD_MauroArys.Data;
using ProjectAD_MauroArys.Dtos;

namespace ProjectAD_MauroArys.Controllers
{
    [ApiController]
    [Route("rooms/{roomId}/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly RoomRepository _repository = new();
        

        [HttpGet]
        public async Task<IActionResult> GetAll(int roomId)
        {
            if (!await _repository.ExistsAsync(roomId))
                return NotFound();

            var bookings = await _repository.GetBookingsAsync(roomId);
            return Ok(bookings.Select(b => b.ToDto()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(int roomId, BookingInputDto dto)
        {
            if (!await _repository.ExistsAsync(roomId))
                return NotFound();

            var booking = dto.ToEntity();
            booking.RoomId = roomId;

            await _repository.AddBookingAsync(booking);

            return Created($"/rooms/{roomId}/bookings/{booking.Id}", booking.ToDto());
        }
    }
}
