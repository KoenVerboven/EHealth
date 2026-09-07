
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;

namespace EhealthApiTests.Data
{
    internal static class DoctorAppointmentMockData
    {
        internal static IEnumerable<DoctorAppointment> DoctorAppointmentList()
        {
            IEnumerable<DoctorAppointment> doctorAppointments = [
                new DoctorAppointment()
                {
                    Id= 1,
                    PatientId= 1,
                    DoctorId=1,
                    AppointmentDate= DateTime.Now,
                    ReasonForVisit = "pain",
                    Status = 1,
                    DegreeOfUrgency = 1,
                    AppointmentPlaceId= 1
                },
                new DoctorAppointment()
                {
                    Id=2,
                    PatientId= 1,
                    DoctorId=1,
                    AppointmentDate= DateTime.Now,
                    ReasonForVisit = "pain",
                    Status = 1,
                    DegreeOfUrgency = 1,
                    AppointmentPlaceId= 1
                }
            ];
            return doctorAppointments;
        }
    }
}
