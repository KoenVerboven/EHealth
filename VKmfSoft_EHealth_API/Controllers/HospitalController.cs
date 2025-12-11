using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalRepository hospitalRepository;

        public HospitalController(IHospitalRepository hospitalRepository)
        {
            this.hospitalRepository = hospitalRepository;
        }

        [HttpGet]
        public async Task<ActionResult< IEnumerable<Hospital>>> Get()
        {
            var hospitals = await hospitalRepository.GetAllAsync();
            return Ok(hospitals);
        }

       
    }
}
