using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Patient;

namespace VKmfSoft_EHealth_API.Models.DTO.Patient
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required byte Gender { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public int FirstLanguageID { get; set; }
        public byte[]? Photo { get; set; }
        public string? InsuranceNumber { get; set; }
        public string? InsuranceProvider { get; set; }
        public DateTime? InsuranceExpiryDate { get; set; }
        public bool IsMobile { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhoneNumber { get; set; }
        public string? EmergencyContactDescription { get; set; }
        public byte BloodTypeId { get; set; }
        public PatientMedicalRecord? PatientMedicalRecord { get; set; }
    }
}
