using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using Web.ApiPublic.Data;
using Web.ApiPublic.Data.Interface;
using Web.ApiPublic.Models;
using Web.ApiPublic.Models.Domains;
using Web.ApiPublic.Models.Dtos;

namespace Web.ApiPublic.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IApiPublicRepo _repository;
        private readonly IMapper _mapper;

        public PatientsController(IApiPublicRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientReadDto>> GetAllPatients()
        {
            var patients = _repository.GetAllPatients();

            return Ok(_mapper.Map<IEnumerable<PatientReadDto>>(patients));
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public ActionResult<PatientReadDto> GetPatientById(int id)
        {
            var patient = _repository.GetPatientById(id);

            if (patient != null)
            {
                return Ok(_mapper.Map<PatientReadDto>(patient));
            }

            return NotFound();
        }

        [HttpGet("{fullName}/{nationalIdNumber}", Name = "GetPatient")]
        public ActionResult<PatientReadDto> GetPatient(string fullName, string nationalIdNumber)
        {
            var patient = _repository.GetPatient(fullName, nationalIdNumber);

            if (patient != null)
            {
                return Ok(_mapper.Map<PatientReadDto>(patient));
            }

            return NotFound();
        }

        // POST api/patients
        [HttpPost]
        public ActionResult<PatientReadDto> CreatePatient(PatientCreateDto patientCreateDto)
        {
            var patient = _mapper.Map<Patient>(patientCreateDto);
            _repository.CreatePatient(patient);
            _repository.SaveChanges();

            var patientReadDto = _mapper.Map<PatientReadDto>(patient);

            return CreatedAtRoute(nameof(GetPatientById), new { Id = patientReadDto.Id }, patientReadDto);
        }
    }
}
