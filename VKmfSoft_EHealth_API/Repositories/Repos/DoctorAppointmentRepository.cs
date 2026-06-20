
using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Specifications;

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

        public async Task<IEnumerable<DoctorAppointment>> GetSearchAsync(DoctorAppointmentSearchParams doctorAppointmentSearchParams)
        {
            var pageSize = doctorAppointmentSearchParams.PageSize;
            IQueryable<DoctorAppointment> doctorAppointments;

            doctorAppointments = _context.DoctorAppointments;


            if (doctorAppointmentSearchParams.PatientId != null)
            {
                doctorAppointments = doctorAppointments.Where(p => p.PatientId == doctorAppointmentSearchParams.PatientId);
            }

            if (doctorAppointmentSearchParams.DoctorId != null)                              
            {
                doctorAppointments = doctorAppointments.Where(p => p.DoctorId == doctorAppointmentSearchParams.DoctorId);
            }

            if (doctorAppointmentSearchParams.StartDate != null && doctorAppointmentSearchParams.EndDate != null)
            {
                doctorAppointments = doctorAppointments.Where(p => p.AppointmentDate >= doctorAppointmentSearchParams.StartDate 
                                                                && p.AppointmentDate <= doctorAppointmentSearchParams.EndDate);
            }

            doctorAppointments = doctorAppointmentSearchParams.Sort.ToLower() switch
            {
                "id" => doctorAppointments.OrderBy(p => p.Id).AsQueryable(),
                "id_desc" => doctorAppointments.OrderByDescending(p => p.Id).AsQueryable(),
                "patientid" => doctorAppointments.OrderBy(p => p.PatientId).AsQueryable(),
                "patientid_desc" => doctorAppointments.OrderByDescending(p => p.PatientId).AsQueryable(),
                "doctorid" => doctorAppointments.OrderBy(p => p.DoctorId).AsQueryable(),
                "doctorid_desc" => doctorAppointments.OrderByDescending(p => p.DoctorId ).AsQueryable(),
                "appointmentdate" => doctorAppointments.OrderBy(p => p.AppointmentDate).AsQueryable(),
                "appointmentdate_desc" => doctorAppointments.OrderByDescending(p => p.AppointmentDate).AsQueryable(),
                _ => doctorAppointments.OrderBy(p => p.Id).AsQueryable(),
            };

            if (doctorAppointmentSearchParams.PageSize > 0 && doctorAppointmentSearchParams.PageNumber > 0) 
            {
                if (doctorAppointmentSearchParams.PageSize > 30)
                {
                    pageSize = 30;
                }

                doctorAppointments = doctorAppointments.Skip(doctorAppointmentSearchParams.PageSize * (doctorAppointmentSearchParams.PageNumber - 1)).Take(pageSize);
            }

            return await doctorAppointments.ToListAsync();
        }
    }
}
