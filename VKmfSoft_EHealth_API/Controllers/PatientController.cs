using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;


namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> Get()
        {
            var patients = await patientRepository.GetAllAsync();
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
    }
}
