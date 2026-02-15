using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hardware;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace VKmfSoft_EHealth_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalDepartment> HospitalDepartments { get; set; }
        public DbSet<HospitalBed> HospitalBeds { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<IntensiveCareRoom> IntensiveCareRooms { get; set; }
        public DbSet<EmergencyRoom> EmergencyRooms { get; set; }
        public DbSet<EmergencyRoomOccupation> EmergencyRoomOccupations { get; set; }
        public DbSet<OnePersonPatientRoom> OnePersonPatientRooms { get; set; }
        public DbSet<MorePersonPatientRoom> MorePersonPatientRooms { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
 
    }
}
