using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;
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
        public DbSet<MedicalWorker> MedicalWorkers { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
 
    }
}
