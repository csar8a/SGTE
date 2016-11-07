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
    public partial class AdministrarProfesores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarProfesores();
            }
        }

        protected void btn_buscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_profesor.Text))
                listarProfesores();
            else
                listarProfesor();
        }

        protected void check_visualizar_CheckedChanged(object sender, EventArgs e)
        {
            listarProfesores();
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarProfesor.aspx");
        }

        protected void gv_profesores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gv_profesores.Rows[index];
                TableCell tbcId = selectedRow.Cells[0];

                Response.Redirect("VerProfesor.aspx?c=" + tbcId.Text);
            }
        }

        protected void gv_profesores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_profesores.PageIndex = e.NewPageIndex;
            listarProfesores();
        }

        public void listarProfesores()
        {
            CtrProfesor negprof = new CtrProfesor();
            lbl_mensaje.Text = "";

            if (!check_visualizar.Checked)
            {
                DataSet dsProfesores = negprof.listarProfesores("1");
                gv_profesores.DataSource = dsProfesores.Tables[0];
                gv_profesores.DataBind();

                if (gv_profesores.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró profesores";
                else
                    lbl_mensaje.Text = "";
            }
            else
            {
                DataSet dsProfesores = negprof.listarProfesores("0");
                gv_profesores.DataSource = dsProfesores.Tables[0];
                gv_profesores.DataBind();

                if (gv_profesores.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró profesores";
                else
                    lbl_mensaje.Text = "";
            }
        }

        public void listarProfesor()
        {
            CtrProfesor negprof = new CtrProfesor();
            lbl_mensaje.Text = "";

            if (!check_visualizar.Checked)
            {
                DataSet dsProfesores = negprof.listarProfesor("1", txt_profesor.Text.ToString().Trim());
                gv_profesores.DataSource = dsProfesores.Tables[0];
                gv_profesores.DataBind();

                if (gv_profesores.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró al profesor";
                else
                    lbl_mensaje.Text = "";
            }
            else
            {
                DataSet dsProfesores = negprof.listarProfesor("0", txt_profesor.Text.ToString().Trim());
                gv_profesores.DataSource = dsProfesores.Tables[0];
                gv_profesores.DataBind();

                if (gv_profesores.Rows.Count == 0)
                    lbl_mensaje.Text = "No se encontró al profesor";
                else
                    lbl_mensaje.Text = "";
            }
        }
    }
}