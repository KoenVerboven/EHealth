using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Room
{
    public class HospitalRoom
    {
        [Key]
        public int Id { get; set; }
        public int RoomNumber { get; set; }
    }
}
