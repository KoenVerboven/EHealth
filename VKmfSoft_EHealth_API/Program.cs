using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using VKmfSoft_EHealth_API.AutoMapper;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddAutoMapper(cfg =>
           cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxODA1NDE0NDAwIiwiaWF0IjoiMTc3MzkyOTgxNiIsImFjY291bnRfaWQiOiIwMTlkMDY3MDkxYmM3YmM0YWM0MGU2M2MwYmRjYzAwZCIsImN1c3RvbWVyX2lkIjoiY3RtXzAxa20zNzlyZjcyZ2Fna3JzZ2prc2d0eXNwIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.ePB0aHCScYiAEkBaRc6ptNMVd8XH9YxyCsrJqJBdPCDeCe_0Cxxi3Pn-9WjnDmUCOE7Pd3pUQK1OvWuqDD__au2D6rd0-0aAedCHGQm0wn411CRrUkKk8R0wJuqg46OdDJWeOCgaa6htpzo9so8_wLG1lST7ikqv_QYu6PTgFUorqtUKmYZ4xrOK_eFGDGepItGqKMkn2uK76jh8M2VuW3sm_ad2fEQAtKI-qe5rIGEo5jyWxVDC1Uc33xSjGRM_uX8-ny1VEZhnwKotYQ8ORLcuBAAoox31VulMKYyqbLQsaWaqWyjpGnqd_PaD2ggUHrF4qJvQSgqtV772FffFcQ"
           , typeof(MappingConfig));

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
