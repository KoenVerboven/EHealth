using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class MedicalWorkerRepository : IMedicalWorkerRepository
    {
        private readonly AppDbContext _context;

        public MedicalWorkerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Hospital> AddAsync(MedicalWorker medicalWorker)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MedicalWorker>> GetAllAsync()
        {
            return await _context.MedicalWorkers.ToListAsync();
        }

        public Task<Hospital?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital?> UpdateAsync(MedicalWorker medicalWorker)
        {
            throw new NotImplementedException();
        }
    }
}
