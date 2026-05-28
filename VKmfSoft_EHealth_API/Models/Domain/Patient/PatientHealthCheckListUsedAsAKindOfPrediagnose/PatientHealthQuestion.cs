using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient.PatientHealthCheckList
{
    public class PatientHealthQuestion// question list for patient health questionnaire // make it multiple choice question 
    {
        [Key]
        public int Id { get; set; }
        public int PatientHealthSurveyId { get; set; }
        public int QuestionNumber { get; set; }
        public required String Question { get; set; }
    }
}
