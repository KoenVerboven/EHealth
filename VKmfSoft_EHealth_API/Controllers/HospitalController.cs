using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
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
        public async Task<ActionResult<IEnumerable<HospitalDTO>>> Get()
        {
            var hospitals = await hospitalRepository.GetAllAsync();
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
    }
}
