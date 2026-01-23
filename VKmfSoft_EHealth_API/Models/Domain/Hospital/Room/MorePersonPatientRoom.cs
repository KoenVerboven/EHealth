using VKmfSoft_EHealth_API.Models.Domain.Patient;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class MorePersonPatientRoom : HospitalRoom
    {
        public decimal DayPricePerPerson { get; set; }
        public int NumberOfBeds { get; set; }
        public  IList<Patient.Patient>? Patients { get; set; }
    }
}
