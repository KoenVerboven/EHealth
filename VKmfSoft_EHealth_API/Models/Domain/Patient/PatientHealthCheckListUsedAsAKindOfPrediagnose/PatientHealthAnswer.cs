using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient.PatientHealthCheckList
{
    public class PatientHealthAnswer // answer come from patient health questionnaire
    {
        [Key]
        public int Id { get; set; }
        public int PatientId { get; set; } 
        public int PatientHealthSurveyId { get; set; } 
        public int PatientHealthQuestionId { get; set; } = 0; 
        public int AnswerId { get; set; } // answer id for multiple choice question; wich is correct for the specific questions following the patient
    }
}
