using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPagoServicio
    {
        public int codPagoServicio { get; set; }
        public DateTime fechaEnviada { get; set; }
        public string urlPagoServicio { get; set; }
        public string estado { get; set; }
        public int codSolicitud { get; set; }
    }
}
