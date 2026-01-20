using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Repositories.Interfaces;


namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnePersonPatientRoomController : ControllerBase
    {
        private readonly IOnePersonPatientRoomRepository _onePersonPatientRoomRepository;

        public OnePersonPatientRoomController(IOnePersonPatientRoomRepository onePersonPatientRoomRepository )
        {
            _onePersonPatientRoomRepository = onePersonPatientRoomRepository;
        }
    }
}
