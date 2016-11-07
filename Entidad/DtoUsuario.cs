using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoUsuario
    {
        public int codUsuario { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string estado { get; set; }
        public int codPerfil { get; set; }
    }
}
