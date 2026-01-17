using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Hospital?> GetByIdAsync(int id);
        Task<Hospital> AddAsync(Doctor medicalWorker);
        Task<Hospital?> UpdateAsync(Doctor medicalWorker);
        Task<bool> DeleteAsync(int id);
    }
}

