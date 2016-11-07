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
    public class CtrUsuario
    {
        DaoUsuario datuser;
        public CtrUsuario()
        {
            datuser = new DaoUsuario();
        }

        public void registrarUsuario(DtoUsuario usu)
        {
            datuser.insertUsuario(usu);
        }

        public int consultarUltimoUsuario()
        {
            return datuser.getLastUsuario();
        }

        public void habilitarUsuario(DtoUsuario usu)
        {
            datuser.enableUsuario(usu);
        }

        public void inhabilitarUsuario(DtoUsuario usu)
        {
            datuser.disableUsuario(usu);
        }

        public bool consultarUsuario(DtoUsuario user)
        {
            return datuser.getUsuario(user);
        }
    }
}
