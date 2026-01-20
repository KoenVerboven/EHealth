using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorePersonPatientRoomController : ControllerBase
    {
        private readonly IMorePersonPatientRoomRepository _morePersonPatientRoomRepository;

        public MorePersonPatientRoomController(IMorePersonPatientRoomRepository morePersonPatientRoomRepository)
        {
            _morePersonPatientRoomRepository = morePersonPatientRoomRepository;
        }
    }
}
