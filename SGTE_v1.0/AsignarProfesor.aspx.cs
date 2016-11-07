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
    public partial class AsignarProfesor : System.Web.UI.Page
    {
        double maxDist=10;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCole.ReadOnly = true;
            txtNombTallerAperturado.ReadOnly = true;
            if (!IsPostBack)
            {
                btnAmpliarRango.Enabled = false;
                //Sesion del Cole y Taller Aperturado
                if (Session["r"] != null && Session["t"] != null)
                {
                    //Session["r"] = int.Parse(Session["r"].ToString());//Colegio
                    //Session["t"] = int.Parse(Session["t"].ToString());//Taller
                    cargarDatosColeyTallerA();
                    listarProfesores();

                }

            }            
        }

        #region GMAPS
        //Latitud y Longitud del colegio 
    
        private void caracteristicasGmap(string latitu, string longi)
        {
            //Centra y añade marcador al colegio (PREDETERMINADO)
            GLatLng latlng2 = new GLatLng(Convert.ToDouble(latitu), Convert.ToDouble(longi));
            gmap1.setCenter(latlng2, 15);
            GMarker m1 = new GMarker(new GLatLng(Convert.ToDouble(latitu), Convert.ToDouble(longi)));
            gmap1.Add(m1);
            configuracionMap();
            GCustomCursor customCursor = new GCustomCursor(cursor.crosshair, cursor.text);
            gmap1.Add(customCursor);
            gmap1.Add(new GMapUI());
            //Añade info 
            String html = "<center><b>" + ""+txtCole.Text.ToString() + "<center><b>";
            GInfoWindow window = new GInfoWindow(m1, html, true);
            gmap1.Add(window);
        }

        public void configuracionMap()
        {
            //Configuraciones del mapa
            gmap1.Add(new GControl(GControl.preBuilt.LargeMapControl));
            gmap1.enableDragging = true;
            gmap1.enableHookMouseWheelToZoom = true;
            gmap1.enableGKeyboardHandler = true;
            gmap1.Language = "es";
            gmap1.BackColor = Color.White;
        }

        #endregion
        public double distancia(double lat, double lng, double latitud, double longitud)
        {
            
            GLatLng latlng = new GLatLng(lat,lng); //profesor
            GLatLng latlng2 = new GLatLng(latitud, longitud); // colegio
            //Evalua la distancia entre el profesor y el colegio
            double distancia = latlng.distanceFrom(latlng2);
            double km = distancia / 10;

            return km;
        }


        public DataTable evaluarCercanos(DataSet dsProfesores, double km)
        {
            /*KM es el rango de distancias para el que debe buscar*/

            DataTable dtAux=dsProfesores.Tables[0].Clone();
            DtoColegio cole = new DtoColegio();
            CtrColegio ctrcol = new CtrColegio();
            cole.codColegio = int.Parse(Session["r"].ToString());
            
            ctrcol.consultarColegio(cole);
            txtCole.Text = cole.nombre;
            lblLat2.Text = cole.latitud.ToString();
            lblLng2.Text = cole.longitud.ToString();
            double lat, lng, aux=50;
            foreach(DataTable thisTable in dsProfesores.Tables)
            {
                foreach (DataRow row in thisTable.Rows) //Para cada fila evalua la distancia
                {
                    
                    lat = Double.Parse(row["latitud"].ToString());
                    lng = Double.Parse(row["longitud"].ToString());
                    double dist = distancia(lat, lng, Double.Parse(cole.latitud.ToString()), Double.Parse(cole.longitud.ToString()));

                    if (row["diasDisponible"].ToString().Contains(lbldia.Text))
                    {
                    if( dist < km)
                    {
                        
                            dtAux.ImportRow(row); //Si la distancia es menor al rango "km" entonces importa la fila a mi tabla auxiliar

                            //Pinta marcador del profesor
                            GLatLng latlng = new GLatLng(lat, lng);
                            GLatLng latlng2 = new GLatLng(Convert.ToDouble(cole.latitud.ToString()), Convert.ToDouble(cole.longitud.ToString()));

                            GIcon icon = new GIcon();
                            icon.labeledMarkerIconOptions = new LabeledMarkerIconOptions(Color.Gold, Color.White, "P", Color.Green);
                            GMarker ii = new GMarker(latlng, icon);
                            GInfoWindow window = new GInfoWindow(ii, "" + row["nombres"]);

                            //Pinta la linea entre profesor y colegio
                            List<GLatLng> puntos = new List<GLatLng>();
                            puntos.Add(latlng);
                            puntos.Add(latlng2);
                            GPolyline linea = new GPolyline(puntos, "FF0000", 2);
                            gmap1.Add(linea);
                            gmap1.Add(ii);
                            if (dist < aux)
                            {

                                //busca la mejor distancia
                                dista.Text = "La mejor distancia es del profesor " + row["nombres"] + " " + row["apPaterno"] + " con " + dist.ToString() + " km de distancia.";
                                aux = dist;
                                idProfe.Text = "" + row["codPersona"];
                            }
                            else
                            {

                            }
                         
                     }
                    if (dtAux.Rows.Count == 0)
                    {
                        btnAmpliarRango.Enabled = true;
                    }
                    }
                }
            }

            return dtAux;
        }


        public void listarProfesores()
        {
            CtrProfesor negprof = new CtrProfesor();
            lblmensaje.Text = "";
            DataSet dsAux = negprof.listarProfTrabajadoresActivos();
            //lista todos los profesores dentro del rango inicial 10km
            DataTable dsProfesores = evaluarCercanos(dsAux, maxDist);
            gv_profesores.DataSource = dsProfesores;
            gv_profesores.DataBind();

            if (gv_profesores.Rows.Count == 0)
                lblmensaje.Text = "No se encontró profesores";
            else
                lblmensaje.Text = "";
        }
        

        public void cargarDatosColeyTallerA()
        {
            DtoTallerAperturado tallape = new DtoTallerAperturado();
            CtrTallerAperturado ctrTallap = new CtrTallerAperturado();
            tallape.codTallerAperturado = int.Parse(Session["t"].ToString());

            ctrTallap.consultarTallerAperturado3(tallape);

            txtNombTallerAperturado.Text = ctrTallap.consultarTallerAperturado2(tallape);
            //-------------------
            DtoColegio cole = new DtoColegio();
            CtrColegio ctrcol = new CtrColegio();
            cole.codColegio = int.Parse(Session["r"].ToString());

            ctrcol.consultarColegio(cole);

            txtCole.Text = cole.nombre;
            lblLat2.Text = cole.latitud.ToString();
            lblLng2.Text = cole.longitud.ToString();
            idTallerAper.Text = tallape.codTallerAperturado.ToString();
            lbldia.Text = tallape.dia;
            lblalerta.Text = tallape.codProfesor.ToString();

            caracteristicasGmap(cole.latitud.ToString(), cole.longitud.ToString());

        }

        protected void gv_profesores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignar")
            {
                CtrTallerAperturado obj = new CtrTallerAperturado();
                obj.updateTallxProf(int.Parse(idTallerAper.Text), int.Parse(idProfe.Text));
                lblmensaje.Text = "Profesor fue asignado !";
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pruebita.aspx");
        }

        protected void btnAmpliarRango_Click(object sender, EventArgs e)
        {
            maxDist += 10;
        }
    }
}