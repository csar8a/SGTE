<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerServicios.aspx.cs" Inherits="SGTE_v1._0.VerServicios" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Ver Servicio</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <p class="lead">Consultar / editar  Servicio</p>
            <br />
            <p class="lead">Datos del Servicio </p>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombres: "></asp:Label>
                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Ingrese el nombre" Width="70%" MaxLength="20" runat="server"></asp:TextBox>
                
            </div>
            <div class="form-group">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Descripcion" Width="70%" MaxLength="50" runat="server"></asp:TextBox>
                
            </div>
            
                                

                       
         
            <div class="form-group">
                <asp:Label ID="lblestado" runat="server" Text="Condición: "></asp:Label>
                <asp:DropDownList ID="ddlEstado" CssClass="form-control" Width="40%" runat="server" AutoPostBack="True" >
                    <asp:ListItem Value="1">HABILITADO</asp:ListItem>
                    <asp:ListItem Value="0">DESHABILITADO</asp:ListItem>
                    
                </asp:DropDownList>
            </div>
           

          





        </div>

       
    </div>
    <div style="text-align: center">
        <asp:Label ID="lbl_mensaje" align="center" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="btnRegresar" CssClass="btn btn-danger" Style="float: right" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    <asp:Button ID="btnGuardar" CssClass="btn btn-warning" Style="float: right" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />    



    

</asp:Content>
