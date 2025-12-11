using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Other;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class MedicalWorkerRepository : IMedicalWorkerRepository
    {
        public Task<Hospital> CreateAsync(MedicalWorker medicalWorker)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MedicalWorker>> GetAllAsync()
        {
            return new List<MedicalWorker>
            {
                new()
                {
                    Id = 1,
                    LastName = "Doe",
                    FirstName = "John",
                    DateOfBirth = new DateTime(1980, 5, 15),
                    Address = "123 Main St, Anytown, USA",
                    PhoneNumber = "123-456-7890",
                    Email = "",
                    Gender = 'M',
                    MedicalTitle = 1, // Doctor,
                    SpecializationId = 0, // Therapist,
                    LicenseNumber = "MED123456",
                    LicenseValidUntil = new DateTime(2025, 12, 31),
                    Hospital = 1, //hospital ID
                },
                new()
                {
                    Id = 2,
                    LastName = "Smith",
                    FirstName = "Jane",
                    DateOfBirth = new DateTime(1975, 8, 22),
                    Address = "456 Oak St, Sometown, USA",
                    PhoneNumber = "987-654-3210",
                    Email = "",
                     Gender = 'M',
                    MedicalTitle = 2, // Specialist,
                    SpecializationId = 3, // Cardiologist,
                    LicenseNumber = "MED654321",
                    LicenseValidUntil = new DateTime(2024, 6, 30),
                    Hospital = 2, //hospital ID
                },
                new()
                {
                    Id = 3,
                    LastName = "Brown",
                    FirstName = "Emily",
                    DateOfBirth = new DateTime(1990, 3, 10),
                    Address = "789 Pine St, Othertown, USA",
                    PhoneNumber = "555-123-4567",
                    Email = "",
                     Gender = 'V',
                    MedicalTitle = 0, // Nurse,
                    SpecializationId = 2, // Pediatrician,
                    LicenseNumber = "MED789012",
                    LicenseValidUntil = new DateTime(2026, 11, 30),
                    Hospital = 1, //hospital ID
                }
            };
        }

        public Task<Hospital?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital?> UpdateAsync(MedicalWorker medicalWorker)
        {
            throw new NotImplementedException();
        }
    }
}
