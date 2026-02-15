namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class IntensiveCareRoom : HospitalRoom
    {
        public byte Status { get; set; }// 0: not ready to use; 1: not in use; 2 in use
    }
}
