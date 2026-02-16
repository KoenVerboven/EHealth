using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorePersonPatientRoomController : ControllerBase
    {
        private readonly IMorePersonPatientRoomRepository _morePersonPatientRoomRepository;
        private readonly IMapper _mapper;

        public MorePersonPatientRoomController(IMorePersonPatientRoomRepository morePersonPatientRoomRepository, IMapper mapper)
        {
            _morePersonPatientRoomRepository = morePersonPatientRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MorePersonPatientRoomUpdateDTO>>> Get()
        {
            var morePersonRooms = await _morePersonPatientRoomRepository.GetAllAsync();
            var morePersonRoomsDTO = _mapper.Map<IEnumerable<MorePersonPatientRoomDTO>>(morePersonRooms);
            return Ok(morePersonRoomsDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(MorePersonPatientRoomDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<OnePersonPatientRoomDTO>> GetMorePersonRoomById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var morePersonPatientRoom = await _morePersonPatientRoomRepository.GetByIdAsync(id);

            if (morePersonPatientRoom == null)
            {
                return NotFound();
            }

            var morePersonPatientRoomDTO = _mapper.Map<MorePersonPatientRoomDTO>(morePersonPatientRoom);
            return Ok(morePersonPatientRoomDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Doctor>> AddMorePersonPatientRoom(MorePersonPatientRoomCreateDTO morePersonPatientRoomCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var morePersonPatientRoom = _mapper.Map<MorePersonPatientRoom>(morePersonPatientRoomCreateDTO);
            await _morePersonPatientRoomRepository.AddAsync(morePersonPatientRoom);
            return CreatedAtAction(nameof(GetMorePersonRoomById), new { id = morePersonPatientRoom.Id }, morePersonPatientRoom);
        }
    }
}
