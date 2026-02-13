using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MorePersonPatientRoomController : ControllerBase
    {
        private readonly IMorePersonPatientRoomRepository _morePersonPatientRoomRepository;
        private readonly IMapper _mapper;

        public MorePersonPatientRoomController(IMorePersonPatientRoomRepository morePersonPatientRoomRepository, IMapper mapper)
        {
            _morePersonPatientRoomRepository = morePersonPatientRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnePersonPatientRoomDTO>>> Get()
        {
            var morePersonRooms = await _morePersonPatientRoomRepository.GetAllAsync();
            var morePersonRoomsDTO = _mapper.Map<IEnumerable<MorePersonPatientRoomDTO>>(morePersonRooms);
            return Ok(morePersonRoomsDTO);
        }
    }
}
