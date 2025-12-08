using VKmfSoft_EHealth_API.Models.Domain.Other;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment> CreateAsync(Appointment appointment);
        Task<Appointment?> UpdateAsync(Appointment appointment);
        Task<bool> DeleteAsync(int id);

    }
}
