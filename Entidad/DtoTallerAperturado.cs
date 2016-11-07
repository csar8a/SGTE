using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoTallerAperturado : DtoPersona
    {
        public int codTallerAperturado { get; set; }
        public string dia { get; set; }
        public DateTime horaInicio { get; set; }
        public DateTime Fin { get; set; }
        public string estado { get; set; }
        public int codVenta { get; set; }
        public int codTaller { get; set; }
        public Nullable<int> codProfesor { get; set; }
    }
}
