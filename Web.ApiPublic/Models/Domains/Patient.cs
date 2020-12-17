using System.ComponentModel.DataAnnotations;

namespace Web.ApiPublic.Models.Domains
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FullName { get; set; }

        [Required]
        public string NationalIdNumber { get; set; } //Rodne cislo
    }
}
