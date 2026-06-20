using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Specifications;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetDoctorByFilterAsync(string? fullName);
        Task<IEnumerable<Doctor>> GetSearchAsync(DoctorSearchParams doctorSearchParameters);
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
        Task<IEnumerable<Doctor>> GetFilterAsync(string? Name, string? Email, string Sort, int PageSize, int PageNumber);
        bool DoctorExists(int doctorId);
    }
}

