using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientLabResult
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalRecordId { get; set; }//FK
        public  int LabExamKind { get; set; } // blood, urine, etc.
        public required string LabResult { get; set; }
    }
}
