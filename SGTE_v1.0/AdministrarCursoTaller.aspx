<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdministrarCursoTaller.aspx.cs" Inherits="SGTE_v1._0.AdministrarCursoTaller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            <div class="row">
                <div class="col-lg-12">
                        <h1 class="page-header">Talleres</h1>
                        <%--<ol class="breadcrumb">
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
                    <div class="table-responsive">
                    <%--<form id="administrarProfesores" role="form" runat="server">--%>
                        <p class="lead">Selecciona el taller para ver sus datos completos.</p>

                        <asp:Label ID="lbl_mensaje" runat="server"></asp:Label>

                        <asp:GridView ID="gvCursoTaller" class="table table-bordered table-hover" runat="server" BorderColor="#337AB7" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowCommand="gvCursoTaller_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Codigo del Taller" DataField="codTaller" />
                                <asp:BoundField HeaderText="Nombre del Taller" DataField="nombre" />
                                <asp:BoundField HeaderText="Nivel" DataField="nivel" />
                                <asp:BoundField HeaderText="Rango" DataField="rango" />
                                <asp:BoundField HeaderText="Duracion Total" DataField="totalHoras" />
                                <asp:ButtonField HeaderText="Ver Datos" Text="Ver" CommandName="Ver" />
                            </Columns>
                            <%--<EmptyDataTemplate>
                                No se encuentran talleres registrados.
                            </EmptyDataTemplate>--%>
                        </asp:GridView>
                        <asp:Button ID="btnNuevoTaller" runat="server" Text="Nuevo Taller" OnClick="btnNuevoTaller_Click" />

                   <%-- </form>--%>
                    </div>
                </div>
            <!-- /.row -->
            </div>
</asp:Content>
