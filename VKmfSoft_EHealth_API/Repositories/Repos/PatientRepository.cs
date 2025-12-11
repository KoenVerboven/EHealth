using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class PatientRepository : IPatientRepository
    {
        public Task<Patient> CreateAsync(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return new List<Patient>
            {
                new()
                {
                    Id = 1,
                    LastName = "Doe",
                    FirstName = "John",
                    Address = "",
                    Gender = 'M',
                    InsuranceNumber = "INS123456",
                    InsuranceProvider = "HealthCare Inc.",
                    IsMobile = true,
                    PhoneNumber = "123-456-7890",
                    Email = "test@test.com"
                },
                new()
                {
                    Id = 2,
                    LastName = "Smith",
                    FirstName = "Jane",
                    Address = "",
                     Gender = 'V',
                    InsuranceNumber = "INS654321",
                    InsuranceProvider = "MediPlus",
                    IsMobile = false,
                    PhoneNumber = "098-765-4321",
                    Email = "test@test.com"
                }
            };
        }

        public Task<Patient?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Patient?> UpdateAsync(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
