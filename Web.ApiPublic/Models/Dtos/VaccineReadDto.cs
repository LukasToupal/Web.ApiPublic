using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ApiPublic.Models.Dtos
{
    public class VaccineReadDto
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public bool Applied { get; set; }
    }
}
