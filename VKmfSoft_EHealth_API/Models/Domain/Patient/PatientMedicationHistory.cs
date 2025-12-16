using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientMedicationHistory
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalHistoryId { get; set; }//FK to PatientMedicalHistory
        public int MedicationId { get; set; }
        public  string MedicationName { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PrescribingDoctorId { get; set; }
        public string? Notes { get; set; }
    }
}
