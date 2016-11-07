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
    public partial class VerCursoTaller : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarCursoTaller.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
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
            dtoTal.rango = rangoTaller;
            dtoTal.totalHoras = Convert.ToInt32(txtHoras.Text);
            dtoTal.descripcion = txtDescripcion.Text;
            dtoTal.urlSilabo = lbl_mensaje_3.Text;

            CtrTaller ctrTal = new CtrTaller();
            ctrTal.actualizarTaller(dtoTal);
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
        public void cargarDatos()
        {
            CtrTaller ctrTal = new CtrTaller();
            DtoTaller dtoTal = new DtoTaller();
            dtoTal.codTaller = int.Parse(Request["c"]);

            ctrTal.consultarTaller(dtoTal);

            txtNombTaller.Text = dtoTal.nombre;
            lbNivel.SelectedValue = dtoTal.nivel;
            string rangoTaller = dtoTal.rango;
            for (int i = 0; i < rangoTaller.Length; i++)
            {
                if (rangoTaller[i] != '-') 
                {
                    cbSecciones.SelectedValue = rangoTaller[i]+"";
                }
            }
            txtHoras.Text = dtoTal.totalHoras + "";
            txtDescripcion.Text = dtoTal.descripcion;
            lbl_mensaje_3.Text = dtoTal.urlSilabo;
        }

        protected void lbNivel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNivel.Items[1].Selected)
            {
                cbSecciones.Items[5].Enabled = false;
            }
        }
    }
}