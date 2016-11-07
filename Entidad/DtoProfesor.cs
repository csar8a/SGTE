using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoProfesor : DtoTrabajador
    {
        public Nullable<double> latitud { get; set; }
        public Nullable<double> longitud { get; set; }
        public string diasDisponible { get; set; }
        public string urlCV { get; set; }
        public string estadoProfesor { get; set; }
    }
}
