namespace VKmfSoft_EHealth_API.Models
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
        public int BloodTypeId { get; set; }
        public PatientHealthHistory? PatientHealthHistory { get; set; }

    }
}
