namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class OnePersonPatientRoomOccupation
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int OnePersonPatientRoomId { get; set; }//FK
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool PatientAgreeWithSupplementCost { get; set; }
    }
}
