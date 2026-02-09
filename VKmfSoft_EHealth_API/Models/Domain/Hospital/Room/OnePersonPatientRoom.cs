namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class OnePersonPatientRoom : HospitalRoom
    {
        public  decimal DayPrice { get; set; }
        public decimal SupplementCostForOnePersonRoom { get; set; }
        public int PatientId { get; set; }
        public Patient.Patient? Patient { get; set; }
    }
}
