namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientRecommendation
    {
        public int Id { get; set; }
        public int PatientDiagnoseId { get; set; }//FK
        public required string Recommendation { get; set; }
    }
}
