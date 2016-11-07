using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace SGTE_v1._0
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["id_user"] = null;
                Session["perfil_user"] = null;
                Session["nombre_user"] = null;
                Session["id_persona"] = null;                
            }
        }

        protected void iniciarSesion(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if(usuario.Length ==0|| contraseña.Length == 0)
                Response.Write("<script>alert('Debe llenar campos Usuario y Contraseña')</script>");
            else
            {
                DtoPersona pers = new DtoPersona();
                DtoUsuario user = new DtoUsuario();
                user.usuario = usuario;
                user.clave = contraseña;

                CtrUsuario neguser = new CtrUsuario();
                if (neguser.consultarUsuario(user))
                {
                    neguser.consultarUsuario(user);

                    if (user.estado == "True")
                    {
                        pers.codUsuario = user.codUsuario;
                        CtrPersona negpers = new CtrPersona();
                        negpers.consultarPersonaxcodUsuario(pers);

                        Session["id_user"] = user.codUsuario;
                        Session["perfil_user"] = user.codPerfil;
                        Session["nombre_user"] = pers.nombres + " " + pers.apPaterno + " " + pers.apMaterno;
                        Session["id_persona"] = pers.codPersona;

                        Response.Redirect("SesionUsuario.aspx");
                    }
                    else
                        Response.Write("<script>alert('Usted no esta habilitado para ingresar a la aplicación')</script>");
                }
                else
                    Response.Write("<script>alert('Usuario y/o Contraseña incorrecto, Verificar')</script>");
            }

        }
    }
}