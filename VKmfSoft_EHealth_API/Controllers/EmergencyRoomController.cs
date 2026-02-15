using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;



namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyRoomController : ControllerBase
    {
        private readonly IEmergencyRoomRepository _emergencyRoomRepository;
        private readonly IMapper _mapper;

        public EmergencyRoomController(IEmergencyRoomRepository emergencyRoomRepository, IMapper mapper)
        {
            _emergencyRoomRepository = emergencyRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmergencyRoom>>> Get()
        {
            var emergencyRooms = await _emergencyRoomRepository.GetAllAsync();

            var emergencyRoomDTO = _mapper.Map<List<EmergencyRoomDTO>>(emergencyRooms);
            return Ok(emergencyRoomDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(EmergencyRoomDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmergencyRoomDTO>> GetEmergencyRoomById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var emergencyRoom = await _emergencyRoomRepository.GetByIdAsync(id);

            if (emergencyRoom == null)
            {
                return NotFound();
            }

            var emergencyRoomDTO = _mapper.Map<EmergencyRoomDTO>(emergencyRoom);
            return Ok(emergencyRoomDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmergencyRoom>> AddEmergencyRoom(EmergencyRoomCreateDTO emergencyRoomCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var emergencyRoom = _mapper.Map<EmergencyRoom>(emergencyRoomCreateDTO);
            await _emergencyRoomRepository.AddAsync(emergencyRoom);
            return CreatedAtAction(nameof(GetEmergencyRoomById), new { id = emergencyRoom.Id }, emergencyRoom);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateEmergencyRoom(int id, EmergencyRoomUpdateDTO emergencyRoomUpdateDTO)
        {
            if (id != emergencyRoomUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var emergencyRoom = _mapper.Map<EmergencyRoom>(emergencyRoomUpdateDTO);
            await _emergencyRoomRepository.UpdateAsync(emergencyRoom);
            return CreatedAtAction(nameof(GetEmergencyRoomById), new { id = emergencyRoom.Id }, emergencyRoom);
        }

    }
}
