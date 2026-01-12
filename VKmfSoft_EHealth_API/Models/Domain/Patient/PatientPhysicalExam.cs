namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientPhysicalExam
    {
        public int Id { get; set; }
        public int PatientDiagnoseId { get; set; }//FK
        public required string Exam { get; set; }
        public required string ExamResult { get; set; }
    }
}
