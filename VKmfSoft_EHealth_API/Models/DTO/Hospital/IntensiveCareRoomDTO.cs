namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class IntensiveCareRoomDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int InUseByPatientId { get; set; }
        public byte Status { get; set; }
    }
}
