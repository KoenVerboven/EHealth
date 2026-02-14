using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var DoctorInDb = await _context.Doctors.FindAsync(id) ?? throw new KeyNotFoundException($"Doctor with id {id} was not found.");
            _context.Doctors.Remove(DoctorInDb);
            await _context.SaveChangesAsync();
        }

        public bool DoctorExists(int doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorByFilterAsync(string? fullName)
        {
            IQueryable<Doctor> doctors;

            doctors = _context.Doctors;

            if (fullName is not null)
            {
                if (fullName.Trim() != string.Empty)
                {
                    doctors = doctors.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(fullName.ToLower())).AsQueryable();
                }
            }

            return await doctors.ToListAsync();
        }

        public Task<IEnumerable<Doctor>> GetFilterAsync(string? Name, string? Email, string Sort, int PageSize, int PageNumber)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
