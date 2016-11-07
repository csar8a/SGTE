<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SGTE_v1._0.Index" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>MAKE3D</title>

    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="css/stylish-portfolio.css" rel="stylesheet" type="text/css" />

    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,700,300italic,400italic,700italic" rel="stylesheet" type="text/css" />


</head>

<body>
        <!-- Navigation -->
    <a id="menu-toggle" href="#" class="btn btn-dark btn-lg toggle"><i class="fa fa-bars"></i></a>
    <nav id="sidebar-wrapper">
        <ul class="sidebar-nav">
            <a id="menu-close" href="#" class="btn btn-light btn-lg pull-right toggle"><i class="fa fa-times"></i></a>
            <li class="sidebar-brand">
                <a href="#top" onclick=$("#menu-close").click();>Menú</a>
            </li>
            <li>
                <a href="#top" onclick=$("#menu-close").click();>Nosotros</a>
            </li>
            <li>
                <a href="#about" onclick=$("#menu-close").click();>Servicios</a>
            </li>
            <li>
                <a href="#services" onclick=$("#menu-close").click();>Services</a>
            </li>
            <li>
                <a href="#portfolio" onclick=$("#menu-close").click();>Proyectos</a>
            </li>
            <li>
                <a href="#contact" onclick=$("#menu-close").click();>Contactenos</a>
            </li>

        </ul>
    </nav>

    <!-- Header -->
    <header id="top" class="header">
        <div class="text-vertical-center">
            <a href="#about" class="btn btn-dark btn-lg">Averigua más</a>

        </div>
    </header>

    <aside class="call-to-action bg-primary">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <a href="#" class="btn btn-lg btn-light">Registrate</a>
                    <a href="#bootstrapmodal" class="btn btn-lg btn-dark" data-toggle="modal">Log In</a>
                </div>
            </div>
        </div>
    </aside>
    <!-- About -->
    <section id="about" class="about">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <br><br>
                    <h2>"Impulsamos la innovación a través de la exploración 3D""</h2><br><br>
                    <p class="lead">Nosotros</p>
                    <p>Make 3D es una organización que se ha propuesto la meta de difundir el uso de la tecnología de fabricación digital, para que algún dí­a las personas no tengan limitaciones para crear lo que imaginen.</p>
                    <br>
                    <p class="lead">Misión</p>
                    <p>"Impulsar la innovación a través de la exploración con la impresión 3D"</p>
                    <p class="lead">Visión</p>
                    <p>"Ser el principal impulsor de la innovación con impresión 3D a nivel latinoamérica"</p>
                    <br><br>
                </div>
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </section>
    

    <!-- Services -->
    <!-- The circle icons use Font Awesome's stacked icon classes. For more information, visit http://fontawesome.io/examples/ -->
    <section id="services" class="services bg-primary">
        <div class="container">
            <div class="row text-center">
                <div class="col-lg-10 col-lg-offset-1">
                    <h2>Nuestros Servicios</h2>
                    <hr class="small">
                    <div class="row">
                        <div class="col-md-3 col-sm-6">
                            <div class="service-item">
                                <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-cloud fa-stack-1x text-primary"></i>
                            </span>
                                <h4>
                                    <strong>Servicio Tecnico</strong>
                                </h4>
                                <p>Asesoria y soporte en tecnologia de fabricación digital.</p>
                                <a href="#" class="btn btn-light">Saber Más</a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <div class="service-item">
                                <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-compass fa-stack-1x text-primary"></i>
                            </span>
                                <h4>
                                    <strong>3D Lab</strong>
                                </h4>
                                <p>Talleres para introducirte en el mundo del diseño digital.</p>
                                <a href="#" class="btn btn-light">Saber Más</a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <div class="service-item">
                                <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-flask fa-stack-1x text-primary"></i>
                            </span>
                                <h4>
                                    <strong>Productos</strong>
                                </h4>
                                <p>Venta de equipos y materiales.<br><br></p>
                                <a href="#" class="btn btn-light">Saber Más</a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-6">
                            <div class="service-item">
                                <span class="fa-stack fa-4x">
                                <i class="fa fa-circle fa-stack-2x"></i>
                                <i class="fa fa-shield fa-stack-1x text-primary"></i>
                            </span>
                                <h4>
                                    <strong>Show Room</strong>
                                </h4>
                                <p>Evento temático en la tecnología de la fabricación digital.<br></p>
                                <a href="#" class="btn btn-light">Saber Más</a>
                            </div>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.col-lg-10 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </section>

    <!-- Callout -->
    <aside class="callout">
        <div class="text-vertical-center">
            <h1>Todo sobre fabricación digital.</h1>
        </div>
    </aside>

    <!-- Portfolio -->
    <section id="portfolio" class="portfolio">
        <div class="container">
            <div class="row">
                <div class="col-lg-10 col-lg-offset-1 text-center">
                    <h2>Nuestros Proyectos</h2>
                    <hr class="small">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="portfolio-item">
                                <a href="#">
                                    <img class="img-portfolio img-responsive" src="img/portfolio-1.jpg">
                                </a>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="portfolio-item">
                                <a href="#">
                                    <img class="img-portfolio img-responsive" src="img/portfolio-2.jpg">
                                </a>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="portfolio-item">
                                <a href="#">
                                    <img class="img-portfolio img-responsive" src="img/portfolio-3.jpg">
                                </a>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="portfolio-item">
                                <a href="#">
                                    <img class="img-portfolio img-responsive" src="img/portfolio-4.jpg">
                                </a>
                            </div>
                        </div>
                    </div>
                    <!-- /.row (nested) -->
                    <a href="#" class="btn btn-dark">View More Items</a>
                </div>
                <!-- /.col-lg-10 -->
            </div>
            <!-- /.row -->
        </div>
        <!-- /.container -->
    </section>

    <!-- Call to Action -->
    <aside class="call-to-action bg-primary">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h3>¿Quieres formar parte de este gran emprendimiento?</h3>
                    <a href="#" class="btn btn-lg btn-light">Click aqui</a>
                    <a href="#" class="btn btn-lg btn-dark">Revisame</a>
                </div>
            </div>
        </div>
    </aside>

    <!-- Map -->
    <section id="contact" class="map">
        <iframe width="100%" height="100%" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://www.google.com.pe/maps/place/Viña+Tacama,+Distrito+de+Lima+15054/@-12.1685039,-76.94911,17z/data=!3m1!4b1!4m5!3m4!1s0x9105b83406349107:0xa9b37a3755343d02!8m2!3d-12.1685039!4d-76.9927223?hl=es-419"></iframe>
        <br />
        <small>
            <a href="https://www.google.com.pe/maps/place/Viña+Tacama,+Distrito+de+Lima+15054/@-12.1685039,-76.94911,17z/data=!3m1!4b1!4m5!3m4!1s0x9105b83406349107:0xa9b37a3755343d02!8m2!3d-12.1685039!4d-76.9927223?hl=es-419"></a>
        </small>
        </iframe>
    </section>

    <!-- Footer -->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-lg-10 col-lg-offset-1 text-center">
                    <h4><strong>MAKE 3D</strong>
                    </h4>
                    <p>Los Parrales de Surco
                        <br>Calle Viña Tacama</p>
                    <ul class="list-unstyled">
                        <li><i class="fa fa-phone fa-fw"></i>(01) 396-0398</li>
                        <li><i class="fa fa-envelope-o fa-fw"></i> <a href="mailto:informes@make3d.com.pe">informes@make3d.com.pe</a>
                        </li>
                    </ul>
                    <br>
                    <ul class="list-inline">
                        <li>
                            <a href="https://www.facebook.com/make3dperu"><i class="fa fa-facebook fa-fw fa-3x"></i></a>
                        </li>
                    </ul>
                    <hr class="small">
                    <p class="text-muted">Copyright &copy; Make 3D 2016</p>
                </div>
            </div>
        </div>
        <a id="to-top" href="#top" class="btn btn-dark btn-lg"><i class="fa fa-chevron-up fa-fw fa-1x"></i></a>
    </footer>

    <!-- jQuery -->
    <script src="js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script>
        // Closes the sidebar menu
        $("#menu-close").click(function (e) {
            e.preventDefault();
            $("#sidebar-wrapper").toggleClass("active");
        });
        // Opens the sidebar menu
        $("#menu-toggle").click(function (e) {
            e.preventDefault();
            $("#sidebar-wrapper").toggleClass("active");
        });
        // Scrolls to the selected menu item on the page
        $(function () {
            $('a[href*=#]:not([href=#],[data-toggle],[data-target],[data-slide])').click(function () {
                if (location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') || location.hostname == this.hostname) {
                    var target = $(this.hash);
                    target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                    if (target.length) {
                        $('html,body').animate({
                            scrollTop: target.offset().top
                        }, 1000);
                        return false;
                    }
                }
            });
        });
        //#to-top button appears after scrolling
        var fixed = false;
        $(document).scroll(function () {
            if ($(this).scrollTop() > 250) {
                if (!fixed) {
                    fixed = true;
                    // $('#to-top').css({position:'fixed', display:'block'});
                    $('#to-top').show("slow", function () {
                        $('#to-top').css({
                            position: 'fixed',
                            display: 'block'
                        });
                    });
                }
            } else {
                if (fixed) {
                    fixed = false;
                    $('#to-top').hide("slow", function () {
                        $('#to-top').css({
                            display: 'none'
                        });
                    });
                }
            }
        });
        // Disable Google Maps scrolling
        // See http://stackoverflow.com/a/25904582/1607849
        // Disable scroll zooming and bind back the click event
        var onMapMouseleaveHandler = function (event) {
            var that = $(this);
            that.on('click', onMapClickHandler);
            that.off('mouseleave', onMapMouseleaveHandler);
            that.find('iframe').css("pointer-events", "none");
        }
        var onMapClickHandler = function (event) {
            var that = $(this);
            // Disable the click handler until the user leaves the map area
            that.off('click', onMapClickHandler);
            // Enable scrolling zoom
            that.find('iframe').css("pointer-events", "auto");
            // Handle the mouse leave event
            that.on('mouseleave', onMapMouseleaveHandler);
        }
        // Enable map zooming with mouse scroll when the user clicks the map
        $('.map').on('click', onMapClickHandler);
    </script>
    <form id="form1" runat="server">

    <div class="modal fade" data-backdrop="static" id="bootstrapmodal">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h2 class="text-center">Bienvenido</h2>

                    </div>
                    <div class="modal-body">
                        <h6 class="text-center">LLENAR CAMPOS PARA LOGUEARSE</h6>
                        <form class="col-md-10 col-md-offset-1 col-xs-12 col-xs-offset-0">
                            <div class="form-group" style="width: 560px; padding-left: 60px; padding-right: 40px;">
                                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" placeholder="Usuario" />
                            </div>
                            <div class="form-group" style="width: 560px; padding-left: 60px; padding-right: 40px;">
                                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />
                            </div>
                            <div style="width: 560px; padding-left: 60px; padding-right: 40px;">
                                <span class="pull-right"></span><span><a href="#">¿Olvidaste tu Contraseña?</a></span>
                                <br />
                                <br />
                                <div style="text-align: center">
                                    <%--<button type="button" runat="server" class="btn btn-danger btn-lg" style="width: 250px; position:relative">Iniciar Sesión</button>--%>
                                    <asp:LinkButton ID="Button1" runat="server" OnClick="iniciarSesion" CssClass="btn btn-danger btn-lg" Style="width: 250px;">Iniciar Sesión</asp:LinkButton>
                                </div>
                            </div>
                        </form>

                    </div>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>

</html>

