namespace VKmfSoft_EHealth_API.Models.Patient
{
    public class PatientMedicalIssue
    {
        public int Id { get; set; }
        public int PatientMedicalHistoryId { get; set; }
        public int MedicalIssueId { get; set; }//Allergy Problems, Cancer, Heart attack, Hepatitis A, ...
    }
}
