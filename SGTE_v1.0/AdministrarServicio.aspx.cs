using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using CTR;

namespace SGTE_v1._0
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarServicios();
            }

        }
        public void listarServicios()
        {
            CtrServicio negser = new CtrServicio();
            lbl_mensaje.Text = "";

            if (!check_visualizar.Checked)
            {
                DataSet dsServicios = negser.listarServicios(1);
                gv_servicios.DataSource = dsServicios.Tables[0];
                gv_servicios.DataBind();
                hab.Text = "HABLITADOS";
                if (gv_servicios.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró servicios";
                else
                    lbl_mensaje.Text = "";
            }
            else
            {
                DataSet dsServicios = negser.listarServicios(0);
                gv_servicios.DataSource = dsServicios.Tables[0];
                gv_servicios.DataBind();
                hab.Text = "DESHABLITADOS";
                if (gv_servicios.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró servicios";
                else
                    lbl_mensaje.Text = "";
            }
        }


        public void listarServicio2()
        {
            CtrServicio negserv = new CtrServicio();
            lbl_mensaje.Text = "";

            if (!check_visualizar.Checked)
            {
                DataSet dsProfesores = negserv.listarServicio2(1, txt_servicio.Text.ToString().Trim());
                gv_servicios.DataSource = dsProfesores.Tables[0];
                gv_servicios.DataBind();

                if (gv_servicios.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró el servicio";
                else
                    lbl_mensaje.Text = "";
            }
            else
            {
                DataSet dsProfesores = negserv.listarServicio2(0, txt_servicio.Text.ToString().Trim());
                gv_servicios.DataSource = dsProfesores.Tables[0];
                gv_servicios.DataBind();

                if (gv_servicios.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró el servicio";
                else
                    lbl_mensaje.Text = "";
            }
        }





        protected void gv_servicios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_servicios.PageIndex = e.NewPageIndex;
            listarServicios();
        }

        protected void check_visualizar_CheckedChanged(object sender, EventArgs e)
        {
            
            
            listarServicios();
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_servicio.Text))
                listarServicios();
            else
                listarServicio2();
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarServicio.aspx");
        }

        protected void gv_servicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName =="Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gv_servicios.Rows[index];
                TableCell tbcId = selectedRow.Cells[0];

                Response.Redirect("VerServicios.aspx?c="+tbcId.Text);
            }
        }


    }
}