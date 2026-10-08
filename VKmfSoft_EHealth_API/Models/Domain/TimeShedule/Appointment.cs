using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    // RUN MIGRATION TO ADD NEW STRUCTURE TO DATABASE
    // Navigation property to Patient entity can be added later if needed ???!!!!
    // DTO for Appointment entity can be created later if needed ???!!!!
    // DTO for Scanner appointment and Vaccination appointment can be created later if needed ???!!!!

    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }  // Foreign key to Patient
        public string? Notes { get; set; }
        public byte Status { get; set; } // Scheduled, Completed, CanceledByPatient, CanceledByDoctor
        public string? CancellationReason { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int Updatedby { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
