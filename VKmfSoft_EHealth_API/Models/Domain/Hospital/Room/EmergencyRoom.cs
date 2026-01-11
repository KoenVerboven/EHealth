namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class EmergencyRoom : HospitalRoom
    {
        public int InUseByPatientId { get; set; }
        public byte EmergencyGrade { get; set; } // from 1 to 10

    }
}
