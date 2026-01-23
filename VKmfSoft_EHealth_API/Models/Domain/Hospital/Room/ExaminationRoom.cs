namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class ExaminationRoom : HospitalRoom
    {
        public bool Laptop { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}
