using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ApiPublic.Models.Dtos
{
    public class PatientCreateDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string NationalIdNumber { get; set; } //Rodne cislo
    }
}
