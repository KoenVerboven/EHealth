using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<DoctorAppointment>> GetAllAsync();
        Task<DoctorAppointment?> GetByIdAsync(int id);
        Task<DoctorAppointment> CreateAsync(DoctorAppointment appointment);
        Task<DoctorAppointment?> UpdateAsync(DoctorAppointment appointment);
        Task<bool> DeleteAsync(int id);

    }
}
