using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;


namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> Get()
        {
            var patients = await _patientRepository.GetAllAsync();
            var patientsDTO = patients.Select(p => new PatientDTO
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Address = p.Address,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                InsuranceNumber = p.InsuranceNumber,
                InsuranceProvider = p.InsuranceProvider,
                IsMobile = p.IsMobile,
                MiddleName = p.MiddleName,
                FirstLanguageID = p.FirstLanguageID,
                Photo = p.Photo,
                InsuranceExpiryDate = p.InsuranceExpiryDate,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhoneNumber = p.EmergencyContactPhoneNumber,
                EmergencyContactDescription = p.EmergencyContactDescription,
                BloodTypeId = p.BloodTypeId,
                PatientHealthHistory = p.PatientHealthHistory
            });
            return Ok(patientsDTO);
        }


        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PatientDTO>> GetPatientById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            var patientsDTO = new PatientDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Address = patient.Address,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                InsuranceNumber = patient.InsuranceNumber,
                InsuranceProvider = patient.InsuranceProvider,
                IsMobile = patient.IsMobile,
                MiddleName = patient.MiddleName,
                FirstLanguageID = patient.FirstLanguageID,
                Photo = patient.Photo,
                InsuranceExpiryDate = patient.InsuranceExpiryDate,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactPhoneNumber = patient.EmergencyContactPhoneNumber,
                EmergencyContactDescription = patient.EmergencyContactDescription,
                BloodTypeId = patient.BloodTypeId,
                PatientHealthHistory = patient.PatientHealthHistory
            };

            return Ok(patientsDTO);
        }

    }
}
