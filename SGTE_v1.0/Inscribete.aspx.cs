using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGTE_v1._0
{
    public partial class Inscribete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTalleres();
        }

        public void llenarTalleres()
        {
            CtrTaller talleres = new CtrTaller();
            ddlTipoTaller.DataSource = talleres.listarTalleres();
            ddlTipoTaller.DataValueField = "codTaller";
            ddlTipoTaller.DataTextField = "nombre";
            ddlTipoTaller.DataBind();
        }

        public void registrarInscripcion()
        {
            DtoPreferencia preferencia = new DtoPreferencia();
            CtrPreferencia obj = new CtrPreferencia();
            try
            {
                preferencia.codTaller = Int32.Parse(ddlTipoTaller.SelectedValue);

                if (rbDias.SelectedValue == "")
                {
                    lblmensaje.Text = "Debe ingresar un día"; lblmensaje.ForeColor = System.Drawing.Color.Red;
                }
                else { preferencia.dia = rbDias.SelectedValue; }


                    preferencia.horaInicio = DateTime.Parse(ddlHoraInicio.SelectedValue);
                //preferencia.horaFin = DateTime.Parse(ddlHoraFin.SelectedValue);
                preferencia.horaFin = DateTime.Parse(ddlHoraInicio.SelectedValue).AddHours(2);

                


                preferencia.codPersona = Int32.Parse(Session["id_persona"].ToString());

                obj.registrarPreferencia(preferencia);
                lblmensaje.Text = "Se ha enviado tu preferencia :D ";
                lblmensaje.ForeColor = System.Drawing.Color.Blue;
            }
            catch
            {
                
            }

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            registrarInscripcion();
        }
    }
}