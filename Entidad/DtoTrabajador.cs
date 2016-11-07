using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoTrabajador : DtoPersona
    {
        public string urlFoto { get; set; }
        public Nullable<DateTime> fechaContrato { get; set; }
        public Nullable<int> duracionContrato { get; set; }
        public string tipoTrabajador { get; set; }
        public string estadoTrabajador { get; set; }
    }
}