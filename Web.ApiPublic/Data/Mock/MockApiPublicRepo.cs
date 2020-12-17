using System.Collections.Generic;
using Web.ApiPublic.Data.Interface;
using Web.ApiPublic.Models;
using Web.ApiPublic.Models.Domains;

namespace Web.ApiPublic.Data.Mock
{
    /* Note: Look into bogus nuget package to populate with fake data */

    public class MockApiPublicRepo : IApiPublicRepo
    {
        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return new List<Patient>
            {
                new Patient{ Id = 1, FullName = "Johansen Bughar", NationalIdNumber = "891221/3101" },
                new Patient{ Id = 2, FullName = "Karl Benhun", NationalIdNumber = "010520/6959" }
            };
        }

        public Patient GetPatientById(int id)
        {
            return new Patient{ Id = 1, FullName = "Johansen Bughar", NationalIdNumber = "891221 / 3101" };
        }

        public Patient GetPatient(string fullName, string nationalIdNumber)
        {
            throw new System.NotImplementedException();
        }

        public void CreatePatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Vaccine> GetAllVaccines()
        {
            throw new System.NotImplementedException();
        }

        public Vaccine GetVaccineById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Vaccine GetVaccineByPatientId(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public void CreateVaccine(Vaccine vaccine)
        {
            throw new System.NotImplementedException();
        }

        public void VaccinatePatient(int patientId)
        {
            throw new System.NotImplementedException();
        }
    }
}
