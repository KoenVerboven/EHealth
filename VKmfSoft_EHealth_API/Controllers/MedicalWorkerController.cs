using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

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

    }
}
