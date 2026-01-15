using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAllAsync();
        Task<Hospital?> GetByIdAsync(int id);
        Task AddAsync(Hospital hospital);
        Task UpdateAsync(Hospital hospital);
        Task<bool> DeleteAsync(int id);
    }
}
