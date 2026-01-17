using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel
{
    public class Nurse : HospitalEmployee
    {
        public int Grade { get; set; } // 0 : nurse ; 1 : head nurse
    }
}
