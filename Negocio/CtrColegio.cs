using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAO;

namespace CTR
{
    
    public class CtrColegio
    {
        DaoColegio daoColegio;
        public CtrColegio()
        {
            daoColegio = new DaoColegio();
        }

        public bool consultarColegio(DtoColegio prof)
        {
            return daoColegio.getColegio(prof);
        }

    }


}
