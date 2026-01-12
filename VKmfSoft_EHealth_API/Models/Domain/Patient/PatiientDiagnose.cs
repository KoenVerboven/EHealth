namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatiientDiagnose
    {
        public int Id { get; set; }
        public int PatientId { get; set; } //FK
        public int MedicatlWorkerId { get; set; } //FK
        public IList<PatientComplaint>? PatientComplaints { get; set; }
        public  IList<PatientVitalSigns>? PatientVitalSigns { get; set; }
        public IList<PatientPhysicalExam>? PatientPhysicalExams { get; set; }
        public IList<PatientRecommendation>? PatientRecommendations { get; set; }
        public IList<PatientMedicationPrescription>? PatientMedicinePrescriptions { get; set; }

    }
}
