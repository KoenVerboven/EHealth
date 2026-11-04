using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;

namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class DoctorAppointment : Appointment
    {
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "ReasonForVisit is required.")]
        public required string ReasonForVisit { get; set; }
        public int DegreeOfUrgency { get; set; }
        public int AppointmentPlaceId { get; set; } //home visit or practice
        public  Patient.Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
