using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoDisponibilidadColegio
    {
        public int codDisponibilidad { get; set; }
        public string codigoAula { get; set; }
        public string dia { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public int codVenta { get; set; }
    }
}
