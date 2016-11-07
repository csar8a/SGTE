using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGTE_v1._0
{
    public partial class PaginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string usuario = Session["id_user"].ToString();
                if (!IsPostBack)
                {
                    string perfil = Session["perfil_user"].ToString();
                    switch (perfil)
                    {
                        case "1":
                            perfil_JefeArea();
                            break;
                        case "2":
                            perfil_Cliente();
                            break;
                        case "3":
                            perfil_Alumno();
                            break;
                        case "4":
                            perfil_Vendedor();
                            break;
                        case "5":
                            perfil_Profesor();
                            break;
                        case "6":
                            perfil_CoordinadorEducativo();
                            break;
                        case "7":
                            perfil_Recepcionista();
                            break;
                        default:
                            Response.Redirect("Index.aspx");
                            break;
                    }

                    lbl_usuario.Text = Session["nombre_user"].ToString();
                }
            }
            catch { Response.Redirect("Index.aspx"); }
           
        }

        public void perfil_JefeArea()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                            <li class='active'>
                                <a href = 'AdministrarColegios.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Colegios</a>
                            </li>
                            <li>
                                <a href = 'ConsultarServiciosPendientes.aspx' ><i class='fa fa-fw fa-bar-edit'></i> Consultar Servicios Pendientes</a>
                            </li>
                            <li>
                                <a href = 'AdministrarServicios.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Servicios</a>
                            </li>
                        </ul>                       
                    </ div >     
                    ");
            this.Literal1.Text = html;
        }

        public void perfil_Cliente()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                            <li class='active'>
                                <a href = 'SolicitarServicios.aspx' ><i class='fa fa-fw fa-edit'></i> Solicitar Servicios</a>
                            </li>                    
                        </ul>
                    </ div >                    
                    ");
            this.Literal1.Text = html;
        }

        public void perfil_Alumno()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                            <li class='active'>
                                <a href = 'VerTalleresAperturadosPorColegio.aspx' ><i class='fa fa-fw fa-edit'></i> ¡Inscribete!</a>
                            </li>
                            <li>
                                <a href = 'EnviarReciboTaller.aspx' ><i class='fa fa-fw fa-bar-edit'></i> Enviar Comprobante de Pago</a>
                            </li>
                        </ul>
                    </ div >                    
                    ");
            this.Literal1.Text = html;
        }

        public void perfil_Vendedor()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                            <li class='active'>
                                <a href = 'AdministrarVenta.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Venta</a>
                            </li>
                            <li>
                                <a href = 'ConsultarCronograma.aspx' ><i class='fa fa-fw fa-bar-edit'></i> Cronograma de Presentaciones</a>
                            </li>
                        </ul>
                    </ div >                   
                    ");
            this.Literal1.Text = html;
        }

        public void perfil_Profesor()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                    <li class='active'>
                        <a href = '#' ><i class='fa fa-fw fa-edit'></i> En construccion...</a>
                    </li>
                </ul>
                       </ div >
                   
                    ");
            this.Literal1.Text = html;
        }

        public void perfil_CoordinadorEducativo()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                            <li class='active'>
                                <a href = 'AdministrarCursoTaller.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Cursos de Taller</a>
                            </li>
                            <li>
                                <a href = 'AdministrarProfesores.aspx' ><i class='fa fa-fw fa-bar-edit'></i> Administrar Profesores</a>
                            </li>
                            <li>
                                <a href = 'AdministrarPostulaciones.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Postulantes</a>
                            </li>
                            <li>
                                <a href = 'AdministrarServicio.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Servicios</a>
                            </li>
                            <li>
                                <a href = 'AdministrarTalleresAperturados.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Talleres Aperturados</a>
                            </li>
                        </ul>
                       </ div >
                   
                    ");
            this.Literal1.Text = html;
        }

        public void perfil_Recepcionista()
        {
            string html = string.Format(@"
                    <div class='collapse navbar-collapse navbar-ex1-collapse'>
                        <ul class='nav navbar-nav side-nav'>
                            <li class='active'>
                                <a href = 'AdministrarUsuarios.aspx' ><i class='fa fa-fw fa-edit'></i> Administrar Usuarios</a>
                            </li>
                            <li>
                                <a href = 'AdministrarPreguntasFrecuentes.aspx' ><i class='fa fa-fw fa-bar-edit'></i> Administrar Preguntas Frecuentes</a>
                            </li>
                            <li>
                                <a href = 'ConfirmarPago.aspx' ><i class='fa fa-fw fa-edit'></i> Confirmar Pagos</a>
                            </li>
                            <li>
                                <a href = 'VerificarEstadoTaller.aspx' ><i class='fa fa-fw fa-edit'></i> Verificar Estado de Talleres</a>
                            </li>
                        </ul>
                    </ div >                    
                    ");
            this.Literal1.Text = html;
        }
    }
}