using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoVenta
    {
        public int codVenta { get; set; }
        public DateTime fechaContacto { get; set; }
        public string codigoVerificacion { get; set; }
        public string observacion { get; set; }
        public string estado { get; set; }
        public int codColegio { get; set; }
        public Nullable<int> codSolicitud { get; set; }
    }
}