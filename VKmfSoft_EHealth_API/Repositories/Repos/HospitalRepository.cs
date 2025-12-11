using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class HospitalRepository : IHospitalRepository
    {
        public Task<Hospital> CreateAsync(Hospital hospital)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hospital>> GetAllAsync()
        {
            return new List<Hospital>
            {
               new()
               {
                    Id = 1,
                    Name = "City Hospital",
                    Address = "123 Main St, Anytown",
                    PhoneNumber = "555-1234",
                    Email = "test@gmail.com" },
                new()
                {
                    Id = 2,
                    Name = "County General",
                    Address = "456 Oak Ave, Sometown",
                    PhoneNumber = "555-5678",
                    Email = "test@gmail.com" }
            };
        }

        public Task<Hospital?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hospital?> UpdateAsync(Hospital hospital)
        {
            throw new NotImplementedException();
        }
    }
}
