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
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace EhealthApiTests;


public class DoctorControllerTests
{
    private readonly Mock<IDoctorRepository> _mockDoctorRepo;
    private readonly Mock<ILogger<DoctorController>> _mockILogger;
    private readonly MapperConfiguration _mapperConfiguration;

    public DoctorControllerTests()
    {
        _mockDoctorRepo = new Mock<IDoctorRepository>(MockBehavior.Default);
        _mockILogger = new Mock<ILogger<DoctorController>>(MockBehavior.Default);

        var myProfile = new MappingConfig();
        _mapperConfiguration = new MapperConfiguration(
            cfg => cfg.AddProfile(myProfile), new LoggerFactory()
            );
    }

    [Fact]
    public async Task GetAllAync_ShallReturnItemsCount_ForDoctorListContainItems()
    {
        //arrange
        var mapper = _mapperConfiguration.CreateMapper();
        var mockRepo = new Mock<IDoctorRepository>();
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(DoctorList());
        var controller = new DoctorController(mockRepo.Object, mapper);

        //act
        var actionResult = await controller.Get();

        //assert
        Assert.IsType<OkObjectResult>(actionResult.Result);
        Assert.NotNull(actionResult);

        var okObjectResult = actionResult.Result as OkObjectResult;
        var actual = okObjectResult!.Value as IEnumerable<DoctorDTO>;
        var count = actual!.Count();
        Assert.Equal(2, count);
    }

    [Fact]
    public async Task GetAsynById_ShallReturnDoctorWithId_ForExistingDoctorWithId()
    {
        //arrange
        var doctor = new Doctor()
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
            LicenseNumber = "12344444"
        };

        var doctorDTO = new DoctorDTO()
        {
            Id = doctor.Id,
            LastName = doctor.LastName,
            FirstName = doctor.FirstName,
            Addresses  = doctor.Addresses,
            DateOfBirth = doctor.DateOfBirth,
            Gender = doctor.Gender,
            PhoneNumber = doctor.PhoneNumber,
            Email = doctor.Email,
            LicenseNumber = doctor.LicenseNumber
        };

        var mapper = new Mapper(_mapperConfiguration);
        _mockDoctorRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(doctor);
        var controller = new DoctorController(_mockDoctorRepo.Object, mapper);

        //act
        var actionResult = await controller.GetDoctorById(1);
        //assert
        var okObjectResult = actionResult.Result as OkObjectResult;
        Assert.NotNull(okObjectResult);

        var actual = okObjectResult.Value as DoctorDTO;
        Assert.NotNull(actual);
        Assert.Equal(doctorDTO.Id, actual.Id);
        Assert.Equal(doctorDTO.LastName, actual.LastName);
        Assert.Equal(doctorDTO.FirstName, actual.FirstName);
        Assert.Equal(doctorDTO.DateOfBirth, actual.DateOfBirth);
        Assert.Equal(doctorDTO.Gender, actual.Gender);
        Assert.Equal(doctorDTO.PhoneNumber, actual.PhoneNumber);
        Assert.Equal(doctorDTO.Email, actual.Email);
        Assert.Equal(doctorDTO.LicenseNumber, actual.LicenseNumber);
    }

    [Fact]
    public async Task GetAsynById_ShallReturnNotFoundResult_WhenDoctorNotFound()
    {
        //arrange
        var doctor = new Doctor()
        {
            Id = 1,
            LastName = "Poels",
            FirstName = "Maria",
            DateOfBirth = new DateTime(1996, 6, 1),
            Gender = 1,
            PhoneNumber = "123456789",
            Email = "maria@test.com",
            LicenseNumber = "12344444"
        };

        var mapper = new Mapper(_mapperConfiguration);
        _mockDoctorRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(doctor);
        var controller = new DoctorController(_mockDoctorRepo.Object, mapper);

        //act
        var actionResult = await controller.GetDoctorById(99);

        //assert
        var notFoundObjectResult = actionResult.Result as NotFoundResult;
        Assert.NotNull(notFoundObjectResult);
    }

    private static IEnumerable<Doctor> DoctorList()
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
