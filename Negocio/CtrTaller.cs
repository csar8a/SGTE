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
    public class CtrTaller
    {
        DaoTaller dattall;
        public CtrTaller()
        {
            dattall = new DaoTaller();
        }
        public void registrarTaller(DtoTaller tall)
        {
            dattall.insertTaller(tall);
        }
        public void actualizarTaller(DtoTaller tall)
        {
            dattall.updateTaller(tall);
        }
        public bool consultarTaller(DtoTaller tall)
        {
            return dattall.getTaller(tall);
        }
        public DataSet listarTalleres()
        {
            return dattall.getTalleres();
        }
    }
}