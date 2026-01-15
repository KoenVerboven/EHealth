using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Hardware
{
    public class HospitalBed
    {
        [Key]
        public int Id { get; set; }
        public required string BedNumber { get; set; }
    }
}
