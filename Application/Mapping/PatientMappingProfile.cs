using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Commands.UpdatePatient;
using Application.Features.Patients.Queries.GetAllPatients;
using Application.Features.Patients.Queries.GetPatientDetail;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, CreatedPatientVm>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreatePatientCommand, Patient>();

            CreateMap<Patient, PatientListVm>();
            CreateMap<Patient, PatientDetailVm>();
            CreateMap<UpdatePatientCommand, Patient>();
        }
    }
}
