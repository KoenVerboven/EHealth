using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.DTO.TimeShedule
{
    public class DoctorAppointmentCreateDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicalWorkerId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public required string ReasonForVisit { get; set; }
        public string? Notes { get; set; }
        public int Status { get; set; }
        public int DegreeOfUrgency { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AppointmentPlaceId { get; set; }
        public int CreatedByPersonId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
