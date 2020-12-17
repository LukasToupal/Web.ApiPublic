using System.ComponentModel.DataAnnotations;

namespace Web.ApiPublic.Models.Domains
{
    public class Vaccine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public bool Applied { get; set; }
    }
}
