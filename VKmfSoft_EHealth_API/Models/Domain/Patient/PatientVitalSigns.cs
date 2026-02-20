using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientVitalSigns
    {
        [Key]
        public int Id { get; set; }
        public int PatientDiagnoseId { get; set; }//FK
        public int PatientMedicalRecordId { get; set; }//FK
        public DateTime RecordedAt { get; set; }
        public float Temperature { get; set; }
        public int HeartRate { get; set; }
        public int BloodPressureSystolic { get; set; }
        public int BloodPressureDiastolic { get; set; }
        public int RespiratoryRate { get; set; }
        public float OxygenSaturation { get; set; }
        public int Pain { get; set; } // Scale from 0 to 10
        public float Weight { get; set; }
        public float Height { get; set; }
        public string? Notes { get; set; }
    }
}
