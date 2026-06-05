

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VKmfSoft_EHealth_API.AutoMapper;
using VKmfSoft_EHealth_API.Controllers;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
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

        private IEnumerable<Patient> PatientList()
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
