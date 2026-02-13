using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;


namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnePersonPatientRoomController : ControllerBase
    {
        private readonly IOnePersonPatientRoomRepository _onePersonPatientRoomRepository;
        private readonly IMapper _mapper;

        public OnePersonPatientRoomController(IOnePersonPatientRoomRepository onePersonPatientRoomRepository, IMapper mapper )
        {
            _onePersonPatientRoomRepository = onePersonPatientRoomRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OnePersonPatientRoomDTO>>> Get()
        {
            var onePersonRooms = await _onePersonPatientRoomRepository.GetAllAsync();
            var onePersonRoomsDTO = _mapper.Map<IEnumerable<OnePersonPatientRoomDTO>>(onePersonRooms);
            return Ok(onePersonRoomsDTO);
        }
    }
}
