using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoPersona
    {
        public int codPersona { get; set; }
        public string numDocumento { get; set; }
        public string nombres { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public char sexo { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public Nullable<int> codUsuario { get; set; }
        public int codDistrito { get; set; }
    }
}