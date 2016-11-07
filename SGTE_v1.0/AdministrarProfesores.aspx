<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdministrarProfesores.aspx.cs" Inherits="SGTE_v1._0.AdministrarProfesores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Listado de Profesores</h1>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-6 col-lg-offset-3">
            <div class="form-group">
                <label for="inputdefault" style="position: absolute; padding-top: 5px;">Nombre del Profesor:</label>
                <div style="padding-left: 25%; height: 32px;">
                    <table class="input-daterange">
                        <tr>
                            <td style="width: 80%; text-align: left;">
                                <asp:TextBox ID="txt_profesor" runat="server" class="form-control" Style="width: 100%;" MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_buscar" runat="server" class="btn btn-default" Text="Buscar" OnClick="btn_buscar_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-lg-7 col-lg-offset-2" style="text-align: center">
            <div style="float: right">
                <asp:CheckBox ID="check_visualizar" runat="server" AutoPostBack="true" Text="Visualizar profesores en capacitación" Font-Bold="True" ForeColor="#2d2c2c" OnCheckedChanged="check_visualizar_CheckedChanged" /></div>
            <asp:GridView align="center" Width="85%" ID="gv_profesores" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnRowCommand="gv_profesores_RowCommand" OnPageIndexChanging="gv_profesores_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="codPersona" HeaderText="ID" Visible="true" />
                    <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                    <asp:BoundField DataField="apPaterno" HeaderText="Apellido Paterno" />
                    <asp:BoundField DataField="apMaterno" HeaderText="Apellido Materno" />
                    <asp:BoundField DataField="estadoProfesor" HeaderText="Condición" />
                    <asp:BoundField DataField="distrito" HeaderText="Distrito" />
                    <asp:ButtonField ButtonType="Button" Text="Ver" CommandName="Ver">
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
            <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="btn_registrar" CssClass="btn btn-primary" runat="server" Style="float: right; margin-right:30%" Text="Registrar Profesor" OnClick="btn_registrar_Click" />
        </div>
    </div>

</asp:Content>
