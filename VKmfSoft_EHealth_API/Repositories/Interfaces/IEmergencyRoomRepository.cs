using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IEmergencyRoomRepository
    {
        Task<IEnumerable<EmergencyRoom>> GetAllAsync();
        Task<EmergencyRoom?> GetByIdAsync(int id);
        Task AddAsync(EmergencyRoom emergencyRoom);
        Task UpdateAsync(EmergencyRoom emergencyRoom);
        Task DeleteAsync(int id);
    }
}
