using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class AppointmentRepository : IAppointmentRepository

    {
        public Task<DoctorAppointment> CreateAsync(DoctorAppointment appointment)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DoctorAppointment>> GetAllAsync()
        {
            return  new List<DoctorAppointment>
            {
                new()
                {
                    Id = 1,
                    PatientId = 1,
                    MedicalWorkerId = 2,
                    AppointmentDate = new DateTime(2024, 7, 15, 10, 30, 0),
                    ReasonForVisit = "Routine check-up",
                    Notes = "Patient is in good health.",
                    Status = 0, // Scheduled
                    DegreeOfUrgency = 1, // Normal
                    CreatedBy = 1, // Admin user ID
                    CreatedAt = DateTime.Now,
                },
                new()
                {
                    Id = 2,
                    PatientId = 2,
                    MedicalWorkerId = 1,
                    AppointmentDate = new DateTime(2024, 7, 16, 14, 0, 0),
                    ReasonForVisit = "Follow-up on blood test results",
                    Notes = "Discussed lifestyle changes.",
                    Status = 0, // Scheduled
                    DegreeOfUrgency = 2, // Urgent
                    CreatedBy = 1, // Admin user ID
                    CreatedAt = DateTime.Now,
                }
            };
        }

        public Task<DoctorAppointment?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorAppointment?> UpdateAsync(DoctorAppointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
