<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdministrarServicio.aspx.cs" Inherits="SGTE_v1._0.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

     <div class="row">
        <div class="col-lg-12" style="color:#9B0B25">
            <h1 class="page-header">Listado de Servicios</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6 col-lg-offset-3">
            <div class="form-group">
              <h4 class="page-header">Nombre del Servicio :</h4>
                <div style="padding-left: 20%; height: 80px;">
                    <table class="input-daterange">
                        <tr>
                            <td style="width: 80%; text-align: left; color:#9B0B25;">
                                <asp:TextBox ID="txt_servicio"  runat="server" class="form-control" Style="width: 100%;" MaxLength="20" BackColor="	#DCDCDC"  > </asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_buscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="btn_buscar_Click" BorderColor="#4682B4"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-7 col-lg-offset-2" style="text-align: center; top: 10px; left: 0px;">
            <div class="form-group">
                <asp:CheckBox ID="check_visualizar" runat="server" align="right" AutoPostBack="true" Text="Visualizar servicios deshabilitados" Font-Bold="True" ForeColor="#2d2c2c" OnCheckedChanged="check_visualizar_CheckedChanged" />
                <br />
                <asp:Label ID="hab" Text="HABILITADOS" runat="server" /> 

            <asp:GridView align="center" Width="85%" ID="gv_servicios" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnRowCommand="gv_servicios_RowCommand" OnPageIndexChanging="gv_servicios_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="codServicio" HeaderText="ID" Visible="true" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                  
                    <asp:ButtonField ButtonType="Button" Text="Ver" CommandName="Ver" >
                        <ControlStyle CssClass="btn btn-info" BackColor="#990000" BorderColor="YellowGreen"/>
                    </asp:ButtonField>
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#7CBAF0" Font-Bold="True" ForeColor="White" />
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
            <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>
        </div>

       </div>
   <br />

    

        <div>
           <asp:Button ID="Button1" CssClass="btn btn-primary"  runat="server" Style="float: right; margin-right:30% " Text="Registrar Servicio" OnClick="btn_registrar_Click" />
                
     </div>
     </div>


</asp:Content>
