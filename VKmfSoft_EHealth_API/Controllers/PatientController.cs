using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return new List<Patient>
            {
                new()
                {
                    Id = 1,
                    LastName = "Doe",
                    FirstName = "John",
                    Address = "", 
                    Gender = 'M',
                    InsuranceNumber = "INS123456",
                    InsuranceProvider = "HealthCare Inc.",
                    IsMobile = true
                },

                new()
                {
                    Id = 2,
                    LastName = "Smith",
                    FirstName = "Jane",
                    Address = "", 
                     Gender = 'V',
                    InsuranceNumber = "INS654321",
                    InsuranceProvider = "MediPlus",
                    IsMobile = false
                }
            };
        }
    }
}
