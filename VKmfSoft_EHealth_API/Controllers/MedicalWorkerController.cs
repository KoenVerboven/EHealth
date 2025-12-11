using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Other;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
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
        public async Task<ActionResult<IEnumerable<MedicalWorker>>> Get()
        {
            var medicalWorkers = await medicalWorkerRepository.GetAllAsync();
            return Ok(medicalWorkers);
        }


    }
}
