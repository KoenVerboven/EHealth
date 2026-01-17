
namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IIntensiveCareRoomRepository
    {
        Task<IEnumerable<IIntensiveCareRoomRepository>> GetAllAsync();
        Task<IIntensiveCareRoomRepository?> GetByIdAsync(int id);
        Task AddAsync(IIntensiveCareRoomRepository intensiveCareRoom);
        Task UpdateAsync(IIntensiveCareRoomRepository intensiveCareRoom);
        Task DeleteAsync(int id);
    }
}
