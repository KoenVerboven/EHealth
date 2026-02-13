namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class MorePersonPatientRoomDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public decimal DayPricePerPerson { get; set; }
        public int NumberOfBeds { get; set; }
    }
}
