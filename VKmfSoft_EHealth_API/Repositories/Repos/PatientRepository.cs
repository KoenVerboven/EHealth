using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Specifications;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetPatientByFilterAsync(string? fullName)
        {
            IQueryable<Patient> patients;

            patients = _context.Patients;

            if (fullName is not null)
            {
                if (fullName.Trim() != string.Empty)
                {
                    patients = patients.Where(p => (p.LastName.ToLower() + " " + p.FirstName).Contains(fullName.ToLower())).AsQueryable();
                }
            }

            return await patients.ToListAsync();
        }

        public async Task<IEnumerable<Patient>> GetSearchAsync(PatientSearchParams patientSearchParameters)
        {
            var pageSize = patientSearchParameters.PageSize;
            IQueryable<Patient> patients;

            patients = _context.Patients;

            if (!string.IsNullOrWhiteSpace(patientSearchParameters.Lastname))
            {
                patients = patients.Where(p => p.LastName.ToLower().Contains(patientSearchParameters.Lastname.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(patientSearchParameters.Firstname))
            {
                patients = patients.Where(p => p.FirstName.ToLower().Contains(patientSearchParameters.Firstname.ToLower()));
            }

            patients = patientSearchParameters.Sort.ToLower() switch
            {
                "id" => patients.OrderBy(p => p.Id).AsQueryable(),
                "id_desc" => patients.OrderByDescending(p => p.Id).AsQueryable(),
                "lastname" => patients.OrderBy(p => p.LastName).AsQueryable(),
                "lastname_desc" => patients.OrderByDescending(p => p.LastName).AsQueryable(),
                "firstname" => patients.OrderBy(p => p.FirstName).AsQueryable(),
                "firstname_desc" => patients.OrderByDescending(p => p.FirstName).AsQueryable(),
                "email" => patients.OrderBy(p => p.Email).AsQueryable(),
                "email_desc" => patients.OrderByDescending(p => p.Email).AsQueryable(),
                _ => patients.OrderBy(p => p.Id).AsQueryable()
            };

            if (patientSearchParameters.PageSize > 0 && patientSearchParameters.PageNumber > 0) 
            {
                if (patientSearchParameters.PageSize > 30)
                {
                    pageSize = 30;
                }

                patients = patients.Skip(patientSearchParameters.PageSize * (patientSearchParameters.PageNumber - 1)).Take(pageSize);
            }

            return await patients.ToListAsync();
        }

        public bool PatientExists(int patientId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}
