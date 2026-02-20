namespace VKmfSoft_EHealth_API.Models.Domain.General
{
    public class Address
    {
        public int Id { get; set; }
        public required string StreetAndNumber { get; set; }
        public string? BusNumber { get; set; }
        public int ZipCode { get; set; }
        public required string LandCode { get; set; }
        public int PrioritizationAddress { get; set; } //1 = primary address, 2 = secondary address, etc.
    }
}
