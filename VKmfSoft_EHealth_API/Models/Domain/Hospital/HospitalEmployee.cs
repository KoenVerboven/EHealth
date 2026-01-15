using VKmfSoft_EHealth_API.Models.Domain.Other;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital
{
    public class HospitalEmployee : Person
    {
        public string Position { get; set; } = string.Empty;
        public int HospitalId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime InServiceDate { get; set; }
        public DateTime OutServiceDate { get; set; }
        //public Hospital Hospital { get; set; } = null!;
        public  HospitalDepartment hospitalDepartment { get; set; }
        public decimal? Salery { get; set; }
    }
}
