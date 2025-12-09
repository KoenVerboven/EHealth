namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class MedicalWorkerTimeShedule
    {
        public int Id { get; set; }
        public int MedicalWorkerId { get; set; }
        public int PatientId { get; set; }
    }
}
