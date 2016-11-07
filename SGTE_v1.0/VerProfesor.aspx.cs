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

namespace SGTE_v1._0
{
    public partial class VerProfesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divXd.Visible = false;
                divEquisdeConOkeyno.Visible = false;
                listarProvincias(15);
                listarDistritos(127);
                caracteristicasGmap();

                if (Request.Params["c"] != null)
                {
                    Session["c"] = int.Parse(Request.Params["c"]);
                    cargarDatos();
                }
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
                    prof.codPersona = int.Parse(Request.Params["c"]);
                    prof.numDocumento = txtNumDoc.Text;
                    prof.nombres = txtNombres.Text.Trim();
                    prof.apPaterno = txtApPAt.Text.Trim();
                    prof.apMaterno = txtApMat.Text.Trim();
                    if (string.IsNullOrEmpty(txtTelf.Text))
                        prof.telefono = null;
                    else
                        prof.telefono = txtTelf.Text.Trim();
                    prof.email = txtEmail.Text.Trim();
                    prof.direccion = txtDireccion.Text.Trim();
                    prof.sexo = Convert.ToChar(ddlSexo.SelectedValue);
                    prof.fechaNacimiento = Convert.ToDateTime(txt_fecha.Text);
                    if (string.IsNullOrEmpty(lblcodUsuario.Text))
                        prof.codUsuario = null;
                    else
                        prof.codUsuario = Convert.ToInt32(lblcodUsuario.Text);
                    prof.codDistrito = Convert.ToInt32(ddlDistrito.SelectedValue);
                    prof.urlFoto = lbl_mensaje_1.Text;
                    if (string.IsNullOrEmpty(txtContrato.Text.Trim()))
                        prof.fechaContrato = null;
                    else
                        prof.fechaContrato = Convert.ToDateTime(txtContrato.Text);
                    if (string.IsNullOrEmpty(txtDuracion.Text.Trim()))
                        prof.duracionContrato = null;
                    else
                        prof.duracionContrato = Convert.ToInt32(txtDuracion.Text.Trim());

                    prof.tipoTrabajador = "PROFESOR";
                    if (string.IsNullOrEmpty(lblLat.Text))
                        prof.latitud = null;
                    else
                        prof.latitud = Convert.ToDouble(lblLat.Text);
                    if (string.IsNullOrEmpty(lblLng.Text))
                        prof.longitud = null;
                    else
                        prof.longitud = Convert.ToDouble(lblLng.Text);
                    prof.diasDisponible = null;
                    prof.urlCV = lbl_mensaje_3.Text;
                    prof.estadoProfesor = ddlEstado.SelectedValue.ToString();

                    if (prof.estadoProfesor == "ACTIVO")
                        prof.diasDisponible = lblDisponible.Text;

                    if (prof.estadoProfesor == "CAPACITADO" || prof.estadoProfesor == "ACTIVO" || prof.estadoProfesor == "INACTIVO")
                        prof.estadoTrabajador = "1";
                    else
                        prof.estadoTrabajador = "0";

                    DtoUsuario usu = new DtoUsuario();
                    CtrUsuario ctrubsu = new CtrUsuario();
                    if (prof.estadoProfesor == "ACTIVO" && string.IsNullOrEmpty(lblcodUsuario.Text))
                    {
                        usu.usuario = txtUsuario.Text.Trim();
                        usu.clave = txtContraseña.Text.Trim();
                        usu.estado = "1";
                        usu.codPerfil = 5;

                        ctrubsu.registrarUsuario(usu);
                        prof.codUsuario = ctrubsu.consultarUltimoUsuario();
                    }
                    else if (prof.estadoProfesor == "ACTIVO" && !string.IsNullOrEmpty(lblcodUsuario.Text))
                    {
                        usu.codUsuario = Convert.ToInt32(lblcodUsuario.Text);
                        ctrubsu.habilitarUsuario(usu);
                    }
                    else if (!string.IsNullOrEmpty(lblcodUsuario.Text))
                    {
                        usu.codUsuario = Convert.ToInt32(lblcodUsuario.Text);
                        ctrubsu.inhabilitarUsuario(usu);
                    }

                    CtrProfesor ctrprof = new CtrProfesor();
                    ctrprof.modificarProfesor(prof);

                    lbl_mensaje.Text = "Se modificó exitósamente el profesor: " + prof.nombres + " " + prof.apPaterno + " " + prof.apMaterno;
                }
            }
            catch { lbl_mensaje.Text = "Error al intentar modificar el profesor"; }
        }

        public void cargarDatos()
        {
            CtrProfesor ctrprof = new CtrProfesor();
            CtrTrabajador ctrtrab = new CtrTrabajador();
            CtrPersona ctrpers = new CtrPersona();
            DtoProfesor prof = new DtoProfesor();
            CtrUbigeo ctrubig = new CtrUbigeo();
            prof.codPersona = int.Parse(Session["c"].ToString());

            ctrpers.consultarPersona(prof);
            ctrtrab.consultarTrabajador(prof);
            ctrprof.consultarProfesor(prof);

            txtNombres.Text = prof.nombres;
            txtApPAt.Text = prof.apPaterno;
            txtApMat.Text = prof.apMaterno;
            txtNumDoc.Text = prof.numDocumento;
            txtTelf.Text = prof.telefono;
            txtEmail.Text = prof.email;
            txtDireccion.Text = prof.direccion;
            ddlSexo.SelectedValue = prof.sexo.ToString().Trim();
            txt_fecha.Text = prof.fechaNacimiento.ToShortDateString();
            lblcodUsuario.Text = prof.codUsuario.ToString();
            lbl_mensaje_1.Text = prof.urlFoto;
            if (prof.fechaContrato != null)
                txtContrato.Text = prof.fechaContrato.ToString().Substring(0, 10);
            txtDuracion.Text = prof.duracionContrato.ToString();
            if (prof.latitud != null && prof.longitud != null)
            {
                lblLat.Text = prof.latitud.ToString();
                lblLng.Text = prof.longitud.ToString();

                mostrarDireccion(prof.latitud.ToString(), prof.longitud.ToString());
            }
            if (prof.estadoProfesor == "ACTIVO")
            {
                divEquisdeConOkeyno.Visible = true;
                listarTalleresxProfesor(int.Parse(Session["c"].ToString()));
            }

            string cadDisponibilidad = prof.diasDisponible;
            if (cadDisponibilidad.Contains("L")) cblDiasDisponible.Items[0].Selected = true;
            if (cadDisponibilidad.Contains("M")) cblDiasDisponible.Items[1].Selected = true;
            if (cadDisponibilidad.Contains("X")) cblDiasDisponible.Items[2].Selected = true;
            if (cadDisponibilidad.Contains("J")) cblDiasDisponible.Items[3].Selected = true;
            if (cadDisponibilidad.Contains("V")) cblDiasDisponible.Items[4].Selected = true;
            if (cadDisponibilidad.Contains("S")) cblDiasDisponible.Items[5].Selected = true;

            img_foto.ImageUrl = lbl_mensaje_1.Text;
            lbl_mensaje_3.Text = prof.urlCV;
            ddlEstado.SelectedValue = prof.estadoProfesor;

            if (prof.estadoProfesor == "ACTIVO" && string.IsNullOrEmpty(lblcodUsuario.Text))
                divXd.Visible = true;

            int provincia = ctrubig.getProvincia(prof.codDistrito);
            ddlProvincia.SelectedValue = provincia.ToString();
            listarDistritos(provincia);
            ddlDistrito.SelectedValue = prof.codDistrito.ToString();
        }

        public void listarTalleresxProfesor(int codPersona)
        {
            CtrProfesor ctrpro = new CtrProfesor();
            DataSet dsProf = ctrpro.listarTallerxProfesor(codPersona);
            gv_profesores.DataSource = dsProf.Tables[0];
            gv_profesores.DataBind();

            if (gv_profesores.Rows.Count == 0)
                lbl_mensaje_5.Text = "Este profesor no tiene talleres activos";
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
            if (string.IsNullOrEmpty(txtTelf.Text)) { lbl_mensaje.Text = "Ingrese el número teléfono"; return false; }
            if (txtTelf.Text.Trim().Length < 7) { lbl_mensaje.Text = "Ingrese un número teléfono válido"; return false; }

            if (ddlSexo.SelectedValue == "0") { lbl_mensaje.Text = "Seleccione un género"; return false; }
            if (string.IsNullOrEmpty(txt_fecha.Text)) { lbl_mensaje.Text = "Ingrese la fecha de nacimiento"; return false; }
            DateTime fecha = DateTime.Now;
            try { fecha = Convert.ToDateTime(txt_fecha.Text); }
            catch { ver = false; }
            if (!ver) { lbl_mensaje.Text = "Ingrese correctamente la fecha de nacimiento"; return false; }
            if (fecha.Year < DateTime.Now.Year - 60 || fecha.Year > DateTime.Now.Year - 21) { lbl_mensaje.Text = "El profesor debe tener de 21 a 60 años de edad"; return false; }

            if (string.IsNullOrEmpty(txtDireccion.Text)) { lbl_mensaje.Text = "Ingrese la dirección"; return false; }
            if (string.IsNullOrEmpty(txtEmail.Text)) { lbl_mensaje.Text = "Ingrese el correo electrónico"; return false; }
            if (!IsValidEmail(txtEmail.Text)) { lbl_mensaje.Text = "No ha ingresado un correo electrónico correcto"; return false; }

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

            if (ddlEstado.SelectedValue == "ACTIVO")
            {
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
            }

            if (string.IsNullOrEmpty(lbl_mensaje_1.Text)) { lbl_mensaje.Text = "Suba una foto para el perfil"; return false; }
            if (string.IsNullOrEmpty(lblLat.Text)) { lbl_mensaje.Text = "Consulte y verifique su dirección en el mapa"; return false; }
            if (string.IsNullOrEmpty(lblLng.Text)) { lbl_mensaje.Text = "Consulte y verifique su dirección en el mapa"; return false; }

            if (ddlEstado.SelectedValue == "ACTIVO" && string.IsNullOrEmpty(lblcodUsuario.Text))
            {
                if (string.IsNullOrEmpty(txtUsuario.Text)) { lbl_mensaje.Text = "Ingrese un usuario"; return false; }
                if (txtUsuario.Text.Trim().Length < 8) { lbl_mensaje.Text = "Ingrese un usuario con más de 8 caracteres"; return false; }
                if (string.IsNullOrEmpty(txtContraseña.Text)) { lbl_mensaje.Text = "Ingrese una contraseña"; return false; }
                if (txtContraseña.Text.Trim().Length < 8) { lbl_mensaje.Text = "Ingrese una contraseña con más de 8 caracteres"; return false; }
                if (string.IsNullOrEmpty(txtContraseña1.Text)) { lbl_mensaje.Text = "Ingrese nuevamente la contraseña"; return false; }
                if (txtContraseña.Text.Trim() != txtContraseña1.Text.Trim()) { lbl_mensaje.Text = "Las contraseñas no coinciden"; return false; }
            }

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

        #region Gmaps
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

        #region SubidaDeArchivos
        protected void btnSubirCV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lbl_mensaje_3.Text))
                lbl_mensaje.Text = "El CV no está almacenado";
            else
            {
                //Word.Application objWord = (Word.Application)Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
                //object missing = System.Reflection.Missing.Value;


                //object abrirDoc = lbl_mensaje_3.Text;
                //object readOnly = true;
                //object isVisible = true;

                //objWord.Documents.Open(ref abrirDoc, ref missing, ref readOnly, ref missing, ref missing, ref missing,
                //ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                lbl_mensaje.Text = "En construcción...";
            }
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

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedValue == "ACTIVO" && string.IsNullOrEmpty(lblcodUsuario.Text))
                divXd.Visible = true;
            else
                divXd.Visible = false;
            if (ddlEstado.SelectedValue == "ACTIVO")
            {
                divEquisdeConOkeyno.Visible = true;
                listarTalleresxProfesor(int.Parse(Request.Params["c"]));
            }
            else
            {
                divEquisdeConOkeyno.Visible = false;
                lbl_mensaje_5.Text = "";
            }  
        }

        protected void gv_profesores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_profesores.PageIndex = e.NewPageIndex;
            listarTalleresxProfesor(int.Parse(Request.Params["c"]));
        }

        
    }
}