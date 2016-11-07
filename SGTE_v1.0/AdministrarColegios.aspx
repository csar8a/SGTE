<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="AdministrarColegios.aspx.cs" Inherits="SGTE_v1._0.AdministrarColegios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            <div class="row">
                <div class="col-lg-12">
                        <h1 class="page-header">Colegios</h1>
                        <ol class="breadcrumb">
                            <li>
                                <asp:Label ID="lblEditar" runat="server" Text="Editar"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblNuevo" runat="server" Text="Agregar Colegio"></asp:Label>
                            </li>
                        </ol>
                </div>                    
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="table-responsive">
                        <p class="lead">Selecciona el colegio para ver sus datos completos.</p>

                        <asp:GridView ID="gvColegios" class="table table-bordered table-hover" runat="server" BorderColor="#337AB7" EmptyDataText="No se encuentran registros disponibles." HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre Taller" />
                                <asp:BoundField HeaderText="Tipo Taller" />
                                <asp:BoundField HeaderText="Duracion Total" />
                                <asp:BoundField HeaderText="Duracion Clase" />
                                <asp:ButtonField HeaderText="Ver Datos" Text="Ver" />
                            </Columns>
                            <EmptyDataTemplate>
                                Apellidos
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <asp:Button ID="btnNuevoColegio" runat="server" Text="Nuevo Colegio" OnClick="btnNuevoColegio_Click" />

                    </div>
                </div>
            </div>
</asp:Content>
