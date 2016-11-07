<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="SesionUsuario.aspx.cs" Inherits="SGTE_v1._0.SesionUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div>
        <br />
        <%--<h3 >¡Bienvenido --%><asp:Label ID="lblnombre" runat="server" Visible="False"></asp:Label><%--!</h3>--%>     
        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/bglab.jpg" ImageAlign="Left" Width="100%" />   
    </div>
</asp:Content>
