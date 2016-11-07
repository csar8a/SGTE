using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPagoTaller
    {
        public int codPagoTaller { get; set; }
        public DateTime fechaEnviada { get; set; }
        public string urlPagoTaller { get; set; }
        public string estado { get; set; }
        public int codPersona { get; set; }
        public int codTallerAperturado { get; set; }
    }
}
