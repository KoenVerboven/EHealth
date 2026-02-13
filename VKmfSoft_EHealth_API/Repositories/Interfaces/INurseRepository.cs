using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface INurseRepository
    {
        Task<IEnumerable<Nurse>> GetAllAsync();
        Task<Nurse?> GetByIdAsync(int id);
        Task AddAsync(Nurse nurse);
        Task UpdateAsync(Nurse nurse);
        Task DeleteAsync(int id);
        bool NurseExists(int nurseId);
    }
}
