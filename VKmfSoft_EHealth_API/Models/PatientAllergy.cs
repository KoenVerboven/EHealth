using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models
{
    public class PatientAllergy
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalHistoryId { get; set; }//FK to PatientMedicalHistory
        public int AllergyId { get; set; }
        [Required(ErrorMessage = "Severity is required.")]
        public required int  SeverityId { get; set; } 
        public string? Reaction { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? Notes { get; set; }
        public int StatusId { get; set; }

    }
}
