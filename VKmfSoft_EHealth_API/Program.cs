using Microsoft.EntityFrameworkCore;
using Serilog;
using VKmfSoft_EHealth_API.AutoMapper;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;

var builder = WebApplication.CreateBuilder(args);

//logger :
var configuration = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json")
   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
   .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddAutoMapper(cfg =>
               cfg.LicenseKey = builder.Configuration.GetValue<string>("AutoMapper:LicenseKey"),
               typeof(MappingConfig));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


// Dependency Injection for Repositories:
builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<IDoctorAppointmentRepository, DoctorAppointmentRepository>();
builder.Services.AddScoped<IEmergencyRoomRepository, EmergencyRoomRepository>();
builder.Services.AddScoped<IIntensiveCareRoomRepository, IntensiveCareRoomRepository>();
builder.Services.AddScoped<IOnePersonPatientRoomRepository, OnePersonPatientRoomRepository>();
builder.Services.AddScoped<IMorePersonPatientRoomRepository, MorePersonPatientRoomRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
