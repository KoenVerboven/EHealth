namespace VKmfSoft_EHealth_API.Models.DTO.TimeShedule
{
    public class DoctorAppointmentDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MedicalWorkerId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public required string ReasonForVisit { get; set; }
        public string? Notes { get; set; }
        public int Status { get; set; }
        public int DegreeOfUrgency { get; set; }
        public int AppointmentPlaceId { get; set; }
        public required string PatientLastName { get; set; }
        public required string PatientFirstName { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public required string DoctorLastName { get; set; }
        public required string DoctorFirstName { get; set; }
    }
}
