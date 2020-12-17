using Microsoft.EntityFrameworkCore;
using Web.ApiPublic.Models;
using Web.ApiPublic.Models.Domains;

namespace Web.ApiPublic.Data.DbContext
{
    public class ApiPublicContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApiPublicContext(DbContextOptions<ApiPublicContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
    }
}
