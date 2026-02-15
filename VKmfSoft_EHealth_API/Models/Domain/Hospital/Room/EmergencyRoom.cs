namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class EmergencyRoom : HospitalRoom
    {
        public ICollection<EmergencyRoomOccupation>? emergencyRoomOccupations { get; set; }
    }
}
