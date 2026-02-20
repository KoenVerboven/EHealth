using VKmfSoft_EHealth_API.Models.Domain.Messages;
using VKmfSoft_EHealth_API.Models.Domain.Other;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class Patient : Person
    {
        public string? InsuranceNumber { get; set; }
        public string? InsuranceProvider { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
        public bool IsMobile { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhoneNumber { get; set; }
        public string? EmergencyContactDescription { get; set; }
        public byte BloodTypeId { get; set; }
        public string? ImageUrl { get; set; }
        public PatientHealthHistory? PatientHealthHistory { get; set; }
        public List<DoctorAppointment>? DoctorAppointments { get; set; }
        public List<PatientRelative>? patientRelatives { get; set; }
        public List<PatientMessage>? PatientMessages { get; set; }

    }
}
