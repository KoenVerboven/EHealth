using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientVaccination
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalRecordId { get; set; }//FK 
        [Required(ErrorMessage = "Vaccine is required.")]
        public required int VaccineId { get; set; }
        public string? VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public int AdministeringMedicalWorkerId { get; set; }
        public string? Notes { get; set; }
        public byte StatusId { get; set; } // e.g., Completed, Scheduled, Canceled
        public int VaccinationId { get; set; }
            
    }
}
