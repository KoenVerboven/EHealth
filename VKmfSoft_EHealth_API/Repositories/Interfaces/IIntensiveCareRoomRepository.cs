
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IIntensiveCareRoomRepository
    {
        Task<IEnumerable<IntensiveCareRoom>> GetAllAsync();
        Task<IntensiveCareRoom?> GetByIdAsync(int id);
        Task AddAsync(IntensiveCareRoom intensiveCareRoom);
        Task UpdateAsync(IntensiveCareRoom intensiveCareRoom);
        Task DeleteAsync(int id);
    }
}
