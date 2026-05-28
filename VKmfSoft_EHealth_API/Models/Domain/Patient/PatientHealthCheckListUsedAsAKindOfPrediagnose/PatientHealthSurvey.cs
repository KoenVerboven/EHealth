using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient.PatientHealthCheckList
{
    public class PatientHealthSurvey
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
