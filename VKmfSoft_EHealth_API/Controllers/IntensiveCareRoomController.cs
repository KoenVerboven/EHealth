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
    public class IntensiveCareRoomController : ControllerBase
    {
        private readonly IIntensiveCareRoomRepository _intensiveCareRoomRepository;
        private readonly IMapper _mapper;

        public IntensiveCareRoomController(IIntensiveCareRoomRepository intensiveCareRoomRepository, IMapper mapper)
        {
            _intensiveCareRoomRepository = intensiveCareRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntensiveCareRoom>>> Get()
        {
            var intensiveCareRooms = await _intensiveCareRoomRepository.GetAllAsync();
            
            var intensiveCareRoomDTO = _mapper.Map<List<IntensiveCareRoomDTO>>(intensiveCareRooms);
            return Ok(intensiveCareRoomDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(IntensiveCareRoomDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IntensiveCareRoomDTO>> GetIntensiveCareRoomById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var intensiveCareRoom = await _intensiveCareRoomRepository.GetByIdAsync(id);

            if (intensiveCareRoom == null)
            {
                return NotFound();
            }
            
            var intensiveCareRoomDTO = _mapper.Map<IntensiveCareRoomDTO>(intensiveCareRoom);
            return Ok(intensiveCareRoomDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Doctor>> AddDoctor(IntensiveCareRoomCreateDTO intensiveCareRoomCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var intensiveCareRoom = _mapper.Map<IntensiveCareRoom>(intensiveCareRoomCreateDTO);
            await _intensiveCareRoomRepository.AddAsync(intensiveCareRoom);
            return CreatedAtAction(nameof(GetIntensiveCareRoomById), new { id = intensiveCareRoom.Id }, intensiveCareRoom);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateIntensiveCareRoomr(int id, IntensiveCareRoomUpdateDTO intensiveCareRoomUpdateDTO)
        {
            if (id != intensiveCareRoomUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            var intensiveCareRoom = _mapper.Map<IntensiveCareRoom>(intensiveCareRoomUpdateDTO);
             await _intensiveCareRoomRepository.UpdateAsync(intensiveCareRoom);
            return CreatedAtAction(nameof(GetIntensiveCareRoomById), new { id = intensiveCareRoom.Id }, intensiveCareRoom);
        }


    }
}
