
using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class DoctorAppointmentRepository : IDoctorAppointmentRepository

    {
        private readonly AppDbContext _context;

        public DoctorAppointmentRepository(AppDbContext context)
        {
           _context = context;
        }

        public async Task AddAsync(DoctorAppointment appointment)
        {
            await _context.DoctorAppointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var classInDb = await _context.DoctorAppointments.FindAsync(id) ?? throw new KeyNotFoundException($"DoctorAppointment with id {id} was not found.");
            _context.DoctorAppointments.Remove(classInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DoctorAppointment>> GetAllAsync()
        {
            return await _context.DoctorAppointments.ToListAsync();
        }
      

        public async Task<DoctorAppointment?> GetByIdAsync(int id)
        {
            return await _context.DoctorAppointments.FindAsync(id);
        }

        public async Task<IEnumerable<DoctorAppointment?>> GetByDoctorIdAsync(int doctorId, DateTime startDate, DateTime endDate)
        {
            return await _context.DoctorAppointments.Where(
                p=>p.DoctorId == doctorId && 
                p.AppointmentDate >= startDate && 
                p.AppointmentDate <= endDate
                ).ToListAsync();
        }


        public async Task<IEnumerable<DoctorAppointment?>> GetByPatientIdAsync(int patientId, DateTime startDate, DateTime endDate)
        {
            return await _context.DoctorAppointments.Where(
                p=>p.PatientId == patientId && 
                p.AppointmentDate >= startDate && 
                p.AppointmentDate <= endDate
                ).ToListAsync();
        }

        public  async Task UpdateAsync(DoctorAppointment appointment)
        {
            _context.DoctorAppointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
