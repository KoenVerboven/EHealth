using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IMapper _mapper;

        public HospitalController(IHospitalRepository hospitalRepository, IMapper mapper)
        {
            _hospitalRepository = hospitalRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalDTO>>> Get()
        {
            var hospitals = await _hospitalRepository.GetAllAsync();
            var hospitalsDTO = _mapper.Map<List<HospitalDTO>>(hospitals);
            return Ok(hospitalsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Hospital>> AddHospital(HospitalCreateDTO hospitalCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var hospital = _mapper.Map<Hospital>(hospitalCreateDTO);
            await _hospitalRepository.AddAsync(hospital);
            return CreatedAtAction(nameof(GetHospitalById), new { id = hospital.Id }, hospital);
        }


        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> GetHospitalById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var hospital = await _hospitalRepository.GetByIdAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            var hospitalsDTO = _mapper.Map<HospitalDTO>(hospital);
            return Ok(hospitalsDTO);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateHospital(int id, HospitalUpdateDTO hospitalUpdateDTO)
        {
            if (id != hospitalUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var hospital = _mapper.Map<Hospital>(hospitalUpdateDTO);
            await _hospitalRepository.UpdateAsync(hospital);
            return CreatedAtAction(nameof(GetHospitalById), new { id = hospital.Id }, hospital);
        }


    }
}
