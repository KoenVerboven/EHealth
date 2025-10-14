using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models
{
    public class PatientScan
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalHistoryId { get; set; }//FK to PatientMedicalHistory
        public required int ScanTypeId { get; set; }
        public DateTime ScanDate { get; set; }
        public int PerformingMedicalWorkerId { get; set; }
        public string? Notes { get; set; }
        public int StatusId { get; set; } // e.g., Completed, Scheduled, Canceled
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

    }
}
