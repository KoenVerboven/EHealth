using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;

namespace VKmfSoft_EHealth_API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalDepartment> HospitalDepartments { get; set; }
        public DbSet<HospitalBed> HospitalBeds { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
 
    }
}
