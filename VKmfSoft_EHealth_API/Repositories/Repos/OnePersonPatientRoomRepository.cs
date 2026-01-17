using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class OnePersonPatientRoomRepository : IOnePersonPatientRoomRepository
    {
        public Task AddAsync(OnePersonPatientRoom onePersonPatientRoom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OnePersonPatientRoom>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OnePersonPatientRoom?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(OnePersonPatientRoom onePersonPatientRoom)
        {
            throw new NotImplementedException();
        }
    }
}
