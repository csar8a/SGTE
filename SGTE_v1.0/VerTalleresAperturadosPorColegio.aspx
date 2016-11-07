<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerTalleresAperturadosPorColegio.aspx.cs" Inherits="SGTE_v1._0.VerTalleresAperturadosPorColegio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">¡Inscríbete!</h1>
            <%--<ol class="breadcrumb">
                            <li>
                                <asp:Label ID="lblInscribete" runat="server" Text="Inscribirme"></asp:Label>
                            </li>
                            
                        </ol>--%>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <div class="table-responsive">
                <p class="lead">Mira los talleres disponibles para ti e inscribete.</p>
                <br  /><br  />
                 <div class="form-group">
                    <asp:Label ID="prueba" runat="server" />
                    <asp:Label ID="nivel" runat="server" />
                     <asp:Label ID="codTA" runat="server" />
                </div>
                <asp:GridView align="center" Width="85%" ID="gv_talleresaperturados" runat="server" OnRowCommand="gv_talleresaperturados_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="codTallerAperturado" HeaderText="Codigo de T.A" />
                        <asp:BoundField DataField="Taller" HeaderText="Taller" Visible="true" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="dia" HeaderText="Dia" />
                        <asp:BoundField DataField="horaInicio" HeaderText="Hora de Inicio" />
                        <asp:BoundField DataField="horaFin" HeaderText="Hora Fin" />
                        <asp:ButtonField ButtonType="Button" Text="Inscribirse" CommandName="Inscribirse">
                            <ControlStyle CssClass="btn btn-info" />
                        </asp:ButtonField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#555555" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Mode="NumericFirstLast" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <br />
                <br />
                <asp:Button ID="btnPedir" runat="server" Text="Pedir Nuevo Taller" OnClick="btnPedir_Click" />
            </div>
            <asp:Label ID="lblmensaje" align="center" runat="server" />
        </div>
    </div>
</asp:Content>
