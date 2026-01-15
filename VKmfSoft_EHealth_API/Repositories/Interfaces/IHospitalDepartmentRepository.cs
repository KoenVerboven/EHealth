using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IHospitalDepartmentRepository
    {
        Task<IEnumerable<HospitalDepartment>> GetAllAsync();
        Task<HospitalDepartment?> GetByIdAsync(int id);
        Task AddAsync(HospitalDepartment hospitalDepartment);
        Task UpdateAsync(HospitalDepartment hospitalDepartment);
        Task DeleteAsync(int id);
    }
}
