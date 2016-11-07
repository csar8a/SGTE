<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Inscribete.aspx.cs" Inherits="SGTE_v1._0.Inscribete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">¡Inscríbete!</h1>
            <%--<ol class="breadcrumb">
                            <li>
                                <asp:Label ID="lblEditar" runat="server" Text="Editar"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblNuevo" runat="server" Text="Agregar Colegio"></asp:Label>
                            </li>
                        </ol>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="table-responsive">
                <p class="lead">Envíanos tus datos y te avisaremos cuando se aperture el taller.</p>
                <div class="form-group">
                    <asp:Label ID="lblTipoTaller" runat="server" Text="El tipo de taller que me interesa es: "></asp:Label>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddlTipoTaller" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblDia" runat="server" Text="El día que yo prefiero es: "></asp:Label>
                    <asp:RadioButtonList ID="rbDias" runat="server">
                        <asp:ListItem Value="L">Lunes</asp:ListItem>
                        <asp:ListItem Value="M">Martes</asp:ListItem>
                        <asp:ListItem Value="X">Miercoles</asp:ListItem>
                        <asp:ListItem Value="J">Jueves</asp:ListItem>
                        <asp:ListItem Value="V">Viernes</asp:ListItem>
                        <asp:ListItem Value="S">Sábado</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblHoraInicio" runat="server" Text="Mi horario disponible empieza a las: "></asp:Label>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddlHoraInicio" CssClass="form-control" runat="server">
                        <asp:ListItem Value="09:00">09:00am</asp:ListItem>
                        <asp:ListItem Value="10:00">10:00am</asp:ListItem>
                        <asp:ListItem Value="11:00">11:00am</asp:ListItem>
                        <asp:ListItem Value="12:00">12:00am</asp:ListItem>
                        <asp:ListItem Value="13:00">1:00pm</asp:ListItem>
                    </asp:DropDownList>
                </div>
<%--                <div class="form-group">
                    <asp:Label ID="lblHoraFin" runat="server" Text="Mi horario disponible termina a las: "></asp:Label>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddlHoraFin" CssClass="form-control" runat="server">
                        <asp:ListItem Value="10:00">10:00am</asp:ListItem>
                        <asp:ListItem Value="11:00">11:00am</asp:ListItem>
                        <asp:ListItem Value="12:00">12:00am</asp:ListItem>
                        <asp:ListItem Value="13:00">1:00pm</asp:ListItem>
                        <asp:ListItem Value="14:00">2:00pm</asp:ListItem>
                    </asp:DropDownList>
                </div>--%>
                <asp:Button ID="btnEnviar" CssClass="btn btn-success" runat="server" Text="Enviar Inscripción" OnClick="btnEnviar_Click"/>
                <asp:Label ID="lblmensaje" runat="server" />

            </div>
        </div>
    </div>
</asp:Content>
