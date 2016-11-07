<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarCursoTaller.aspx.cs" Inherits="SGTE_v1._0.RegistrarCursoTaller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Ver Taller</h1>
            <%--ol class="breadcrumb">
                <li>
                    <asp:Label ID="lblEditar" runat="server" Text="Editar"></asp:Label>
                </li>
                <li>
                    <asp:Label ID="lblNuevo" runat="server" Text="Agregar Taller"></asp:Label>
                </li>
            </ol>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
                <p class="lead">Selecciona editar para modificar la información.</p>

                <div class="form-group">
                    <asp:Label ID="lblNombTaller" runat="server" Text="Nombre de taller: "></asp:Label>
                    <asp:TextBox ID="txtNombTaller" class="form-control" placeholder="Enter text" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblNivel" runat="server" Text="Nivel: "></asp:Label>
                    <asp:DropDownList ID="lbNivel" class="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="lbNivel_SelectedIndexChanged">
                        <asp:ListItem>Primaria</asp:ListItem>
                        <asp:ListItem>Secundaria</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblSecciones" runat="server" Text="Secciones: "></asp:Label>
                    <asp:CheckBoxList ID="cbSecciones" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">1°</asp:ListItem>
                        <asp:ListItem Value="2">2°</asp:ListItem>
                        <asp:ListItem Value="3">3°</asp:ListItem>
                        <asp:ListItem Value="4">4°</asp:ListItem>
                        <asp:ListItem Value="5">5°</asp:ListItem>
                        <asp:ListItem Value="6">6°</asp:ListItem>
                    </asp:CheckBoxList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblHoras" runat="server" Text="Horas: " ></asp:Label>
                    <asp:TextBox ID="txtHoras" class="form-control" runat="server" MaxLength="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
                    <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Descripcion del taller" runat="server" ></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTipoClases" runat="server" Text="Las clases incluyen: "></asp:Label>
                    <asp:RadioButton ID="rbLaboratorio" GroupName="Clase" class="form-control" runat="server" Text="Laboratorio Digital" />
                    <asp:RadioButton ID="rbPostprocesado" GroupName="Clase" class="form-control" runat="server" Text="Taller de Postprocesado" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblCV" runat="server" Text="Sílabo: "></asp:Label>
                    <asp:FileUpload ID="fuSubirCV" runat="server" />
                    <asp:Button ID="btnSubirCV" runat="server" CssClass="btn btn-primary" Text="Cargar Silabo" OnClick="btnSubirCV_Click" />
                    <asp:Label ID="lbl_mensaje_3" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lbl_mensaje_4" runat="server"></asp:Label>
                </div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
        </div>
    </div>

</asp:Content>
