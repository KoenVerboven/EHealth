using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> Get()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            var doctorDTO = doctors.Select(mw => new DoctorDTO
            {
                Id = mw.Id,
                FirstName = mw.FirstName,
                LastName = mw.LastName,
                MiddleName  = mw.MiddleName,
                DateOfBirth = mw.DateOfBirth,   
                Address = mw.Address,
                Gender = mw.Gender,
                PhoneNumber = mw.PhoneNumber,
                Email = mw.Email,
                FirstLanguageID = mw.FirstLanguageID,
                Photo = mw.Photo,
                MedicalTitle = mw.MedicalTitle,
                SpecializationId = mw.SpecializationId,
                LicenseNumber = mw.LicenseNumber,
                LicenseValidUntil = mw.LicenseValidUntil,
                HospitalId = mw.HospitalId,
                DepartmentId = mw.DepartmentId
            });
            return Ok(doctorDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HospitalDTO>> GetDoctorlById(int id)
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
            var doctorDTO = new DoctorDTO
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                MiddleName = doctor.MiddleName,
                DateOfBirth = doctor.DateOfBirth,
                Address = doctor.Address,
                Gender = doctor.Gender,
                PhoneNumber = doctor.PhoneNumber,
                Email = doctor.Email,
                FirstLanguageID = doctor.FirstLanguageID,
                Photo = doctor.Photo,
                MedicalTitle = doctor.MedicalTitle,
                SpecializationId = doctor.SpecializationId,
                LicenseNumber = doctor.LicenseNumber,
                LicenseValidUntil = doctor.LicenseValidUntil,
                HospitalId = doctor.HospitalId,
                DepartmentId = doctor.DepartmentId
            };

            return Ok(doctorDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Hospital>> AddDoctor(DoctorCreateDTO doctorCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var doctor = new Doctor
            {
                FirstName = doctorCreateDTO.FirstName,
                LastName = doctorCreateDTO.LastName,
                MiddleName = doctorCreateDTO.MiddleName,
                DateOfBirth = doctorCreateDTO.DateOfBirth,
                Address = doctorCreateDTO.Address,
                Gender = doctorCreateDTO.Gender,
                PhoneNumber = doctorCreateDTO.PhoneNumber,
                Email = doctorCreateDTO.Email,
                FirstLanguageID = doctorCreateDTO.FirstLanguageID,
                Photo = doctorCreateDTO.Photo,
                MedicalTitle = doctorCreateDTO.MedicalTitle,
                SpecializationId = doctorCreateDTO.SpecializationId,
                LicenseNumber = doctorCreateDTO.LicenseNumber,
                LicenseValidUntil = doctorCreateDTO.LicenseValidUntil,
                HospitalId = doctorCreateDTO.HospitalId,
                DepartmentId = doctorCreateDTO.DepartmentId
            };

            await _doctorRepository.AddAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorlById), new { id = doctor.Id }, doctor);
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

            var doctor = new Doctor
            {
                
                Id= doctorUpdateDTO.Id,
                FirstName = doctorUpdateDTO.FirstName,
                LastName = doctorUpdateDTO.LastName,
                MiddleName = doctorUpdateDTO.MiddleName,
                DateOfBirth = doctorUpdateDTO.DateOfBirth,
                Address = doctorUpdateDTO.Address,
                Gender = doctorUpdateDTO.Gender,
                PhoneNumber = doctorUpdateDTO.PhoneNumber,
                Email = doctorUpdateDTO.Email,
                FirstLanguageID = doctorUpdateDTO.FirstLanguageID,
                Photo = doctorUpdateDTO.Photo,
                MedicalTitle = doctorUpdateDTO.MedicalTitle,
                SpecializationId = doctorUpdateDTO.SpecializationId,
                LicenseNumber = doctorUpdateDTO.LicenseNumber,
                LicenseValidUntil = doctorUpdateDTO.LicenseValidUntil,
                HospitalId = doctorUpdateDTO.HospitalId,
                DepartmentId = doctorUpdateDTO.DepartmentId
            };

            await _doctorRepository.UpdateAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorlById), new { id = doctor.Id }, doctor);
        }

    }
}
