using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Patient
{
    public class PatientVaccination
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalHistoryId { get; set; }//FK to PatientMedicalHistory
        [Required(ErrorMessage = "Vaccine is required.")]
        public required int VaccineId { get; set; }
        public DateTime VaccinationDate { get; set; }
        public int AdministeringMedicalWorkerId { get; set; }
        public string? Notes { get; set; }
        public int StatusId { get; set; } // e.g., Completed, Scheduled, Canceled
        public int VaccinationId { get; set; }
            
    }
}
