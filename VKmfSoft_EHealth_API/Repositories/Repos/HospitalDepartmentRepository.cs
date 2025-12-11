using VKmfSoft_EHealth_API.Models.Domain.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class HospitalDepartmentRepository : IHospitalDepartmentRepository
    {
        public Task<HospitalDepartment> CreateAsync(HospitalDepartment hospitalDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HospitalDepartment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<HospitalDepartment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HospitalDepartment?> UpdateAsync(HospitalDepartment hospitalDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
