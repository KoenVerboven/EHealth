using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel
{
    public class HospitalEmployeeDiploma
    {
        public int Id { get; set; }
        public int HospitalEmployeeId { get; set; }
        public int DiplomaId { get; set; }
        public DateOnly? ArchievedOnDate { get; set; }
        public string? SchoolName { get; set; }
        public HospitalEmployee HospitalEmployee { get; set; } = null!;
        public Diploma Diploma { get; set; } = null!;
    }
}
