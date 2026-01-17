using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IMorePersonPatientRoomRepository
    {
        Task<IEnumerable<MorePersonPatientRoom>> GetAllAsync();
        Task<MorePersonPatientRoom?> GetByIdAsync(int id);
        Task AddAsync(MorePersonPatientRoom morePersonPatientRoom);
        Task UpdateAsync(MorePersonPatientRoom morePersonPatientRoom);
        Task DeleteAsync(int id);
    }
}
