using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class HospitalDepartmentRepository : IHospitalDepartmentRepository
    {
        private readonly AppDbContext _context;

        public HospitalDepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(HospitalDepartment hospitalDepartment)
        {
            await _context.HospitalDepartments.AddAsync(hospitalDepartment);
            await _context.SaveChangesAsync(); ;
        }

        public async Task DeleteAsync(int id)
        {
            var hospitalDepartmentFind = await _context.HospitalDepartments.FindAsync(id) ?? throw new KeyNotFoundException($"HospitalDepartment with id {id} was not found.");
            _context.HospitalDepartments.Remove(hospitalDepartmentFind);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HospitalDepartment>> GetAllAsync()
        {
            return await _context.HospitalDepartments.ToListAsync();
        }

        public async Task<HospitalDepartment?> GetByIdAsync(int id)
        {
            return await _context.HospitalDepartments.FindAsync(id);
        }

        public async Task UpdateAsync(HospitalDepartment hospitalDepartment)
        {
            _context.HospitalDepartments.Update(hospitalDepartment);
            await _context.SaveChangesAsync();
        }
    }
}
