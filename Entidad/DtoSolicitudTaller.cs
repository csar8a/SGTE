using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoSolicitudTaller: DtoSolicitud
    {
        public string nombreColegio { get; set; }
        public string direccionColegio { get; set; }
    }
}
