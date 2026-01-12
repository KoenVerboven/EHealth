namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientComplaint
    {
        public int Id { get; set; }
        public int PatientDiagnoseId { get; set; }//FK
        public required string Complaint { get; set; }
    }
}
