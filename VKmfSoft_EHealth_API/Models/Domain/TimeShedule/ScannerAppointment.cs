
namespace VKmfSoft_EHealth_API.Models.Domain.TimeShedule
{
    public class ScannerAppointment : Appointment
    {
        public int ScannerId { get; set; } //id of the scanner device or the person responsible for the scan
        public int ScanTypeId { get; set; } //id of the type of scan (e.g., MRI, CT, X-ray)

    }
}
