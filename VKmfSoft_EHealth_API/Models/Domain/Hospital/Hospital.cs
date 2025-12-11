namespace VKmfSoft_EHealth_API.Models.Domain.Hospital
{
    public class Hospital
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
    }
}
