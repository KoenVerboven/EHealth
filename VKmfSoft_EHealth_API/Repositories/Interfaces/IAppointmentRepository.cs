using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<DoctorAppointment>> GetAllAsync();
        Task<DoctorAppointment?> GetByIdAsync(int id);
        Task AddAsync(DoctorAppointment appointment);
        Task UpdateAsync(DoctorAppointment appointment);
        Task DeleteAsync(int id);

    }
}
