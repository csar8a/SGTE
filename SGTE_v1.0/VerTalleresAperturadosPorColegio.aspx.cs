using CTR;
using DTO;
using Subgurim.Controles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Data;

namespace SGTE_v1._0
{
    public partial class VerTalleresAperturadosPorColegio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                prueba.Text = Session["id_persona"].ToString();
                nivel.Visible = false;
                prueba.Visible = false;
                listarTalleresAperturados();
                
            }

        }

        protected void btnPedir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inscribete.aspx");
        }

        public DataTable evaluarNivel(DataSet dsTalleres)
        {
            CtrPersona obj = new CtrPersona();
            nivel.Text = obj.consultarAlumno(int.Parse(prueba.Text));

            DataTable dtaux = dsTalleres.Tables[0].Clone();
            foreach (DataTable thisTable in dsTalleres.Tables)
            {
                foreach (DataRow row in thisTable.Rows)
                {
                    if (row["nivel"].ToString().Contains(nivel.Text.ToString()))
                    {
                        dtaux.ImportRow(row);
                    }
                }
            }
            return dtaux;
        }

        public void listarTalleresAperturados()
        {
            CtrPersona negper = new CtrPersona();
            

            DataSet dsAux = negper.listarTalleres(int.Parse(prueba.Text));

            DataTable dsTalleres = evaluarNivel(dsAux);
            gv_talleresaperturados.DataSource = dsTalleres;
            gv_talleresaperturados.DataBind();

            if (gv_talleresaperturados.Rows.Count == 0)
                lblmensaje.Text = "No se encontró profesores";
            else
                lblmensaje.Text = "";
        }





        protected void gv_talleresaperturados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Inscribirse")
            {
                DtoTallerAperturado daot = new DtoTallerAperturado();
                CtrTallerAperturado obj = new CtrTallerAperturado();
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = gv_talleresaperturados.Rows[index];
                TableCell t = selectedRow.Cells[0];
                TableCell tall = selectedRow.Cells[1];
                try
                {
                    
                    daot.codPersona = int.Parse(prueba.Text);
                    daot.codTallerAperturado = int.Parse(t.Text);
                    obj.registrarAlumnoxTA(daot);
                    selectedRow.Enabled = false;
                    //mensajito :v
                    lblmensaje.Text = "INSCRIPCIÓN EXITOSA";
                    lblmensaje.ForeColor = Color.Blue;
                }
                catch
                {
                    
                    lblmensaje.Text = "Ya estas inscrito en el taller ["+tall.Text+"] , sorry :c";
                    lblmensaje.ForeColor = Color.Red;
                }
               
            }
        }
    }
}