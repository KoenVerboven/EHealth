using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class MorePersonPatientRoomRepository : IMorePersonPatientRoomRepository
    {
        public Task AddAsync(MorePersonPatientRoom morePersonPatientRoom)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MorePersonPatientRoom>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MorePersonPatientRoom?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MorePersonPatientRoom morePersonPatientRoom)
        {
            throw new NotImplementedException();
        }
    }
}
