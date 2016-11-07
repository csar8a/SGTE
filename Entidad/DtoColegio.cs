using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoColegio
    {
        public int codColegio { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string caracter { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public string estado { get; set; }
        public int codDistrito { get; set; }
    }
}
