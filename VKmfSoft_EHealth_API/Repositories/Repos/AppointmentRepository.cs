using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class AppointmentRepository : IAppointmentRepository

    {
        public Task<DoctorAppointment> CreateAsync(DoctorAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DoctorAppointment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DoctorAppointment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorAppointment?> UpdateAsync(DoctorAppointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
