using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HospitalDTO>>> Get()
        {
            var hospitals = await _hospitalRepository.GetAllAsync();
            var hospitalsDTO = hospitals.Select(h => new HospitalDTO
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                PhoneNumber = h.PhoneNumber,
                Email = h.Email
            });
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
            
            var hospital = new Hospital
            {
                Name = hospitalCreateDTO.Name,
                Address = hospitalCreateDTO.Address,
                PhoneNumber = hospitalCreateDTO.PhoneNumber,
                Email = hospitalCreateDTO.Email
            };

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
            var hospitalsDTO =  new HospitalDTO
            {
                Id = hospital.Id,
                Name = hospital.Name,
                Address = hospital.Address,
                PhoneNumber = hospital.PhoneNumber,
                Email = hospital.Email
            };

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

            var hospital = new Hospital
            {
                Name = hospitalUpdateDTO.Name,
                Address = hospitalUpdateDTO.Address,
                PhoneNumber = hospitalUpdateDTO.PhoneNumber,
                Email = hospitalUpdateDTO.Email
            };

            await _hospitalRepository.UpdateAsync(hospital);
            return CreatedAtAction(nameof(GetHospitalById), new { id = hospital.Id }, hospital);
        }


    }
}
