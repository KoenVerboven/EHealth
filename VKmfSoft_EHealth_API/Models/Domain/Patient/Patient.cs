using VKmfSoft_EHealth_API.Models.Domain.Other;

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
        public PatientHealthHistory? PatientHealthHistory { get; set; } // todo fill in with data n
       
    }
}
