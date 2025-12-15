namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class MedicalWorkerUpdateDTO
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
        public int MedicalTitle { get; set; }
        public int SpecializationId { get; set; }
        public required string LicenseNumber { get; set; }
        public DateTime LicenseValidUntil { get; set; }
        public int HospitalId { get; set; }
        public int DepartmentId { get; set; }
        public int UpdatedByPersonId { get; set; }  
        public DateTime UpdateDate { get; set; }
    }
}
