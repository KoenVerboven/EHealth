namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class HospitalUpdateDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public int UpdatedByPersonId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
