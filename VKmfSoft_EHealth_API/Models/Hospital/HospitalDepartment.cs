namespace VKmfSoft_EHealth_API.Models.Hospital
{
    public class HospitalDepartment
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<HospitalBed> PatientBeds { get; set; }
    }
}
