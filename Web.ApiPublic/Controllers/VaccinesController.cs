using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using AutoMapper;
using Web.ApiPublic.Data.Interface;
using Web.ApiPublic.Models.Domains;
using Web.ApiPublic.Models.Dtos;

namespace Web.ApiPublic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccinesController : ControllerBase
    {
        private readonly IApiPublicRepo _repository;
        private readonly IMapper _mapper;

        public VaccinesController(IApiPublicRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VaccineReadDto>> GetAllVaccines()
        {
            var vaccines = _repository.GetAllVaccines();

            return Ok(_mapper.Map<IEnumerable<VaccineReadDto>>(vaccines));
        }

        [HttpGet("{id}", Name = "GetVaccineById")]
        public ActionResult<Vaccine> GetVaccineById(int id)
        {
            var vaccine = _repository.GetVaccineById(id);

            if (vaccine != null)
            {
                return Ok(_mapper.Map<VaccineReadDto>(vaccine));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<VaccineReadDto> CreateVaccine(VaccineCreateDto vaccineCreateDto)
        {
            var vaccine = _mapper.Map<Vaccine>(vaccineCreateDto);
            _repository.CreateVaccine(vaccine);
            _repository.SaveChanges();

            var vaccineReadDto = _mapper.Map<VaccineReadDto>(vaccine);

            return CreatedAtRoute(nameof(GetVaccineById), new { Id = vaccineReadDto.Id }, vaccineReadDto);
        }

        [HttpPost("{patientId}")]
        public ActionResult<VaccineReadDto> VaccinatePatient(int patientId)
        {
            _repository.VaccinatePatient(patientId);
            _repository.SaveChanges();

            var vaccine = _repository.GetVaccineByPatientId(patientId);

            return Ok(_mapper.Map<VaccineReadDto>(vaccine));
        }
    }
}
