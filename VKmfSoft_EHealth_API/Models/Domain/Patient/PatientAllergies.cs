namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientAllergies
    {
        public int Id { get; set; }
        public int PatientId { get; set; }//FK
        public required string Name { get; set; }
    }
}
