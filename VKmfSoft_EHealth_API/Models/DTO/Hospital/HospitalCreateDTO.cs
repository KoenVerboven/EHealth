namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class HospitalCreateDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public  int CreatedByPersonId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
