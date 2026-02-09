
using AutoMapper;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Patient;

namespace VKmfSoft_EHealth_API.AutoMapper
{
    public class MappingConfig:Profile
    {
        public MappingConfig() 
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Doctor, DoctorCreateDTO>().ReverseMap();
            CreateMap<Doctor, DoctorUpdateDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, PatientCreateDTO>().ReverseMap();
            CreateMap<Patient, PatientUpdateDTO>().ReverseMap();
        }
    }
}
