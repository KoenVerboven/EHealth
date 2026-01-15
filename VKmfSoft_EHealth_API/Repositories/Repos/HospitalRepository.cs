using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly AppDbContext _context;

        public HospitalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Hospital hospital)
        {
            await _context.Hospitals.AddAsync(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hospitalFind = await _context.Hospitals.FindAsync(id) ?? throw new KeyNotFoundException($"Hospital with id {id} was not found.");
            _context.Hospitals.Remove(hospitalFind);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            return await _context.Hospitals.ToListAsync();
        }

        public async Task<Hospital?> GetByIdAsync(int id)
        {
            return await _context.Hospitals.FindAsync(id);
        }

        public async Task UpdateAsync(Hospital hospital)
        {
            _context.Hospitals.Update(hospital);
            await _context.SaveChangesAsync();
        }
    }
}
