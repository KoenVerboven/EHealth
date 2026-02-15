namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class EmergencyRoomCreateDTO
    {
        public int RoomNumber { get; set; }
        public int PatientId { get; set; }
        public byte EmergencyGrade { get; set; } // from 1 to 10
    }
}
