using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IOnePersonPatientRoomRepository
    {
        Task<IEnumerable<OnePersonPatientRoom>> GetAllAsync();
        Task<OnePersonPatientRoom?> GetByIdAsync(int id);
        Task AddAsync(OnePersonPatientRoom onePersonPatientRoom);
        Task UpdateAsync(OnePersonPatientRoom onePersonPatientRoom);
        Task DeleteAsync(int id);
    }
}
