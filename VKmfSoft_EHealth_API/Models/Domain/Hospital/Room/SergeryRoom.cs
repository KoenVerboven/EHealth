namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class SergeryRoom : HospitalRoom
    {
        public byte SergeryRoomClasse { get; set; }
        public bool ReadyToUse { get; set; }
        public int PatientId { get; set; }
    }
}
