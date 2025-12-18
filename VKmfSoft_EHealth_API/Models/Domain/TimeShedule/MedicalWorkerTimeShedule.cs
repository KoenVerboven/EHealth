using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class MedicalWorkerTimeShedule
    {
        [Key]
        public int Id { get; set; }
        public int MedicalWorkerId { get; set; }
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
