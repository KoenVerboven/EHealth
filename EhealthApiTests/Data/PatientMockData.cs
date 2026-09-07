
using VKmfSoft_EHealth_API.Models.Domain.Patient;

namespace EhealthApiTests.Data
{
    internal static class PatientMockData
    {
        internal static IEnumerable<Patient> PatientList()
        {
            IEnumerable<Patient> patients = [
                new Patient()
                {
                    Id = 1,
                    LastName = "Verboven",
                    FirstName = "Koen",
                    DateOfBirth = new DateTime(1996, 6, 1),
                    Gender = 1,
                    PhoneNumber = "123456789",
                    Email = "koen@test.com"

                },
                new Patient()
                {
                    Id = 2,
                    LastName = "Peeters",
                    FirstName = "Dirk",
                    DateOfBirth = new DateTime(1998, 1, 4),
                    Gender = 1,
                    PhoneNumber = "1234544789",
                    Email = "dirk@test.com"

                }
             ];
            return patients;
        }
    }
}
