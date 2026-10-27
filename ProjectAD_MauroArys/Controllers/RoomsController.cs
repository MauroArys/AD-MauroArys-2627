using Microsoft.AspNetCore.Mvc;
using ProjectAD_MauroArys.Data;
using ProjectAD_MauroArys.Dtos;
using ProjectAD_MauroArys.Model;

namespace ProjectAD_MauroArys.Controllers
{
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomRepository _repository = new();

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RoomQueryDto query)
        {
            var rooms = await _repository.GetAllAsync(query);
            return Ok(rooms.Select(r => r.ToDto()));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _repository.GetByIdWithBookingsAsync(id);
            if (room is null)
                return NotFound();

            return Ok(room.ToDetailDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create(RoomInputDto dto)
        {
            var room = dto.ToEntity();
            await _repository.AddAsync(room);

            return CreatedAtAction(nameof(GetById), new { id = room.Id }, room.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomInputDto dto)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room is null)
                return NotFound();

            room.Name = dto.Name;
            room.Capacity = dto.Capacity;
            room.Floor = dto.Floor;

            await _repository.UpdateAsync(room);

            return Ok(room.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var room = await _repository.GetByIdAsync(id);
            if (room is null)
                return NotFound();

            await _repository.DeleteAsync(room);

            return NoContent();
        }
    }

}
