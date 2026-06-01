using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

/*
 * Author: Koen Verboven
 * The controller has been reworked so that we perform the MAPPING MANUALLY instead of with Automapper.
 * Why?
 * test whether it is feasible in the field of :
 * development time, performance, readability and maintainability.
 * 
 */


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
            List<DoctorAppointmentDTO> doctorAppointmentDTOs = new();
            var doctorAppointments = await _appointmentRepository.GetAllAsync();

            foreach (var doctorAppointment in doctorAppointments)
            {
                doctorAppointmentDTOs.Add(
                    new DoctorAppointmentDTO
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
                    }
                );
            }

            return Ok(doctorAppointmentDTOs);
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
           
            var doctorAppointmentDTO = new DoctorAppointmentDTO 
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
            return Ok(doctorAppointmentDTO);
        }

        [HttpGet("getByPatientId/{patientid}/{startdate}/{enddate}")]
        [ProducesResponseType(typeof(DoctorAppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DoctorAppointmentDTO>> GetAppointmentByPatientId(int patientId, DateTime startDate, DateTime endDate)
        {
            List<DoctorAppointmentDTO> doctorAppointmentDTOs = new();

            if (patientId == 0)
            {
                return BadRequest();
            }

            var doctorAppointments = await _appointmentRepository.GetByPatientIdAsync(patientId,startDate,endDate);

            if (doctorAppointments == null)
            {
                return NotFound();
            }

            foreach (var doctorAppointment in doctorAppointments)
            {
                doctorAppointmentDTOs.Add(
                    new DoctorAppointmentDTO
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
                    }
                );
            }

            return Ok(doctorAppointmentDTOs);
        }

        [HttpGet("getByDoctorId/{doctorid}/{startdate}/{enddate}")]
        [ProducesResponseType(typeof(DoctorAppointmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DoctorAppointmentDTO>> GetAppointmentByDoctorId(int doctorId, DateTime startDate, DateTime endDate)
        {
            List<DoctorAppointmentDTO> doctorAppointmentDTOs = new();

            if (doctorId == 0)
            {
                return BadRequest();
            }

            var doctorAppointments = await _appointmentRepository.GetByDoctorIdAsync(doctorId,startDate,endDate );

            if (doctorAppointments == null)
            {
                return NotFound();
            }

            foreach (var doctorAppointment in doctorAppointments)
            {
                doctorAppointmentDTOs.Add(
                    new DoctorAppointmentDTO
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
                    }
                );
            }
            return Ok(doctorAppointmentDTOs);
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

            var doctorAppointment = new DoctorAppointment
            {
                Id = doctorAppointmentCreateDTO.Id,
                PatientId = doctorAppointmentCreateDTO.PatientId,
                DoctorId = doctorAppointmentCreateDTO.MedicalWorkerId,
                AppointmentDate = doctorAppointmentCreateDTO.AppointmentDate,
                ReasonForVisit = doctorAppointmentCreateDTO.ReasonForVisit,
                Notes = doctorAppointmentCreateDTO.Notes,
                Status = (byte)AppointmentStatus.Scheduled,
                DegreeOfUrgency = doctorAppointmentCreateDTO.DegreeOfUrgency,
                AppointmentPlaceId = doctorAppointmentCreateDTO.AppointmentPlaceId,
                CreatedBy = doctorAppointmentCreateDTO.CreatedByPersonId,
                CreatedAt = DateTime.Now
            };

            await _appointmentRepository.AddAsync(doctorAppointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = doctorAppointment.Id }, doctorAppointment);
        }

        [HttpPut("setStatus/{id},{appointmentstatus},{cancellingReason},{userId}")]//todo : testing!!
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateDoctorAppointmentStatus(int id, AppointmentStatus appointmentstatus, string cancellingReason, int userId)
        {
            var doctorAppointment = await _appointmentRepository.GetByIdAsync(id);

            if (doctorAppointment == null)
            {
                return NotFound();
            }

            doctorAppointment.Status = (byte)appointmentstatus;

            if (appointmentstatus == AppointmentStatus.Canceled)
            {
                doctorAppointment.CancellingReason = cancellingReason;
            }

            //doctorAppointment.Updatedby = userId; //todo : get the user id from the token
            //doctorAppointment.UpdateAt = DateTime.Now;

            await _appointmentRepository.UpdateAsync(doctorAppointment);

            return NoContent();
        }

    }
}
