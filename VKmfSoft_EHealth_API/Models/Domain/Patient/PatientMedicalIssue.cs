using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientMedicalIssue
    {
        [Key]
        public int Id { get; set; }
        public int PatientMedicalRecordId { get; set; } //FK
        public int MedicalIssueId { get; set; }//Allergy Problems, Cancer, Heart attack, Hepatitis A, ...
    }
}
