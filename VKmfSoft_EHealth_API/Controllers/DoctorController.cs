using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> Get()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            var doctorDTO = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            return Ok(doctorDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> GetDoctorById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var doctorDTO = _mapper.Map<DoctorDTO>(doctor);
            return Ok(doctorDTO);
        }

        [HttpGet("getDoctorByFilter")]
        [ProducesResponseType(typeof(IEnumerable<DoctorDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctorByFilter([FromQuery] string? fullName)
        {
            var doctors = await _doctorRepository.GetDoctorByFilterAsync(fullName);
            var doctorsDTO = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            return Ok(doctorsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Doctor>> AddDoctor(DoctorCreateDTO doctorCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           //var doctorWithSameLicense = await _doctorRepository.GetByLicenseNumberAsync(doctorCreateDTO.LicenseNumber);
           // if (doctorWithSameLicense != null)
           // {
           //     ModelState.AddModelError("LicenseNumber", "A doctor with the same license number already exists.");
           //     return BadRequest(ModelState);
           // }

            Doctor doctor = _mapper.Map<Doctor>(doctorCreateDTO);
     
            await _doctorRepository.AddAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDoctor(int id, DoctorUpdateDTO doctorUpdateDTO)
        {
            if (id != doctorUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Doctor doctor = _mapper.Map<Doctor>(doctorUpdateDTO);
            await _doctorRepository.UpdateAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

    }
}
