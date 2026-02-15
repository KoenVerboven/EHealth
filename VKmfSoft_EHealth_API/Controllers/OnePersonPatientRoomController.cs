using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;


namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnePersonPatientRoomController : ControllerBase
    {
        private readonly IOnePersonPatientRoomRepository _onePersonPatientRoomRepository;
        private readonly IMapper _mapper;

        public OnePersonPatientRoomController(IOnePersonPatientRoomRepository onePersonPatientRoomRepository, IMapper mapper )
        {
            _onePersonPatientRoomRepository = onePersonPatientRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnePersonPatientRoomDTO>>> Get()
        {
            var onePersonRooms = await _onePersonPatientRoomRepository.GetAllAsync();
            var onePersonRoomsDTO = _mapper.Map<IEnumerable<OnePersonPatientRoomDTO>>(onePersonRooms);
            return Ok(onePersonRoomsDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(OnePersonPatientRoomDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OnePersonPatientRoomDTO>> GetOnePersonRoomById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var onePersonPatientRoom = await _onePersonPatientRoomRepository.GetByIdAsync(id);

            if (onePersonPatientRoom == null)
            {
                return NotFound();
            }

            var onePersonPatientRoomDTO = _mapper.Map<OnePersonPatientRoomDTO>(onePersonPatientRoom);
            return Ok(onePersonPatientRoomDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Doctor>> AddDoctor(OnePersonPatientRoomCreateDTO onePersonPatientRoomCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var onePersonPatientRoom = _mapper.Map<OnePersonPatientRoom>(onePersonPatientRoomCreateDTO);
            await _onePersonPatientRoomRepository.AddAsync(onePersonPatientRoom);
            return CreatedAtAction(nameof(GetOnePersonRoomById), new { id = onePersonPatientRoom.Id }, onePersonPatientRoom);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateOnePatientRoom(int id, OnePersonPatientRoomUpdateDTO onePersonPatientRoomUpdateDTO)
        {
            if (id != onePersonPatientRoomUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var onePersonPatientRoom = _mapper.Map<OnePersonPatientRoom>(onePersonPatientRoomUpdateDTO);
            await _onePersonPatientRoomRepository.UpdateAsync(onePersonPatientRoom);
            return CreatedAtAction(nameof(GetOnePersonRoomById), new { id = onePersonPatientRoom.Id }, onePersonPatientRoom);
        }
    }
}
