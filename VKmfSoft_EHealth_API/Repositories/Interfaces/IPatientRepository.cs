using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Specifications;

namespace VKmfSoft_EHealth_API.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetSearchAsync(PatientSearchParams patiientSearchParameters);
        Task<IEnumerable<Patient>> GetPatientByFilterAsync(string? fullName);
        Task  AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(int id);
        bool PatientExists(int patientId);
    }
}
