namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientPainRegistration
    {
        public int Id { get; set; }
        public int PatientId { get; set; } //FK
        public int PainRegistrationNumber { get; set; }// from 1 to 10
        public DateTime RegistrationDate { get; set; }
    }
}
