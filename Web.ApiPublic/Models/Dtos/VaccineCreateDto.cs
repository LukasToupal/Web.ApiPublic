using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ApiPublic.Models.Dtos
{
    public class VaccineCreateDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public bool Applied { get; set; }
    }
}
