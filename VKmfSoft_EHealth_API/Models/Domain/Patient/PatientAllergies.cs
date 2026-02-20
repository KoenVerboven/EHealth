namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientAllergies
    {
        public int Id { get; set; }
        public int PatientMedicalHistoryId { get; set; }//FK to PatientMedicalHistory
        public required string Name { get; set; }
    }
}
