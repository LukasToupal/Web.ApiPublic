using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ApiPublic.Data.DbContext;
using Web.ApiPublic.Data.Interface;
using Web.ApiPublic.Models;
using Web.ApiPublic.Models.Domains;
using Web.ApiPublic.Models.Dtos;

namespace Web.ApiPublic.Data
{
    public class SqlApiPublicRepo : IApiPublicRepo
    {
        private readonly ApiPublicContext _context;

        public SqlApiPublicRepo(ApiPublicContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public Patient GetPatient(string fullName, string nationalIdNumber)
        {
            return _context.Patients.FirstOrDefault(p => p.FullName == fullName && p.NationalIdNumber == nationalIdNumber);
        }

        public void CreatePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _context.Patients.Add(patient);
        }

        public IEnumerable<Vaccine> GetAllVaccines()
        {
            return _context.Vaccines.ToList();
        }

        public Vaccine GetVaccineById(int id)
        {
            return _context.Vaccines.FirstOrDefault(v => v.Id == id);
        }

        public Vaccine GetVaccineByPatientId(int patientId)
        {
            return _context.Vaccines.FirstOrDefault(v => v.PatientId == patientId);
        }


        public void CreateVaccine(Vaccine vaccine)
        {
            if (vaccine == null)
            {
                throw new ArgumentNullException(nameof(vaccine));
            }

            _context.Vaccines.Add(vaccine);
        }

        public void VaccinatePatient(int patientId)
        {
            var patient = GetPatientById(patientId);

            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            var vaccine = GetVaccineByPatientId(patientId);

            if (vaccine == null)
            {
                var newVaccine = new Vaccine
                {
                    Applied = true,
                    PatientId = patientId
                };
                CreateVaccine(newVaccine);
            }
            else
            {
                vaccine.Applied = true;
            }
        }
    }
}
