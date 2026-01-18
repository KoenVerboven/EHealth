using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseRepository _nurseRepository;

        public NurseController(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }
    }
}
