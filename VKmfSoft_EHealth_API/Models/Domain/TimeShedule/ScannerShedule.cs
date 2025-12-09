namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class ScannerShedule
    {
        public int Id { get; set; }
        public int ScannerId { get; set; }
        public int PatientId { get; set; }
    }
}
