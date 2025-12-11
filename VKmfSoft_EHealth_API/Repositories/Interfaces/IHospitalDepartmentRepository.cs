using VKmfSoft_EHealth_API.Models.Domain.Hospital;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IHospitalDepartmentRepository
    {
        Task<IEnumerable<HospitalDepartment>> GetAllAsync();
        Task<HospitalDepartment?> GetByIdAsync(int id);
        Task<HospitalDepartment> CreateAsync(HospitalDepartment hospitalDepartment);
        Task<HospitalDepartment?> UpdateAsync(HospitalDepartment hospitalDepartment);
        Task<bool> DeleteAsync(int id);
    }
}
