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
    public class CtrProfesor
    {
        DaoProfesor datprof;
        DaoTrabajador daotra;
        DaoPersona daopers;
        public CtrProfesor()
        {
            datprof = new DaoProfesor();
            daotra = new DaoTrabajador();
            daopers = new DaoPersona();
        }

        public DataSet listarTallerxProfesor(int codPersona)								
        {													
            return datprof.getTalleresxProfesor(codPersona);							
        }

        public void registrarProfesor(DtoProfesor prof)
        {
            DtoPersona pers = prof;
            daopers.insertPersona(pers);

            DtoTrabajador tra = prof;
            try { daotra.insertTrabajador(tra); }
            catch { daopers.deleteLastPersona(pers); }

            try { datprof.insertProfesor(prof); }
            catch { daotra.deleteLastTrabajador(tra); daopers.deleteLastPersona(pers); }
        }

        public void modificarProfesor(DtoProfesor prof)
        {
            DtoPersona pers = prof;
            daopers.updatePersona(pers);

            DtoTrabajador tra = prof;
            daotra.updateTrabajador(tra);

            datprof.updateProfesor(prof);
        }

        public void inhabilitarProfesor(DtoProfesor prof)
        {
            DtoTrabajador tra = prof;
            daotra.disableTrabajador(tra);

            datprof.disableProfesor(prof);
        }

        public bool consultarProfesor(DtoProfesor prof)
        {
            return datprof.getProfesor(prof);
        }

        public DataSet listarProfesores(string estadoProfesor)
        {
            return datprof.getProfesores(estadoProfesor);
        }

        public DataSet listarProfesor(string estadoProfesor, string nombre)
        {
            return datprof.getProfesores1(estadoProfesor, nombre);
        }
        public bool consultarNumDocxPersona(string numDocumento)
        {
            return daopers.getNumDocxPersona(numDocumento);
        }
        public bool consultarEmailxPersona(string email)
        {
            return daopers.getEmailxPersona(email);
        }

        public DataSet listarProfTrabajadoresActivos()
        {
            return datprof.getProfTrabajadores();
        }
    }
}
