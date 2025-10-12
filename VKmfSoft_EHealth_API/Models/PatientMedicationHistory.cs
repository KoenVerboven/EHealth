using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models
{
    public class PatientMedicationHistory
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicationId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PrescribingDoctorId { get; set; }
        public string? Notes { get; set; }
    }
}
