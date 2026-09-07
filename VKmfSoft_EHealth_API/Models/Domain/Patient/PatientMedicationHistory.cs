using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Medical;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientMedicationHistory
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalRecordId { get; set; }//FK
        public int MedicationId { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PrescribingDoctorId { get; set; }
        public string? Notes { get; set; }

        // Navigation properties
        public required Medication Medication { get; set; }
    }
}
