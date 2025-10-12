using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models
{
    public class PatientSurgery
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        [Required(ErrorMessage = "SurgeryType is required.")]
        public required int SurgeryTypeId { get; set; }
        public DateTime SurgeryDate { get; set; }
        public int PerformingMedicalWorkerId { get; set; }
        public int HospitalNameId { get; set; }
        public string? Notes { get; set; }
        public int StatusId { get; set; } // e.g., Completed, Scheduled, Canceled
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
    }
}
