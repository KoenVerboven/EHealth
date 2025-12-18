namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class MorePersonRoom : HospitalRoom
    {
        public decimal DayPricePerPerson { get; set; }
        public int NumberOfBeds { get; set; }
    }
}
