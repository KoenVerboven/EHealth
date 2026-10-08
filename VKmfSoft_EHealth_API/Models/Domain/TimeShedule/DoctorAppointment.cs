using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class DoctorAppointment : Appointment
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "ReasonForVisit is required.")]
        public required string ReasonForVisit { get; set; }
        public int DegreeOfUrgency { get; set; }
        public int AppointmentPlaceId { get; set; } //home visit or practice
    }
}
