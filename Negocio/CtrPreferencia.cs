using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTR
{
    public class CtrPreferencia
    {
        DaoPreferencia daopref;

        public CtrPreferencia()
        {
            daopref = new DaoPreferencia();
        }

        public void registrarPreferencia(DtoPreferencia dtopref)
        {
            daopref.insertPreferencia(dtopref);
        }

        //public DataSet consultarPreferencias()
        //{
        //   return daopref.getPreferencias();
        //}
    }
}
