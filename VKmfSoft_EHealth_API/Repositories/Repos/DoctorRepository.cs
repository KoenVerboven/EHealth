using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Specifications;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var DoctorInDb = await _context.Doctors.FindAsync(id) ?? throw new KeyNotFoundException($"Doctor with id {id} was not found.");
            _context.Doctors.Remove(DoctorInDb);
            await _context.SaveChangesAsync();
        }

        public bool DoctorExists(int doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorByFilterAsync(string? fullName)// todo : add more filters bv specialiteit , sort and pagination
        {
            IQueryable<Doctor> doctors;

            doctors = _context.Doctors;

            if (fullName is not null)
            {
                if (fullName.Trim() != string.Empty)
                {
                    doctors = doctors.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(fullName.ToLower())).AsQueryable();
                }
            }

            return await doctors.ToListAsync();
        }

        public Task<IEnumerable<Doctor>> GetFilterAsync(string? Name, string? Email, string Sort, int PageSize, int PageNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doctor>> GetSearchAsync(DoctorSearchParams doctorSearchParameters)
        {
            var pageSize = doctorSearchParameters.PageSize;
            IQueryable<Doctor> doctors;

            doctors = _context.Doctors          ;

            if (!string.IsNullOrWhiteSpace(doctorSearchParameters.Lastname))
            {
                doctors = doctors.Where(p => p.LastName.ToLower().Contains(doctorSearchParameters.Lastname.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(doctorSearchParameters.Firstname) && !string.IsNullOrWhiteSpace(doctorSearchParameters.Firstname))
            {
                doctors = doctors.Where(p => p.FirstName.ToLower().Contains(doctorSearchParameters.Firstname.ToLower())
                                         && p.LastName.ToLower().Contains(doctorSearchParameters.Lastname.ToLower()));//todo lastname may be null

            }

            doctors = doctorSearchParameters.Sort.ToLower() switch
            {
                "id" => doctors.OrderBy(p => p.Id).AsQueryable(),
                "id_desc" => doctors.OrderByDescending(p => p.Id).AsQueryable(),
                "lastname" => doctors.OrderBy(p => p.LastName).AsQueryable(),
                "lastname_desc" => doctors.OrderByDescending(p => p.LastName).AsQueryable(),
                "firstname" => doctors.OrderBy(p => p.FirstName).AsQueryable(),
                "firstname_desc" => doctors.OrderByDescending(p => p.FirstName).AsQueryable(),
                "email" => doctors.OrderBy(p => p.Email).AsQueryable(),
                "email_desc" => doctors.OrderByDescending(p => p.Email).AsQueryable(),
                _ => doctors.OrderBy(p => p.Id).AsQueryable(),
            };

            if (doctorSearchParameters.PageSize > 0 && doctorSearchParameters.PageNumber > 0) //todo : kan korter
            {
                if (doctorSearchParameters.PageSize > 30)
                {
                    pageSize = 30;
                }

                doctors = doctors.Skip(doctorSearchParameters.PageSize * (doctorSearchParameters.PageNumber - 1)).Take(pageSize);
            }

            return await doctors.ToListAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
