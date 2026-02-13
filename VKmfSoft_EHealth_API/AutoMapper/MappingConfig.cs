
using AutoMapper;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.Domain.TimeShedule;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
using VKmfSoft_EHealth_API.Models.DTO.TimeShedule;

namespace VKmfSoft_EHealth_API.AutoMapper
{
    public class MappingConfig:Profile
    {
        public MappingConfig() 
        {
            CreateMap<Hospital, HospitalDTO>().ReverseMap();
            CreateMap<Hospital, HospitalCreateDTO>().ReverseMap();
            CreateMap<Hospital, HospitalUpdateDTO>().ReverseMap();

            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Doctor, DoctorCreateDTO>().ReverseMap();
            CreateMap<Doctor, DoctorUpdateDTO>().ReverseMap();

            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Patient, PatientCreateDTO>().ReverseMap();
            CreateMap<Patient, PatientUpdateDTO>().ReverseMap();

            CreateMap<Nurse, NurseDTO>().ReverseMap();
            CreateMap<Nurse, NurseCreateDTO>().ReverseMap();
            CreateMap<Nurse, NurseUpdateDTO>().ReverseMap();

            CreateMap<DoctorAppointment, DoctorAppointmentDTO>().ReverseMap();
            CreateMap<DoctorAppointment, DoctorAppointmentCreateDTO>().ReverseMap();
            CreateMap<DoctorAppointment, DoctorAppointmentUpdateDTO>().ReverseMap();

            CreateMap<IntensiveCareRoom, IntensiveCareRoomDTO>().ReverseMap();
            CreateMap<IntensiveCareRoom, IntensiveCareRoomCreateDTO>().ReverseMap();
            CreateMap<IntensiveCareRoom, IntensiveCareRoomUpdateDTO>().ReverseMap();

            CreateMap<OnePersonPatientRoom, OnePersonPatientRoomDTO>().ReverseMap();
            CreateMap<OnePersonPatientRoom, OnePersonPatientRoomCreateDTO>().ReverseMap();
            CreateMap<OnePersonPatientRoom, OnePersonPatientRoomUpdateDTO>().ReverseMap();

            CreateMap<MorePersonPatientRoom, MorePersonPatientRoomDTO>().ReverseMap();
            CreateMap<MorePersonPatientRoom, MorePersonPatientRoomCreateDTO>().ReverseMap();
            CreateMap<MorePersonPatientRoom, MorePersonPatientRoomUpdateDTO>().ReverseMap();
        }
    }
}
