<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AsignarProfesor.aspx.cs" Inherits="SGTE_v1._0.AsignarProfesor" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Asignar Profesor</h1>
        </div>
    </div>



    <div class="row">
        <div class="col-lg-6">
            <div class="table-responsive">
                <p class="lead">Seleccione el profesor para el taller aperturado</p>

                <div class="form-group">
                    <asp:Label ID="lblNombTallerAperturado" runat="server" Text="Nombre de taller aperturado: "></asp:Label>
                    <asp:TextBox ID="txtNombTallerAperturado" class="form-control" runat="server" ></asp:TextBox>
                </div>

                <asp:Label Text="Ubicacion del colegio" runat="server" />
                <br />
                <br />
                <div class="form-group">
                    <cc1:GMap ID="gmap1" runat="server" enableServerEvents="True" />
                </div>
                <div class="form-group">
                    <asp:Label ID="lblLat" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblLng" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblLat2" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblLng2" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lbldia" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="dista" runat="server" />
                    <br /><asp:Label ID="lblalerta" runat="server" Visible="false"/>
                    <br />
                    <asp:Label ID="idTallerAper" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="idProfe" runat="server" Visible="false"></asp:Label>
                </div>

            </div>
        </div>

        <div class="col-lg-6">
            <br />
            <br />
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Colegio: "></asp:Label>
                <asp:TextBox ID="txtCole" class="form-control" runat="server" ></asp:TextBox>
            </div>

            <asp:Label ID="Label7" runat="server" Text="Profesores: "></asp:Label>
            <br />
            <br />
            <div class="form-group">
                
                <asp:GridView align="center" Width="85%" ID="gv_profesores" runat="server" OnRowCommand="gv_profesores_RowCommand" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="codPersona" HeaderText="ID" Visible="true" />
                        <asp:BoundField DataField="nombres" HeaderText="Nombre" />
                        <asp:BoundField DataField="apPaterno" HeaderText="Apellido Paterno" />
                        <asp:BoundField DataField="apMaterno" HeaderText="Apellido Materno" />
                        <asp:BoundField DataField="distrito" HeaderText="Distrito" />
                        <asp:ButtonField ButtonType="Button" Text="Asignar" CommandName="Asignar">
                            <ControlStyle CssClass="btn btn-info" />
                        </asp:ButtonField>
                        <%--<asp:ButtonField ButtonType="Button" Text="Ver" CommandName="Ver">
                            <ControlStyle CssClass="btn btn-info" />
                        </asp:ButtonField>--%>
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
                <asp:Button ID="btnAmpliarRango" CssClass="btn btn-info" Style="float: right" runat="server" Text="Ampliar Distancia Maxima" OnClick="btnAmpliarRango_Click"  />

            </div>


        </div>


    </div>

    <div style="text-align: center">
        <asp:Label ID="lblmensaje" align="center" runat="server" Text=""></asp:Label>
    </div>
    <asp:Button ID="btnRegresar" CssClass="btn btn-danger" Style="float: right" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
    <asp:Button ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" Style="float: right" runat="server" Text="Guardar" />
</asp:Content>
