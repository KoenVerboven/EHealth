using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class DoctorAppointment
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "ReasonForVisit is required.")]
        public required string ReasonForVisit { get; set; }
        public string? CancellingReason { get; set; }
        public string? Notes { get; set; }
        public byte Status { get; set; } // Scheduled, Completed, CanceledByPatient, CanceledByDoctor
        public int DegreeOfUrgency { get; set; }
        public int AppointmentPlaceId { get; set; } //home visit or practice
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int Updatedby { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}
