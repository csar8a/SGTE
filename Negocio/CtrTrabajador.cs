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
    public class CtrTrabajador
    {
        DaoTrabajador dattra;
        public CtrTrabajador()
        {
            dattra = new DaoTrabajador();
        }

        public void registrarTrabajador(DtoTrabajador tra)
        {
            dattra.insertTrabajador(tra);
        }

        public void modificarTrabajador(DtoTrabajador tra)
        {
            dattra.updateTrabajador(tra);
        }

        public void inhabilitarTrabajador(DtoTrabajador tra)
        {
            dattra.disableTrabajador(tra);
        }

        //public void eliminarTrabajador(DtoTrabajador tra)
        //{
        //    dattra.deleteTrabajador(tra);
        //}

        public bool consultarTrabajador(DtoTrabajador tra)
        {
            return dattra.getTrabajador(tra);
        }
    }
}
