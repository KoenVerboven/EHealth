using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Other
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicalWorkerId { get; set; }
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "ReasonForVisit is required.")]
        public required string ReasonForVisit { get; set; }
        public string? Notes { get; set; }
        public int Status { get; set; } // Scheduled, Completed, Canceled
        public int DegreeOfUrgency { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AppointmentPlaceId { get; set; } //home visit or practice


    }
}
