using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class ScannerShedule
    {
        [Key]
        public int Id { get; set; }
        public int ScannerId { get; set; }
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
