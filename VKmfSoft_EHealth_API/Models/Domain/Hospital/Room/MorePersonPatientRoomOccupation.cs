namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class MorePersonPatientRoomOccupation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int MorePersonPatientRoomId { get; set; } //FK
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
