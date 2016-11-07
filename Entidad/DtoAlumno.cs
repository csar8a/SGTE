using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoAlumno : DtoPersona
    {
        public string nivel { get; set; }
        public string grado { get; set; }
    }
}
