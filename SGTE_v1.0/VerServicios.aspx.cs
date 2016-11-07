using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net;
using System.Xml;
using System.IO;
using System.Xml.XPath;
using System.Globalization;
using Image = System.Drawing.Image;
using System.Configuration;
using System.Text;
using Subgurim.Controles;
using System.Drawing;
using DTO;
using CTR;
using Word = Microsoft.Office.Interop.Word.Document;
using System.Diagnostics;
using System.Data;
using System.Collections;

namespace SGTE_v1._0
{
    public partial class VerServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Params["c"] != null)
                {

                    Session["c"] = int.Parse(Request.Params["c"]);
                    cargarDatos();
                }
                
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarServicio.aspx");
        }


        //ArrayList lista = new ArrayList();
        //public void CargarEstado()
        //{
        //    lista.Add("HABILITADO");
        //    lista.Add("DESHABILITADO");
        //    this.ddlEstado.DataSource = lista;
        //    DataBind();
        //}




        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                if (validarDatos())
                {
                    DtoServicio prof = new DtoServicio();
                    CtrServicio ctrprof = new CtrServicio();

                    prof.codServicio = int.Parse(Request.Params["c"]);
                    prof.nombre = txtNombre.Text.Trim();
                    prof.descripcion = txtDescripcion.Text.Trim();
                    if (ddlEstado.SelectedValue.ToString() == "1")
                    {

                        prof.estado = 1;

                    }
                    else
                    {
                        prof.estado = 0;
                    }

                    ctrprof.modificarServicio(prof);

                    lbl_mensaje.Text = "Se modificó exitósamente el servicio: " + prof.nombre; 
                }
                                   
            }
            catch { lbl_mensaje.Text = "Error al intentar modificar el servicio"; }
        }


        private bool validarDatos()
        {
         

            if (string.IsNullOrEmpty(txtNombre.Text)) { lbl_mensaje.Text = "Ingrese el nombre"; return false; }
            if (string.IsNullOrEmpty(txtDescripcion.Text)) { lbl_mensaje.Text = "Ingrese la descripcion"; return false; }
                  
            return true;
        }




        public void cargarDatos()
        {
            CtrServicio ctrser = new CtrServicio();
            DtoServicio serv = new DtoServicio();
            serv.codServicio = int.Parse(Session["c"].ToString());

            ctrser.consultarServicio(serv);

            txtNombre.Text = serv.nombre;
            txtDescripcion.Text = serv.descripcion;
        }




        
     
    }
}