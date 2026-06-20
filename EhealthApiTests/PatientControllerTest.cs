

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VKmfSoft_EHealth_API.AutoMapper;
using VKmfSoft_EHealth_API.Controllers;
using VKmfSoft_EHealth_API.Models.Domain.General;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace EhealthApiTests
{
    public class PatientControllerTest
    {
        private readonly Mock<IPatientRepository> _mockPatientRepo;
        private readonly Mock<ILogger<PatientController>> _mockILogger;
        private readonly MapperConfiguration _mapperConfiguration;

        public PatientControllerTest()
        {
            _mockPatientRepo = new Mock<IPatientRepository>(MockBehavior.Default);
            _mockILogger = new Mock<ILogger<PatientController>>(MockBehavior.Default);

            var myProfile = new MappingConfig();
            _mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile(myProfile), new LoggerFactory()
                );
        }

        [Fact]
        public async Task GetAllAync_ShallReturnItemsCount_ForPatientListContainItems()
        {
            //arrange
            var mapper = _mapperConfiguration.CreateMapper();
            var mockRepo = new Mock<IPatientRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(PatientList());
            var controller = new PatientController(mockRepo.Object,mapper);
            
            //act
            var actionResult = await controller.GetAllPatientsAsync();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);

            var okObjectResult = actionResult.Result as OkObjectResult;
            var actual = okObjectResult!.Value as IEnumerable<PatientDTO>;
            var count = actual!.Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetAsynById_ShallReturnPatientWithId_ForExistingPatientWithId()
        {
            //arrange
            var patient = new Patient()
            {
                Id = 1,
                LastName = "Poels",
                FirstName = "Maria",
                Addresses =
                [
                    new Address()
                {
                    Id = 1,
                 StreetAndNumber  = "Teststraat 1",
                    LandCode = "TL"
                }
                ],
                DateOfBirth = new DateTime(1996, 6, 1),
                Gender = 1,
                PhoneNumber = "123456789",
                Email = "maria@test.com",
            };

            var patientDTO = new PatientDTO ()
            {
                Id = patient.Id,
                LastName = patient.LastName,
                FirstName = patient.FirstName,
                Addresses = patient.Addresses,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
            };

            var mapper = new Mapper(_mapperConfiguration);
            _mockPatientRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(patient);
            var controller = new PatientController(_mockPatientRepo.Object, mapper);

            //act
            var actionResult = await controller.GetPatientById(1);
            //assert
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actual = okObjectResult.Value as PatientDTO;
            Assert.NotNull(actual);
            Assert.Equal(patientDTO.Id, actual.Id);
            Assert.Equal(patientDTO.LastName, actual.LastName);
            Assert.Equal(patientDTO.FirstName, actual.FirstName);
            Assert.Equal(patientDTO.DateOfBirth, actual.DateOfBirth);
            Assert.Equal(patientDTO.Gender, actual.Gender);
            Assert.Equal(patientDTO .PhoneNumber, actual.PhoneNumber);
        }

        [Fact]
        public async Task GetAsynById_ShallReturnNotFoundResult_WhenPatientNotFound()
        {
            //arrange
            var patient = new Patient()
            {
                Id = 1,
                LastName = "Poels",
                FirstName = "Maria",
                DateOfBirth = new DateTime(1996, 6, 1),
                Gender = 1,
                PhoneNumber = "123456789",
                Email = "maria@test.com"    
            };

            var mapper = new Mapper(_mapperConfiguration);
            _mockPatientRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(patient);
            var controller = new PatientController(_mockPatientRepo.Object, mapper);

            //act
            var actionResult = await controller.GetPatientById(99);

            //assert
            var notFoundObjectResult = actionResult.Result as NotFoundResult;
            Assert.NotNull(notFoundObjectResult);
        }

        [Fact]
        public async Task CreateDoctorAppointment_AddPatientCorrectly_WhenNewPatientIsAdded()
        {
            //arrange
            var patient = new Patient()
            {
                Id = 1,
                LastName = "Poels",
                FirstName = "Maria",
                DateOfBirth = new DateTime(1996, 6, 1),
                Gender = 1,
                PhoneNumber = "123456789",
                Email = "maria@test.com"
            };

            var newPatient = new PatientCreateDTO()
            {
                LastName = "Poels",
                FirstName = "Maria",
                DateOfBirth = new DateTime(1996, 6, 1),
                Gender = 1,
                PhoneNumber = "123456789",
                Email = "maria@test.com",
                Address = "Teststraat 1"
            };

            var mapper = new Mapper(_mapperConfiguration);
            _mockPatientRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(patient);
            var controller = new PatientController(_mockPatientRepo.Object, mapper);

            //act
            var actionResult = await controller.AddPatient(newPatient);

            //assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);

        }

        private static IEnumerable<Patient> PatientList()
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
