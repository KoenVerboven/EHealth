namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class EmergencyRoomOccupation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int EmergencyRoomId { get; set; } //FK
        public byte EmergencyGrade { get; set; } // from 1 to 10
        public bool PatientIsCheckedByDoctor { get; set; }
        public  DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
