using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;

namespace EhealthApiTests.Data
{
    internal static class DoctorMockData
    {
        internal static IEnumerable<Doctor> DoctorList()
        {
            IEnumerable<Doctor> doctors = [
                new Doctor()
                {
                    Id = 1,
                    LastName = "Poels",
                    FirstName = "Maria",
                    DateOfBirth = new DateTime(1996, 6, 1),
                    Gender = 1,
                    PhoneNumber = "123456789",
                    Email = "maria@test.com",
                    LicenseNumber = "12344444"
                },
                new Doctor()
                {
                    Id = 2,
                    LastName = "Janssens",
                    FirstName = "Dirk",
                    DateOfBirth = new DateTime(1998, 1, 4),
                    Gender = 1,
                    PhoneNumber = "1234544789",
                    Email = "dirk@test.com",
                    LicenseNumber = "123456789"

                }
            ];
            return doctors;
        }
    }
}
