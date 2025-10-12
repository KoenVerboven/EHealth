using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models
{
    public class PatientAllergy
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AllergyId { get; set; }
        [Required(ErrorMessage = "Severity is required.")]
        public required string  Severity { get; set; } // Mild, Moderate, Severe
        public string? Reaction { get; set; }
        public DateTime RecordedDate { get; set; }
        public string? Notes { get; set; }
        public int StatusId { get; set; }

    }
}
