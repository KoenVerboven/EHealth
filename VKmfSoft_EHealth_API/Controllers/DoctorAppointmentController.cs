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

        public DoctorAppointmentController(IDoctorAppointmentRepository appointmentRepository)
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
                MedicalWorkerId = doctorAppointment.DoctorId,
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
                MedicalWorkerId = doctorAppointment.DoctorId,
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
                DoctorId = doctorAppointmentCreateDTO.MedicalWorkerId,
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

            var doctorAppointment = new DoctorAppointment
            {
                Id = doctorAppointmentUpdateDTO.Id,
                PatientId = doctorAppointmentUpdateDTO.PatientId,
                DoctorId = doctorAppointmentUpdateDTO.MedicalWorkerId,
                AppointmentDate = doctorAppointmentUpdateDTO.AppointmentDate,
                ReasonForVisit = doctorAppointmentUpdateDTO.ReasonForVisit,
                Notes = doctorAppointmentUpdateDTO.Notes,
                Status = doctorAppointmentUpdateDTO.Status,
                DegreeOfUrgency = doctorAppointmentUpdateDTO.DegreeOfUrgency,
                AppointmentPlaceId = doctorAppointmentUpdateDTO.AppointmentPlaceId
            };

            await _appointmentRepository.UpdateAsync(doctorAppointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = doctorAppointment.Id }, doctorAppointment);
        }

    }
}
