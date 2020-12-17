using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Web.ApiPublic.Models.Domains;
using Web.ApiPublic.Models.Dtos;

namespace Web.ApiPublic.Profiles
{
    public class PatientsProfile : Profile
    {
        public PatientsProfile()
        {
            CreateMap<Patient, PatientReadDto>();
            CreateMap<PatientCreateDto, Patient>();

            CreateMap<Vaccine, VaccineReadDto>();
            CreateMap<VaccineCreateDto, Vaccine>();
        }
    }
}
