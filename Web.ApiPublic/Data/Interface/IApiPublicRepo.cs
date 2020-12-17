using System.Collections.Generic;
using Web.ApiPublic.Models;
using Web.ApiPublic.Models.Domains;

namespace Web.ApiPublic.Data.Interface
{
    public interface IApiPublicRepo
    {
        bool SaveChanges();

        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int id);
        Patient GetPatient(string fullName, string nationalIdNumber);
        void CreatePatient(Patient patient);

        IEnumerable<Vaccine> GetAllVaccines();
        Vaccine GetVaccineById(int id);
        Vaccine GetVaccineByPatientId(int patientId);
        void CreateVaccine(Vaccine vaccine);
        void VaccinatePatient(int patientId);
    }
}
