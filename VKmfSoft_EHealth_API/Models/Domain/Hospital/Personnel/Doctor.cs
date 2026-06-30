using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel
{
    public class Doctor : HospitalEmployee
    {
        public int MedicalTitle { get; set; } // 1: doctor, 2: specialist, 3: professor
        public int SpecializationId { get; set; } //0: therapist, 1: surgeon, 2: pediatrician, 3: cardiologist, 4: dentist, 5: neurologist, 6: psychiatrist, 7: gynecologist
        [Required(ErrorMessage = "LicenseNumber is required.")]
        public required string LicenseNumber { get; set; }
        public DateTime LicenseValidUntil { get; set; }
        public List<DoctorAppointment>? DoctorAppointments { get; set; }
    }
}
