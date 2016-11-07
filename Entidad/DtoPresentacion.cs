using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPresentacion
    {
        public int codPresentacion { get; set; }
        public int codVenta { get; set; }
        public string detalle { get; set; }
        public DateTime fechaPresentacion { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime horaFin { get; set; }
        public string estado { get; set; }
    }
}
