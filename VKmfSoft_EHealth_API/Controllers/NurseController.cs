using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;


namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseRepository _nurseRepository;
        private readonly IMapper _mapper;

        public NurseController(INurseRepository nurseRepository, IMapper mapper)
        {
            _nurseRepository = nurseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseDTO>>> Get()
        {
            var nurses = await _nurseRepository.GetAllAsync();
            var nurseDTO = _mapper.Map<List<NurseDTO>>(nurses);
            return Ok(nurseDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NurseDTO>> GetNurseById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var nurse = await _nurseRepository.GetByIdAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }
            var nurseDTO = _mapper.Map<NurseDTO>(nurse);
            return Ok(nurseDTO);
        }

        [HttpGet("getNurseByFilter")]
        [ProducesResponseType(typeof(IEnumerable<NurseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<NurseDTO>>> GetNurseByFilter([FromQuery] string? fullName)
        {
            var nurses = await _nurseRepository.GetNurseByFilterAsync(fullName);
            var nursesDTO = _mapper.Map<IEnumerable<NurseDTO>>(nurses);
            return Ok(nursesDTO);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Nurse>> AddDoctor(NurseCreateDTO nurseCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var nurse = _mapper.Map<Nurse>(nurseCreateDTO);
            await _nurseRepository.AddAsync(nurse);
            return CreatedAtAction(nameof(GetNurseById), new { id = nurse.Id }, nurse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateNurse(int id, NurseUpdateDTO nurseUpdateDTO)
        {
            if (id != nurseUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var nurse = _mapper.Map<Nurse>(nurseUpdateDTO);
            await _nurseRepository.UpdateAsync(nurse);
            return CreatedAtAction(nameof(GetNurseById), new { id = nurse.Id }, nurse);
        }


    }
}
