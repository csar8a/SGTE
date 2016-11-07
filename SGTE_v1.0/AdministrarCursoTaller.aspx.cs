using CTR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGTE_v1._0
{
    public partial class AdministrarCursoTaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CtrTaller talleres = new CtrTaller();
            lbl_mensaje.Text = "";
            DataSet dsProfesores = talleres.listarTalleres();
            gvCursoTaller.DataSource = dsProfesores.Tables[0];
            gvCursoTaller.DataBind();

            if (gvCursoTaller.Rows.Count == 0)
                lbl_mensaje.Text = "No se encontraron registros disponibles";
            else
                lbl_mensaje.Text = "";
            GridViewRow thisRow;
            for (int i = 0; i < gvCursoTaller.Rows.Count; i++)
            {
                thisRow = gvCursoTaller.Rows[i];
                TableCell tc = thisRow.Cells[3];
                desempaquetar(tc, thisRow.Cells[3], new TableCell());
            }

        }

        private void desempaquetar(TableCell t1, TableCell t2, TableCell aux)
        {
            for (int i = 0; i < t1.Text.Length; i++)
            {
                if (t1.Text[i] != '-')
                {
                    aux.Text += t1.Text[i];
                }
                if (i == t1.Text.Length - 2)
                {
                    break;
                }
                else
                {
                    aux.Text += "°, ";
                }
            }
            t2.Text = aux.Text;
        }

        protected void btnNuevoTaller_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarCursoTaller.aspx");
        }

        protected void gvCursoTaller_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gvCursoTaller.Rows[index];
                TableCell tbcId = selectedRow.Cells[0];

                Response.Redirect("VerCursoTaller.aspx?c=" + tbcId.Text);
            }
        }
    }
}                