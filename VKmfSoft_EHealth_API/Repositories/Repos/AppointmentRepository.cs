using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class AppointmentRepository : IAppointmentRepository

    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
           _context = context;
        }

        public Task<DoctorAppointment> CreateAsync(DoctorAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DoctorAppointment>> GetAllAsync()
        {
            return await _context.DoctorAppointments.ToListAsync();
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
