namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class OnePersonPatientRoom : HospitalRoom
    {
        public  decimal DayPrice { get; set; }
        public int PatientId { get; set; }
    }
}
