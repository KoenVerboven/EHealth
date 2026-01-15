using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hardware;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital
{
    public class HospitalDepartment
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<HospitalBed>? PatientBeds { get; set; }
    }
}
