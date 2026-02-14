using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital
{
    public class Hospital
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }


        //todo add zipcode for address
        //todo add city for address
        //todo add country for address

        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public ICollection<HospitalDepartment>? HosptialDepartments { get; set; }
        public ICollection<OnePersonPatientRoom>? OnePersonPatientRoom { get; set; }
        public ICollection<MorePersonPatientRoom>? morePersonPatientRooms { get; set; }
        public ICollection<IntensiveCareRoom>? IntensiveCareRooms { get; set; }
        
    }
}
