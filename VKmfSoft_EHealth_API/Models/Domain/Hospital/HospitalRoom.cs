namespace VKmfSoft_EHealth_API.Models.Domain.Hospital
{
    public class HospitalRoom
    {
        public int Id { get; set; }
        public int ChamerNumber { get; set; }
        public  bool IsOnePersonRoom { get; set; }
        public  byte  CountOfBedsInRoom { get; set; }
        public byte RoomType { get; set; } 
    }
}
