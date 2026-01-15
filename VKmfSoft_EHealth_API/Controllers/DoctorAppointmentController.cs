using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorAppointmentController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorAppointmentDTO>>> Get()
        {
            var doctorAppointments = await _appointmentRepository.GetAllAsync();
            var doctorAppointmentsDTO = doctorAppointments.Select(doctorAppointment => new DoctorAppointmentDTO
            {
                Id = doctorAppointment.Id,
                PatientId = doctorAppointment.PatientId,
                MedicalWorkerId = doctorAppointment.MedicalWorkerId,
                AppointmentDate = doctorAppointment.AppointmentDate,
                ReasonForVisit = doctorAppointment.ReasonForVisit,
                Notes = doctorAppointment.Notes,
                Status = doctorAppointment.Status,
                DegreeOfUrgency = doctorAppointment.DegreeOfUrgency,
                AppointmentPlaceId = doctorAppointment.AppointmentPlaceId
            });
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
            var hospitalsDTO = new DoctorAppointmentDTO
            {
                Id = doctorAppointment.Id,
                PatientId = doctorAppointment.PatientId,
                MedicalWorkerId = doctorAppointment.MedicalWorkerId,
                AppointmentDate = doctorAppointment.AppointmentDate,
                ReasonForVisit = doctorAppointment.ReasonForVisit,
                Notes = doctorAppointment.Notes,
                Status = doctorAppointment.Status,
                DegreeOfUrgency = doctorAppointment.DegreeOfUrgency,
                AppointmentPlaceId = doctorAppointment.AppointmentPlaceId
            };

            return Ok(hospitalsDTO);
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


            DoctorAppointment doctorAppointment = new DoctorAppointment
            {
                Id = doctorAppointmentCreateDTO.Id,
                PatientId = doctorAppointmentCreateDTO.PatientId,
                MedicalWorkerId = doctorAppointmentCreateDTO.MedicalWorkerId,
                AppointmentDate = doctorAppointmentCreateDTO.AppointmentDate,
                ReasonForVisit = doctorAppointmentCreateDTO.ReasonForVisit,
                Notes = doctorAppointmentCreateDTO.Notes,
                Status = doctorAppointmentCreateDTO.Status,
                DegreeOfUrgency = doctorAppointmentCreateDTO.DegreeOfUrgency,
                AppointmentPlaceId = doctorAppointmentCreateDTO.AppointmentPlaceId
            };

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

    }
}
