using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IDoctorAppointmentRepository
    {
        Task<IEnumerable<DoctorAppointment>> GetAllAsync();
        Task<DoctorAppointment?> GetByIdAsync(int id);
        Task<IEnumerable<DoctorAppointment?>> GetByPatientIdAsync(int patientId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<DoctorAppointment?>> GetByDoctorIdAsync(int doctorId, DateTime startDate, DateTime endDate);
        Task AddAsync(DoctorAppointment appointment);
        Task UpdateAsync(DoctorAppointment appointment);
        Task DeleteAsync(int id);
    }
}
