using VKmfSoft_EHealth_API.Models.Domain.Other;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class AppointmentRepository : IAppointmentRepository

    {
        public Task<Appointment> CreateAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Appointment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment?> UpdateAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
