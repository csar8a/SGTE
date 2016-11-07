using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DtoSolicitudServicio: DtoSolicitud
    {
        public string dimension { get; set; }
        public string material { get; set; }
        public string url { get; set; }
        public int codServicio { get; set; }
    }
}
