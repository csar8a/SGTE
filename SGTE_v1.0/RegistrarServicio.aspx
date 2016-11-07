<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="RegistrarServicio.aspx.cs" Inherits="SGTE_v1._0.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

      <div class="row">
        <div class="col-lg-12" style="color:#8E1329">
            <h1 class="page-header">Registrar Servicio</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <p class="lead" style="height:60px;">Ingrese informacion del Servicio : </p>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre : "></asp:Label>
                <asp:TextBox ID="txtNombre" class="form-control" placeholder="Ingrese el nombre " Width="70%" MaxLength="20" runat="server"></asp:TextBox>
            </div>
            <div class="form-group" >
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
                <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Descripcion " Width="70%" MaxLength="80" runat="server"></asp:TextBox>
            </div>           
                 

           
        </div>
   
   <div style="text-align: center">
        <asp:Label ID="lbl_mensaje" align="center" runat="server" Text=""></asp:Label>
    </div>

    <asp:Button ID="btnRegresar" CssClass="btn btn-danger" Style="float: right" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    <asp:Button ID="btnGuardar" CssClass="btn btn-success" Style="float: right" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />


</asp:Content>
