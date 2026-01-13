using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital;
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

        public Task<HospitalDepartment> CreateAsync(HospitalDepartment hospitalDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HospitalDepartment>> GetAllAsync()
        {
            return await _context.HospitalDepartments.ToListAsync();
        }

        public Task<HospitalDepartment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HospitalDepartment?> UpdateAsync(HospitalDepartment hospitalDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
