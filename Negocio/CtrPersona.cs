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
    public class CtrPersona
    {
        DaoPersona daopers;
        public CtrPersona()
        {
            daopers = new DaoPersona();
        }

        public void registrarPersona(DtoPersona pers)
        {
            daopers.insertPersona(pers);
        }

        public void modificarPersona(DtoPersona pers)
        {
            daopers.updatePersona(pers);
        }

        public bool consultarPersona(DtoPersona persona)
        {
            return daopers.getPersona(persona);
        }

        public bool consultarPersonaxcodUsuario(DtoPersona persona)
        {
            return daopers.getPersonaxcodUsuario(persona);
        }

        //.-----.---..implementado

        public DataSet listarTalleres(int codPersona)
        {
            return daopers.getTalleresxCole(codPersona);
        }


        public string consultarAlumno(int codPersona)
        {
            return daopers.getAlumnoXcode(codPersona);
        }
    }
}
