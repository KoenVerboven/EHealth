namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class OnePersonPatientRoom : HospitalRoom
    {
        public  decimal DayPrice { get; set; }
        public decimal SupplementCostForOnePersonRoom { get; set; }
        public ICollection<OnePersonPatientRoomOccupation>? onePersonPatientRoomOccupations { get; set; }
    }
}
