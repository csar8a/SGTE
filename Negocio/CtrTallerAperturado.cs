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
    public class CtrTallerAperturado
    {
        DaoTallerApert daotallape;
        public CtrTallerAperturado()
        {
            daotallape = new DaoTallerApert();
        }

        public string consultarTallerAperturado2(DtoTallerAperturado prof)
        {
            return daotallape.getTallerAperturado2(prof);
        }

        public bool consultarTallerAperturado3(DtoTallerAperturado prof)
        {
            return daotallape.getTallerAperturado3(prof);
        }

        public void updateTallxProf(int cT, int cP)
        {
            DaoTallerApert a = new DaoTallerApert();
            a.updateTallerAperturadoProfesor(cT, cP);
        }

        public void registrarAlumnoxTA(DtoTallerAperturado prof)
        {
            daotallape.insertAlumnoXtallerAperturado(prof);
        }
    }
}
