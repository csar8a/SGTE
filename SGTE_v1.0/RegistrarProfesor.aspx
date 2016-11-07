<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarProfesor.aspx.cs" Inherits="SGTE_v1._0.RegistrarProfesor" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Registrar Profesor</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <p class="lead">Ingrese los datos personales</p>
            <div class="form-group">
                <asp:Label ID="lblNombres" runat="server" Text="Nombres: "></asp:Label>
                <asp:TextBox ID="txtNombres" class="form-control" placeholder="Ingrese el nombre" Width="70%" MaxLength="20" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblApPat" runat="server" Text="Apellido Paterno: "></asp:Label>
                <asp:TextBox ID="txtApPAt" class="form-control" placeholder="Ingrese el apellido paterno" Width="70%" MaxLength="50" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblApMat" runat="server" Text="Apellido Materno: "></asp:Label>
                <asp:TextBox ID="txtApMat" class="form-control" placeholder="Ingrese el apellido materno" Width="70%" MaxLength="20" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNumDoc" runat="server" Text="Num. Documento: "></asp:Label>
                <asp:TextBox ID="txtNumDoc" class="form-control" placeholder="Ingrese el número de documento" runat="server" Width="40%" MaxLength="8"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblSexo" runat="server" Text="Sexo: "></asp:Label>
                <asp:DropDownList ID="ddlSexo" CssClass="form-control" Width="40%" runat="server">
                    <asp:ListItem Value="0">-Seleccione un sexo-</asp:ListItem>
                    <asp:ListItem Value="M">Masculino</asp:ListItem>
                    <asp:ListItem Value="F">Femenino</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblFechaNac" runat="server" Text="Fecha de Nacimiento: "></asp:Label>
                <asp:TextBox class="form-control" ID="txt_fecha" Width="40%" MaxLength="10" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblDireccion" runat="server" Text="Direccion: "></asp:Label>
                <asp:TextBox ID="txtDireccion" class="form-control" placeholder="Ingrese la dirección" Width="70%" MaxLength="150" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblTelf" runat="server" Text="Telefono: "></asp:Label>
                <asp:TextBox ID="txtTelf" class="form-control" placeholder="Ingrese el teléfono" runat="server" Width="40%" MaxLength="11"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" Text="Correo Electronico: "></asp:Label>
                <asp:TextBox ID="txtEmail" class="form-control" placeholder="Ingrese el correo electrónico" MaxLength="50" Width="70%" runat="server"></asp:TextBox>
            </div>
            <br />
            <br />
            <br />
            <p class="lead">Ingrese los datos de trabajador</p>
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Ingrese fecha de contrato: "></asp:Label>
                <asp:TextBox class="form-control" ID="txtContrato" Width="40%" MaxLength="10" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Duracion del contrato(meses): "></asp:Label>
                <asp:TextBox ID="txtDuracion" class="form-control" Width="40%" MaxLength="3" runat="server"></asp:TextBox>
            </div>
            <div class="form-group"><asp:Label ID="lblDisponible" runat="server" Text="" Visible="False"></asp:Label>
                <asp:Label ID="Label7" runat="server" Text="Días disponibles en la semana: "></asp:Label>
                <asp:CheckBoxList ID="cblDiasDisponible" runat="server">
                    <asp:ListItem Value="L">Lunes</asp:ListItem>
                    <asp:ListItem Value="M">Martes</asp:ListItem>
                    <asp:ListItem Value="X">Miercoles</asp:ListItem>
                    <asp:ListItem Value="J">Jueves</asp:ListItem>
                    <asp:ListItem Value="V">Viernes</asp:ListItem>
                    <asp:ListItem Value="S">Sábado</asp:ListItem>
                </asp:CheckBoxList>
            </div>
            <div class="form-group">
                <asp:Label ID="lblCV" runat="server" Text="Curriculum Vitae: "></asp:Label>
                <asp:FileUpload ID="fuSubirCV" runat="server" />
                <asp:Button ID="btnSubirCV" runat="server" CssClass="btn btn-primary" Text="Cargar CV" OnClick="btnSubirCV_Click" />
                <asp:Label ID="lbl_mensaje_3" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lbl_mensaje_4" runat="server"></asp:Label>
            </div>
        </div>

        <div class="col-lg-6">
            <p class="lead">Selecciona una foto para su perfil</p>
            <asp:FileUpload ID="fu_examinar" runat="server" />
            <asp:Image ID="img_foto" runat="server" Height="220px" Width="240px" />
            <br />
            <asp:Button ID="btnSubirFoto" CssClass="btn btn-primary" runat="server" Text="Subir" OnClick="btnSubirFoto_Click" />
            <asp:Label ID="lbl_mensaje_1" runat="server" Visible="False"></asp:Label>
            <asp:Label ID="lbl_mensaje_2" runat="server"></asp:Label>
            <br />
            <br />
            <br />
            <p class="lead">Detalle la ubicación del profesor</p>
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Provincia: "></asp:Label>
                <asp:DropDownList ID="ddlProvincia" CssClass="form-control" Width="40%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Distrito: "></asp:Label>
                <asp:DropDownList ID="ddlDistrito" CssClass="form-control" Width="40%" runat="server">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="inputdefault" style="position: absolute;">Verificar dirección:</label>
                <br />
                    <table class="input-daterange">
                    <tr>
                        <td style="width: 87%; text-align: left;">
                            <asp:TextBox ID="tb_Buscar" runat="server" placeholder="Ingrese la dirección" class="form-control" Width="100%" MaxLength="150"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="bt_Buscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="bt_Buscar_Click" meta:resourcekey="bt_BuscarResource1" />
                        </td>
                    </tr>
                </table>         
            </div>
            <p>
                <asp:Label ID="lb_Buscar" runat="server"></asp:Label>
            </p>
            <cc1:GMap ID="gmap1" runat="server" enableServerEvents="True" />
            <div class="form-group">
                <asp:Label ID="lblLat" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="lblLng" runat="server" Visible="False"></asp:Label>
            </div>
        </div>
    </div>
    <div style="text-align: center">
        <asp:Label ID="lbl_mensaje" align="center" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="btnRegresar" CssClass="btn btn-danger" Style="float: right" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    <asp:Button ID="btnGuardar" CssClass="btn btn-success" Style="float: right" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
</asp:Content>
