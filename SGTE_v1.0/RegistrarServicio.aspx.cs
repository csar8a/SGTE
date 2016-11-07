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
using Image = System.Drawing.Image;

namespace SGTE_v1._0
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiar();
            }
        }


        public void limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
       }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                if (validarDatos())
                {
                    DtoServicio ser= new DtoServicio();

                    ser.nombre = txtNombre.Text.Trim();
                    ser.descripcion = txtDescripcion.Text.Trim();
                    //ser.estado =1;
                    

                    CtrServicio ctrser = new CtrServicio();
                    ctrser.registrarServicio(ser);

                    lbl_mensaje.Text = "Se registró exitósamente el servicio : " + ser.nombre;
                    limpiar();
                }
            }
            catch {lbl_mensaje.Text = "Error al intentar registrar el servicio"; }

        }

        private bool validarDatos()
        {
            bool ver=true ;

            if (string.IsNullOrEmpty(txtNombre.Text)) { lbl_mensaje.Text = "Ingrese el nombre"; return false; }
            if (string.IsNullOrEmpty(txtDescripcion.Text)) { lbl_mensaje.Text = "Ingrese la descripcion "; return false; }
           
   
            return ver;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarServicio.aspx");
        }

    }
}