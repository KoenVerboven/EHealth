using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

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
        public async Task<ActionResult<Hospital>> AddClass(HospitalCreateDTO hospitalCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Hospital hospital = new Hospital
            {
                Name = hospitalCreateDTO.Name,
                Address = hospitalCreateDTO.Address,
                PhoneNumber = hospitalCreateDTO.PhoneNumber,
                Email = hospitalCreateDTO.Email
            };

            await _hospitalRepository.AddAsync(hospital);
            return CreatedAtAction(nameof(GetClassById), new { id = hospital.Id }, hospital);
        }


        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> GetClassById(int id)
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


    }
}
