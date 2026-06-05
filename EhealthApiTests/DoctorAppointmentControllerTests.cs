
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VKmfSoft_EHealth_API.AutoMapper;
using VKmfSoft_EHealth_API.Controllers;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace EhealthApiTests
{
    public class DoctorAppointmentControllerTests
    {
        private readonly Mock<IDoctorAppointmentRepository> _mockDoctorAppointmentRepo;
        private readonly Mock<ILogger<DoctorAppointmentController>> _mockILogger;
        private readonly MapperConfiguration _mapperConfiguration;


        public DoctorAppointmentControllerTests()
        {
            _mockDoctorAppointmentRepo = new Mock<IDoctorAppointmentRepository>(MockBehavior.Default);
            _mockILogger = new Mock<ILogger<DoctorAppointmentController>>(MockBehavior.Default);

            var myProfile = new MappingConfig();
            _mapperConfiguration = new MapperConfiguration(
                cfg => cfg.AddProfile(myProfile), new LoggerFactory()
                );
        }

        [Fact]
        public async Task GetAllAync_ShallReturnTypeOK_ForDoctorAppointmentListContainItems()
        {
            //arrange
            var mapper = new Mapper(_mapperConfiguration);
            _mockDoctorAppointmentRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(DoctorAppointmentList());
            var controller = new DoctorAppointmentController(_mockDoctorAppointmentRepo.Object, mapper);

            //act
            var actionResult = await controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);
        }



        [Fact]
        public async Task GetAllAync_ShallReturnItemsCount_ForDoctorAppointmentListContainItems()
        {
            //arrange
            var mapper = _mapperConfiguration.CreateMapper();
            var mockRepo = new Mock<IDoctorAppointmentRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(DoctorAppointmentList());
            var controller = new DoctorAppointmentController(mockRepo.Object, mapper);

            //act
            var actionResult = await controller.Get();

            //assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.NotNull(actionResult);

            var okObjectResult = actionResult.Result as OkObjectResult;
            var actual = okObjectResult!.Value as IEnumerable<DoctorAppointmentDTO>;
            var count = actual!.Count();
            Assert.Equal(2, count);
        }

        [Fact]
        public async Task GetAsynById_ShallReturnDoctorAppointmentWithId_ForExistingDoctorAppointmentWithId()
        {
            //arrange
            var doctorAppointment = new DoctorAppointment()
            {
                Id = 1,
                PatientId = 1,
                DoctorId = 1,
                AppointmentDate = DateTime.Now,
                ReasonForVisit = "pain",
                Status = 1,
                DegreeOfUrgency = 1,
                AppointmentPlaceId = 1

            };

            var doctorAppointmentsDTO = new DoctorAppointmentDTO()
            {
                Id = doctorAppointment.Id,
                PatientId = doctorAppointment.PatientId,
                MedicalWorkerId = doctorAppointment.DoctorId,
                AppointmentDate = doctorAppointment.AppointmentDate,
                ReasonForVisit = doctorAppointment.ReasonForVisit,
                Status = doctorAppointment.Status,
                DegreeOfUrgency = doctorAppointment.DegreeOfUrgency,
                AppointmentPlaceId = doctorAppointment.AppointmentPlaceId
            };

            var mapper = new Mapper(_mapperConfiguration);
            _mockDoctorAppointmentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(doctorAppointment);
            var controller = new DoctorAppointmentController(_mockDoctorAppointmentRepo.Object, mapper);

            //act
            var actionResult = await controller.GetAppointmentById(1);
            //assert
            var okObjectResult = actionResult.Result as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actual = okObjectResult.Value as DoctorAppointmentDTO;
            Assert.NotNull(actual);
            Assert.Equal(doctorAppointmentsDTO.Id, actual.Id);
            Assert.Equal(doctorAppointmentsDTO.PatientId, actual.PatientId);
            Assert.Equal(doctorAppointmentsDTO.MedicalWorkerId, actual.MedicalWorkerId);
            Assert.Equal(doctorAppointmentsDTO.AppointmentDate, actual.AppointmentDate);
            Assert.Equal(doctorAppointmentsDTO.ReasonForVisit, actual.ReasonForVisit);
            Assert.Equal(doctorAppointmentsDTO.Status, actual.Status);
            Assert.Equal(doctorAppointmentsDTO.DegreeOfUrgency, actual.DegreeOfUrgency);
            Assert.Equal(doctorAppointmentsDTO.AppointmentPlaceId, actual.AppointmentPlaceId);              
        }

        [Fact]
        public async Task GetAsynById_ShallReturnNotFoundResult_WhenDoctorAppointmentNotFound()
        {
            //arrange
            var doctorAppointment = new DoctorAppointment()
            {
                Id = 1,
                PatientId = 1,
                DoctorId = 1,
                AppointmentDate = DateTime.Now,
                ReasonForVisit = "pain",
                Status = 1,
                DegreeOfUrgency = 1,
                AppointmentPlaceId = 1
            };

            var mapper = new Mapper(_mapperConfiguration);
            _mockDoctorAppointmentRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(doctorAppointment);
            var controller = new DoctorAppointmentController(_mockDoctorAppointmentRepo.Object, mapper);

            //act
            var actionResult = await controller.GetAppointmentById(99);

            //assert
            var notFoundObjectResult = actionResult.Result as NotFoundResult;
            Assert.NotNull(notFoundObjectResult);
        }

        private IEnumerable<DoctorAppointment> DoctorAppointmentList()
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
