using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.DTO.General;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalWorkerController : ControllerBase
    {
        private readonly IMedicalWorkerRepository medicalWorkerRepository;

        public MedicalWorkerController(IMedicalWorkerRepository medicalWorkerRepository)
        {
            this.medicalWorkerRepository = medicalWorkerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalWorkerDTO>>> Get()
        {
            var medicalWorkers = await medicalWorkerRepository.GetAllAsync();
            var medicalWorkerDTO = medicalWorkers.Select(mw => new MedicalWorkerDTO
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
            return Ok(medicalWorkerDTO);
        }

    }
}
