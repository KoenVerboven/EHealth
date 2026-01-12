namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientMedicationPrescription
    {
        public int Id { get; set; }
        public int PatientDiagnoseId { get; set; }//FK
        public  int MedicationId { get; set; }
    }
}
