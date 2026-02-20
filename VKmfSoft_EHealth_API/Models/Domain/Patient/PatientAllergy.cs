using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientAllergy
    {
        [Key]
        public int Id { get; set; }
       
        public int PatientMedicalRecordId { get; set; }//FK
      
        public int AllergyId { get; set; }
        
        [Required(ErrorMessage = "Severity is required.")]
       
        public required byte  SeverityId { get; set; } 
       
        public string? Reaction { get; set; }
       
        public DateTime RecordedDate { get; set; }
       
        public string? Notes { get; set; }
       
        public byte StatusId { get; set; }

    }
}
