using CTR;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGTE_v1._0
{
    public partial class RegistrarCursoTaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarCursoTaller.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    DtoTaller dtoTal = new DtoTaller();
                    dtoTal.nombre = txtNombTaller.Text;
                    dtoTal.nivel = lbNivel.SelectedItem.Text;
                    string rangoTaller = "";
                    for (int i = 0; i < cbSecciones.Items.Count; i++)
                    {
                        if (cbSecciones.Items[i].Selected)
                        {
                            rangoTaller += cbSecciones.Items[i].Value + "-";
                        }
                    }
                    if (rangoTaller.Equals(null))
                    {
                        lbl_mensaje_4.Text = "Seleccione al menos una sección para el taller.";

                    }
                    dtoTal.rango = rangoTaller;
                    dtoTal.totalHoras = Convert.ToInt32(txtHoras.Text);
                    dtoTal.descripcion = txtDescripcion.Text;
                    dtoTal.urlSilabo = lbl_mensaje_3.Text;
                    //falta "Las clases incluyen"
                    CtrTaller ctrTal = new CtrTaller();
                    ctrTal.registrarTaller(dtoTal);
                    //confirmar registro correcto
                    lbl_mensaje_4.Text = "Registrado correctamente.";

                    limpiar();
                }
            }
            catch { lbl_mensaje_4.Text = "Error al intentar registrar el taller."; }
        }

        protected bool validarDatos()
        {
            bool ver = true;
            if (string.IsNullOrEmpty(txtNombTaller.Text)) { lbl_mensaje_4.Text = "Ingrese el nombre del taller"; return false; }
            if (string.IsNullOrEmpty(txtHoras.Text)) { lbl_mensaje_4.Text = "Ingrese el numero de horas"; return false; }
            if (string.IsNullOrEmpty(txtDescripcion.Text)) { lbl_mensaje_4.Text = "Ingrese una descripción de taller"; return false; }
            int horas=0;
            try { horas = int.Parse(txtHoras.Text); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje_4.Text = "Ingrese la cantidad en formato numérico"; return false; }
            
            return true;
        }

        protected void limpiar() 
        {
            txtNombTaller.Text = "";
            lbNivel.SelectedIndex = 0;
            cbSecciones.ClearSelection();
            txtHoras.Text = "";
            txtDescripcion.Text = "";
        }

        protected void btnSubirCV_Click(object sender, EventArgs e)
        {
            lbl_mensaje_3.Text = "";
            lbl_mensaje_4.Text = "";
            bool _OK = false;
            string path = Server.MapPath("~/doc/");
            if (fuSubirCV.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(fuSubirCV.FileName).ToLower();
                string[] extensiones = { ".doc", ".docx" };
                for (int i = 0; i < extensiones.Length; i++)
                {
                    if (fileExtension == extensiones[i])
                    {
                        _OK = true;
                    }
                }
            }

            if (_OK)
            {
                try
                {
                    fuSubirCV.PostedFile.SaveAs(path + fuSubirCV.FileName);
                    string nombre = fuSubirCV.FileName;
                    string ruta = "~/doc/" + nombre;

                    lbl_mensaje_3.Text = ruta;

                    lbl_mensaje_4.ForeColor = System.Drawing.Color.Blue;
                    lbl_mensaje_4.Text = nombre + " almacenado correctamente";
                }
                catch (Exception ex)
                {
                    lbl_mensaje_4.Text = "Error al guardar el Silabo";
                }
            }
            else
                lbl_mensaje_4.Text = "No se ha subido un archivo word";
        }

        protected void lbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNivel.Items[1].Selected)
            {
                cbSecciones.Items[5].Enabled= false;
            }
        }
    }
}