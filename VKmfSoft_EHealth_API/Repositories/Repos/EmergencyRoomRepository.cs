using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class EmergencyRoomRepository : IEmergencyRoomRepository
    {
        public Task AddAsync(EmergencyRoom emergencyRoom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmergencyRoom>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EmergencyRoom?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EmergencyRoom emergencyRoom)
        {
            throw new NotImplementedException();
        }
    }
}
