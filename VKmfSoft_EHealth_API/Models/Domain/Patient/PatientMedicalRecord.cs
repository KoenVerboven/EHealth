namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientMedicalRecord
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public List<PatientScan> Scans { get; set; } = [];
        public List<PatientSurgery> Surgeries { get; set; } = [];
        public List<PatientVaccination> Vaccinations { get; set; } = [];
       
        //public List<PatientVitalSigns> VitalSigns { get; set; } = [];
        public List<PatientMedicationHistory> Medications { get; set; } = [];
        public List<PatientAllergy> PatientAllergies  { get; set; } = [];

    }
}
