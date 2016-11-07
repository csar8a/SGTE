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
    public class CtrServicio
    {
        DaoServicio daoservi;

         public CtrServicio()
        {
            daoservi = new DaoServicio();
        }
         public void registrarServicio(DtoServicio serv)
         {
             daoservi.InsertServicio(serv);
         }
         public void modificarServicio(DtoServicio serv)
         {
             daoservi.updateServicio(serv);
         }

         public void inhabilitarServicio(DtoServicio serv)
         {
            
             daoservi.disableServicio(serv);

           


         }

         public bool consultarServicio(DtoServicio serv)
         {
             return daoservi.getServicio(serv);
         }





         public DataSet listarServicios(int estado)
         {
             return daoservi.getServicios(estado);
         }

         public DataSet listarServicio2(int  estado, string nombre)
         {
             return daoservi.getServicios2 (estado, nombre);
         }


    }
}
