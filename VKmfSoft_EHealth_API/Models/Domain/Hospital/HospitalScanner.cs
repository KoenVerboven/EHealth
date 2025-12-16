using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital
{
    public class HospitalScanner
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "SerialNumber is required.")]
        public required string SerialNumber { get; set; }
        public required byte ScannerType { get; set; } //type byte is closer to the values we use here than the type int
        public int HospitalId { get; set; } // Foreign key to Hospital

    }
}
