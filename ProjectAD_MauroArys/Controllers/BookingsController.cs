using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAD_MauroArys.Dtos;
using ProjectAD_MauroArys.Services;

namespace ProjectAD_MauroArys.Controllers
{
    [ApiController]
    [Route("rooms/{roomId}/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IRoomService _service;

        public BookingsController(IRoomService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll(int roomId)
        {
            var bookings = await _service.GetBookingsAsync(roomId);
            if (bookings is null)
                return NotFound();

            return Ok(bookings);
        }

  
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(int roomId, BookingInputDto dto)
        {
            var booking = await _service.AddBookingAsync(roomId, dto);

            if (booking is null)
            {
                return Problem(
                    title: "Booking conflict or invalid input.",
                    statusCode: StatusCodes.Status409Conflict);
            }

            return Created($"/rooms/{roomId}/bookings/{booking.Id}", booking);
        }

      
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int roomId, int id)
        {
            var success = await _service.DeleteBookingAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
