using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoSolicitud
    {
        public int codSolicitud { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public string estado { get; set; }
        public int codPersona { get; set; }
    }
}
