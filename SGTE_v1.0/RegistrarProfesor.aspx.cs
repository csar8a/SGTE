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
    public partial class RegistrarProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                limpiar();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministrarProfesores.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_mensaje.Text = "";
                if (validarDatos())
                {
                    DtoProfesor prof = new DtoProfesor();
                    prof.numDocumento = txtNumDoc.Text;
                    prof.nombres = txtNombres.Text.Trim();
                    prof.apPaterno = txtApPAt.Text.Trim();
                    prof.apMaterno = txtApMat.Text.Trim();
                    prof.telefono = txtTelf.Text.Trim();
                    prof.email = txtEmail.Text.Trim();
                    prof.direccion = txtDireccion.Text.Trim();
                    prof.sexo = Convert.ToChar(ddlSexo.SelectedValue);
                    prof.fechaNacimiento = Convert.ToDateTime(txt_fecha.Text);
                    prof.codUsuario = null;
                    prof.codDistrito = Convert.ToInt32(ddlDistrito.SelectedValue);
                    prof.urlFoto = lbl_mensaje_1.Text;
                    prof.fechaContrato = Convert.ToDateTime(txtContrato.Text);
                    prof.duracionContrato = Convert.ToInt32(txtDuracion.Text.Trim());
                    prof.tipoTrabajador = "PROFESOR";
                    prof.estadoTrabajador = "1";
                    prof.latitud = Convert.ToDouble(lblLat.Text);
                    prof.longitud = Convert.ToDouble(lblLng.Text);
                    prof.diasDisponible = lblDisponible.Text;
                    if (string.IsNullOrEmpty(lbl_mensaje_3.Text))
                        prof.urlCV = null;
                    else
                        prof.urlCV = lbl_mensaje_3.Text;
                    prof.estadoProfesor = "CAPACITADO";

                    CtrProfesor ctrprof = new CtrProfesor();
                    ctrprof.registrarProfesor(prof);

                    lbl_mensaje.Text = "Se registró exitósamente el profesor: " + prof.nombres + " " + prof.apPaterno + " " + prof.apMaterno;
                    limpiar();
                }
            }
            catch { lbl_mensaje.Text = "Error al intentar registrar el profesor"; }

        }

        public void limpiar()
        {
            txtNombres.Text = "";
            txtApPAt.Text = "";
            txtApMat.Text = "";
            txtNumDoc.Text = "";
            txtTelf.Text = "";
            txtDireccion.Text = "";
            ddlSexo.SelectedValue = "0";
            txt_fecha.Text = "";
            txtEmail.Text = "";
            txtContrato.Text = "";
            txtDuracion.Text = "";
            for (int i = 0; i < cblDiasDisponible.Items.Count - 1; i++)
            {
                cblDiasDisponible.Items[i].Selected = false;
            }
            lbl_mensaje_3.Text = "";
            lbl_mensaje_1.Text = "";
            lblLat.Text = "";
            lblLng.Text = "";

            listarProvincias(15);
            listarDistritos(127);
            caracteristicasGmap();
        }

        #region validaciones

        private bool validarDatos()
        {
            bool ver = true;

            if (string.IsNullOrEmpty(txtNombres.Text)) { lbl_mensaje.Text = "Ingrese el nombre"; return false; }
            if (string.IsNullOrEmpty(txtApPAt.Text)) { lbl_mensaje.Text = "Ingrese el apellido paterno"; return false; }
            if (string.IsNullOrEmpty(txtApMat.Text)) { lbl_mensaje.Text = "Ingrese el apellido materno"; return false; }
            if (string.IsNullOrEmpty(txtNumDoc.Text)) { lbl_mensaje.Text = "Ingrese el número de documento"; return false; }
            if (txtNumDoc.Text.Trim().Length != 8) { lbl_mensaje.Text = "El número de documento debe contener 8 dígitos"; return false; }
            int numdoc = 0;
            try { numdoc = int.Parse(txtNumDoc.Text); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje.Text = "Ingrese correctamente el número de documento"; return false; }
            if (numdoc <= 0) { lbl_mensaje.Text = "Ingrese correctamente el número de documento"; return false; }
            CtrProfesor ctrprof = new CtrProfesor();

            ver = !ctrprof.consultarNumDocxPersona(numdoc.ToString());
            if (!ver) { lbl_mensaje.Text = "El número de documento ingresado ya está en uso"; return false; }

            if (ddlSexo.SelectedValue == "0") { lbl_mensaje.Text = "Seleccione un género"; return false; }
            if (string.IsNullOrEmpty(txt_fecha.Text)) { lbl_mensaje.Text = "Ingrese la fecha de nacimiento"; return false; }
            DateTime fecha = DateTime.Now;
            try { fecha = Convert.ToDateTime(txt_fecha.Text); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje.Text = "Ingrese correctamente la fecha de nacimiento"; return false; }
            if (fecha.Year < DateTime.Now.Year - 60 || fecha.Year > DateTime.Now.Year - 21) { lbl_mensaje.Text = "El profesor debe tener de 21 a 60 años de edad"; return false; }

            if (string.IsNullOrEmpty(txtDireccion.Text)) { lbl_mensaje.Text = "Ingrese la dirección"; return false; }
            if (string.IsNullOrEmpty(txtTelf.Text)) { lbl_mensaje.Text = "Ingrese el número teléfono"; return false; }
            if (txtTelf.Text.Trim().Length < 7) { lbl_mensaje.Text = "Ingrese un número teléfono"; return false; }
            int tel = 0;
            try { tel = int.Parse(txtTelf.Text); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje.Text = "Ingrese correctamente el número de teléfono"; return false; }
            if (tel <= 0) { lbl_mensaje.Text = "Ingrese correctamente el número de teléfono"; return false; }

            if (string.IsNullOrEmpty(txtEmail.Text)) { lbl_mensaje.Text = "Ingrese el correo electrónico"; return false; }
            if (!IsValidEmail(txtEmail.Text)) { lbl_mensaje.Text = "No ha ingresado un correo electrónico correcto"; return false; }
            ver = !ctrprof.consultarEmailxPersona(txtEmail.Text.Trim());
            
            if (!ver) { lbl_mensaje.Text = "El correo electrónico ingresado ya está en uso"; return false; }

            if (string.IsNullOrEmpty(txtContrato.Text)) { lbl_mensaje.Text = "Ingrese la fecha de contrato"; return false; }
            DateTime contrato = DateTime.Now;
            try { contrato = Convert.ToDateTime(txtContrato.Text); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje.Text = "Ingrese correctamente la fecha de contrato"; return false; }
            if (contrato > DateTime.Now || contrato.Year < 2016) { lbl_mensaje.Text = "La fecha de contrato es inválida"; return false; }
            if (string.IsNullOrEmpty(txtDuracion.Text)) { lbl_mensaje.Text = "Ingrese la duración del contrato"; return false; }
            int duracion = 0;
            try { duracion = int.Parse(txtDuracion.Text.Trim()); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje.Text = "Ingrese correctamente el número de meses del contrato"; return false; }
            if (duracion < 6 || duracion > 60) { lbl_mensaje.Text = "Ingrese una duración entre 6 a 60 meses"; return false; }

            lblDisponible.Text = "";
            bool primero = true;
            for (int i = 0; i < cblDiasDisponible.Items.Count; i++)
            {
                if (cblDiasDisponible.Items[i].Selected)
                {
                    if (!primero)
                        lblDisponible.Text = lblDisponible.Text + "-";
                    lblDisponible.Text = lblDisponible.Text + cblDiasDisponible.Items[i].Value;
                    if (primero)
                        primero = false;
                }
            }
            if (string.IsNullOrEmpty(lblDisponible.Text)) { lbl_mensaje.Text = "Marque los dias disponibles"; return false; }
            if (string.IsNullOrEmpty(lbl_mensaje_1.Text)) { lbl_mensaje.Text = "Suba una foto para el perfil"; return false; }
            if (string.IsNullOrEmpty(lblLat.Text)) { lbl_mensaje.Text = "Consulte y verifique su dirección en el mapa"; return false; }
            if (string.IsNullOrEmpty(lblLng.Text)) { lbl_mensaje.Text = "Consulte y verifique su dirección en el mapa"; return false; }

            return true;
        }

        bool invalid;
        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        #endregion

        #region GMAPS


        protected void bt_Buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_Buscar.Text))
            {
                lblLat.Text = "";
                lblLng.Text = "";
                lb_Buscar.Text = "";

                string key = ConfigurationManager.AppSettings.Get("googlemaps.subgurim.net");

                GeoCode geocode = GMap.geoCodeRequest(tb_Buscar.Text, key, new GLatLngBounds(new GLatLng(40, 10), new GLatLng(50, 20)));

                GMap gMap1 = new GMap();
                gMap1.getGeoCodeRequest(tb_Buscar.Text, new GLatLngBounds(new GLatLng(40, 10), new GLatLng(50, 20)));


                if ((null != geocode) && geocode.valid)
                {
                    lblLat.Text = geocode.Placemark.coordinates.lat.ToString();
                    lblLng.Text = geocode.Placemark.coordinates.lng.ToString();
                    lb_Buscar.Text = "Dirección encontrada";
                    mostrarDireccion(lblLat.Text.Trim(), lblLng.Text.Trim());
                }
                else
                {
                    lb_Buscar.Text = "No se encontró la dirección";
                }
            }
        }

        public void mostrarDireccion(string lat, string lng)
        {
            gmap1.resetMarkers();
            gmap1.setCenter(new GLatLng(Convert.ToDouble(lat), Convert.ToDouble(lng)), 17);
            GLatLng latlng = new GLatLng(Convert.ToDouble(lat), Convert.ToDouble(lng));
            GMarker ii = new GMarker(latlng);
            gmap1.Add(ii);
        }

        private void caracteristicasGmap()
        {
            gmap1.enableDragging = true;
            gmap1.enableHookMouseWheelToZoom = true;
            gmap1.enableGKeyboardHandler = true;
            gmap1.Language = "es";
            gmap1.BackColor = Color.White;
            gmap1.setCenter(new GLatLng(-12.1416088, -76.99181550000003), 14);

            GCustomCursor customCursor = new GCustomCursor(cursor.crosshair, cursor.text);
            gmap1.Add(customCursor);
            gmap1.Add(new GMapUI());


            gmap1.Add(new GControl(GControl.extraBuilt.TextualOnClickCoordinatesControl, new GControlPosition(GControlPosition.position.Bottom_Left)));
        }

        #endregion

        #region UBIGEO

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarDistritos(int.Parse(ddlProvincia.SelectedValue));
        }

        public void listarProvincias(int codDepartamento)
        {
            CtrUbigeo negubigeo = new CtrUbigeo();
            ddlProvincia.DataSource = negubigeo.getProvincias(codDepartamento);
            ddlProvincia.DataValueField = "codProvincia";
            ddlProvincia.DataTextField = "nombre";
            ddlProvincia.DataBind();
        }
        public void listarDistritos(int codProvincia)
        {
            CtrUbigeo negubigeo = new CtrUbigeo();
            ddlDistrito.DataSource = negubigeo.getDistrito(codProvincia);
            ddlDistrito.DataValueField = "codDistrito";
            ddlDistrito.DataTextField = "nombre";
            ddlDistrito.DataBind();
        }



        #endregion

        #region SubidaDeArchivos

        protected void btnSubirCV_Click(object sender, EventArgs e)
        {
            lbl_mensaje_3.Text = "";
            lbl_mensaje_4.Text = "";
            bool _OK = false;
            string path = Server.MapPath("~/doc/");
            if (fuSubirCV.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(fuSubirCV.FileName).ToLower();
                string[] extenciones = { ".doc", ".docx" };
                for (int i = 0; i < extenciones.Length; i++)
                {
                    if (fileExtension == extenciones[i])
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

                    lbl_mensaje_4.ForeColor = Color.Blue;
                    lbl_mensaje_4.Text = nombre + " almacenado correctamente";
                }
                catch (Exception ex)
                {
                    lbl_mensaje_4.Text = "Error al guardar el CV";
                }
            }
            else
                lbl_mensaje_4.Text = "No se ha subido un archivo word";
        }

        protected void btnSubirFoto_Click(object sender, EventArgs e)
        {
            lbl_mensaje_1.Text = "";
            lbl_mensaje_2.Text = "";
            bool _OK = false;
            string path = Server.MapPath("~/img/fotos/");
            if (fu_examinar.HasFile)
            {
                string fileExtension = System.IO.Path.GetExtension(fu_examinar.FileName).ToLower();
                string[] extenciones = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < extenciones.Length; i++)
                {
                    if (fileExtension == extenciones[i])
                    {
                        _OK = true;
                    }
                }
            }

            if (_OK)
            {
                try
                {
                    fu_examinar.PostedFile.SaveAs(path + fu_examinar.FileName);
                    string nombre = fu_examinar.FileName;
                    string ruta = "~/img/fotos/" + nombre;

                    lbl_mensaje_1.Text = ruta;

                    img_foto.ImageUrl = ruta;
                    lbl_mensaje_2.ForeColor = Color.Blue;
                    lbl_mensaje_2.Text = "Imagen almacenada correctamente";
                }
                catch (Exception ex)
                {
                    lbl_mensaje_2.Text = "Error al guardar la imagen";
                }
            }
            else
                lbl_mensaje_2.Text = "No ha subido una imagen";
        }
        #endregion

    }
}