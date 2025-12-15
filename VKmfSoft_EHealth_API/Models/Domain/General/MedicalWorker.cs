using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;

namespace VKmfSoft_EHealth_API.Models.Domain.Other
{
    public class MedicalWorker : HospitalEmployee
    {
        public int MedicalTitle { get; set; } //0: nurse, 1: doctor, 2: specialist, 3: professor
       
        public int SpecializationId { get; set; } //0: therapist, 1: surgeon, 2: pediatrician, 3: cardiologist, 4: dentist, 5: neurologist, 6: psychiatrist, 7: gynecologist
       
        [Required(ErrorMessage = "LicenseNumber is required.")]
        public required string LicenseNumber { get; set; }
       
        public DateTime LicenseValidUntil { get; set; }
        
        public int HospitalId { get; set; } 
        
        public int DepartmentId { get; set; } 

    }
}
