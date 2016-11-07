using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;

namespace CTR
{
    public class CtrUbigeo
    {
        DaoUbigeo dat_ubigeo;
        public CtrUbigeo()
        {
            dat_ubigeo = new DaoUbigeo();
        }
        public DataSet getDepartamentos()
        {
            return dat_ubigeo.getDepartamentos();
        }
        public DataSet getProvincias(int codDepartamento)
        {
            return dat_ubigeo.getProvincias(codDepartamento);
        }
        public DataSet getDistrito(int codProvincia)
        {
            return dat_ubigeo.getDistritos(codProvincia);
        }

        public int getProvincia(int codDistrito)
        {
            return dat_ubigeo.getProvincia(codDistrito);
        }

        public int getDepartamento(int codProvincia)
        {
            return dat_ubigeo.getDepartamento(codProvincia);
        }
    }
}
