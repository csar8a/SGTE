using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPreferencia
    {
        public string dia { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public int codTaller { get; set; }
        public int codPersona { get; set; }
        
    }
}
