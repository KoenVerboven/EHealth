using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {
        private readonly IDoctorAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public DoctorAppointmentController(IDoctorAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorAppointmentDTO>>> Get()
        {
            var doctorAppointments = await _appointmentRepository.GetAllAsync();
            var doctorAppointmentsDTO = _mapper.Map<List<DoctorAppointmentDTO>>(doctorAppointments);
            return Ok(doctorAppointmentsDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(DoctorAppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DoctorAppointmentDTO>> GetAppointmentById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var doctorAppointment = await _appointmentRepository.GetByIdAsync(id);

            if (doctorAppointment == null)
            {
                return NotFound();
            }

            var doctorAppointmentDTO = _mapper.Map<DoctorAppointmentDTO>(doctorAppointment);
            return Ok(doctorAppointmentDTO);
        }

        [HttpGet("getByPatientId")]
        [ProducesResponseType(typeof(DoctorAppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DoctorAppointmentDTO>> GetAppointmentByPatientId(int patientId, DateTime startDate, DateTime endDate)
        {
            if (patientId == 0)
            {
                return BadRequest();
            }

            var doctorAppointment = await _appointmentRepository.GetByPatientIdAsync(patientId,startDate,endDate);

            if (doctorAppointment == null)
            {
                return NotFound();
            }

            var doctorAppointmentDTO = _mapper.Map<DoctorAppointmentDTO>(doctorAppointment);
            return Ok(doctorAppointmentDTO);
        }

        [HttpGet("getByDoctorId")]
        [ProducesResponseType(typeof(DoctorAppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DoctorAppointmentDTO>> GetAppointmentByDoctorId(int doctorId, DateTime startDate, DateTime endDate)
        {
            if (doctorId == 0)
            {
                return BadRequest();
            }

            var doctorAppointment = await _appointmentRepository.GetByDoctorIdAsync(doctorId,startDate,endDate );

            if (doctorAppointment == null)
            {
                return NotFound();
            }

            var doctorAppointmentDTO = _mapper.Map<DoctorAppointmentDTO>(doctorAppointment);
            return Ok(doctorAppointmentDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Hospital>> AddDoctorAppointment(DoctorAppointmentCreateDTO doctorAppointmentCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var doctorAppointment = _mapper.Map<DoctorAppointment>(doctorAppointmentCreateDTO);
            await _appointmentRepository.AddAsync(doctorAppointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = doctorAppointment.Id }, doctorAppointment);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDoctorAppointment(int id, DoctorAppointmentUpdateDTO doctorAppointmentUpdateDTO)
        {
            if (id != doctorAppointmentUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var doctorAppointment = _mapper.Map<DoctorAppointment>(doctorAppointmentUpdateDTO);
            await _appointmentRepository.UpdateAsync(doctorAppointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = doctorAppointment.Id }, doctorAppointment);
        }

    }
}
