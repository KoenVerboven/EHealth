using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Other
{
    public class MedicalWorker : Person
    {
        public int MedicalTitle { get; set; } //0: nurse, 1: doctor, 2: specialist, 3: professor
       
        public int SpecializationId { get; set; } //0: therapist, 1: surgeon, 2: pediatrician, 3: cardiologist, 4: dentist, 5: neurologist, 6: psychiatrist, 7: gynecologist
       
        [Required(ErrorMessage = "LicenseNumber is required.")]
        public required string LicenseNumber { get; set; }
       
        public DateTime LicenseValidUntil { get; set; }
        
        public int Hospital { get; set; } //hospital ID
        
        public int Department { get; set; } //department ID

    }
}
