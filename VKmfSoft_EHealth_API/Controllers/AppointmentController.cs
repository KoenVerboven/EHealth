using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentController(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorAppointmentDTO>>> Get()
        {
            var doctorAppointments = await appointmentRepository.GetAllAsync();
            var doctorAppointmentsDTO = doctorAppointments.Select(da => new DoctorAppointmentDTO
            {
                Id = da.Id,
                PatientId = da.PatientId,
                MedicalWorkerId = da.MedicalWorkerId,
                AppointmentDate = da.AppointmentDate,
                ReasonForVisit = da.ReasonForVisit,
                Notes = da.Notes,
                Status = da.Status,
                DegreeOfUrgency = da.DegreeOfUrgency,
                AppointmentPlaceId = da.AppointmentPlaceId
            });
            return Ok(doctorAppointmentsDTO);
        }

    }
}
