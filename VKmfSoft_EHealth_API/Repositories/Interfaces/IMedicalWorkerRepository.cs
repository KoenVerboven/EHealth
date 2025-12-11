using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Other;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IMedicalWorkerRepository
    {
        Task<IEnumerable<MedicalWorker>> GetAllAsync();
        Task<Hospital?> GetByIdAsync(int id);
        Task<Hospital> CreateAsync(MedicalWorker medicalWorker);
        Task<Hospital?> UpdateAsync(MedicalWorker medicalWorker);
        Task<bool> DeleteAsync(int id);
    }
}

