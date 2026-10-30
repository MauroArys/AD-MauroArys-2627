using Microsoft.AspNetCore.Mvc;
using ProjectAD_MauroArys.Dtos;
using ProjectAD_MauroArys.Services;

namespace ProjectAD_MauroArys.Controllers
{
    [ApiController]
    [Route("rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomsController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RoomQueryDto query)
        {
            var rooms = await _service.GetAllAsync(query);
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _service.GetByIdAsync(id);
            if (room is null)
                return NotFound();

            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomInputDto dto)
        {
            var created = await _service.CreateAsync(dto);
            if (created is null)
                return Problem(
                    title: "Er bestaat al een vergaderruimte met deze naam",
                    statusCode: StatusCodes.Status409Conflict);
            return CreatedAtAction(nameof(GetById), new { id = created!.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomInputDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }

}
