<%@ Page Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="VerTalleres.aspx.cs" Inherits="SGTE_v1._0.VerTalleres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">
                            Ver Profesor
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <asp:Label ID="lblEditar" runat="server" Text="Editar"></asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblNuevo" runat="server" Text="Agregar Taller"></asp:Label>
                            </li>
                        </ol>
                    </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                        <p class="lead">Selecciona editar para modficiar la información.</p>
                        
                        <div class="form-group">
                            <asp:Label ID="lblNombTaller" runat="server" Text="Nombre de taller: "></asp:Label>
                            <asp:TextBox ID="txtNombTaller" class="form-control" placeholder="Enter text" runat="server"></asp:TextBox>                    
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblNivel" runat="server" Text="Nivel: "></asp:Label>
                            <asp:ListBox ID="lbNivel" class="form-control" runat="server">
                                <asp:ListItem>Primaria</asp:ListItem>
                                <asp:ListItem>Secundaria</asp:ListItem>
                            </asp:ListBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblSecciones" runat="server" Text="Secciones: "></asp:Label>
                            <asp:RadioButtonList ID="rbSecciones" runat="server">
                                <asp:ListItem Value="Primero">1°</asp:ListItem>
                                <asp:ListItem Value="Segundo">2°</asp:ListItem>
                                <asp:ListItem Value="Tercero">3°</asp:ListItem>
                                <asp:ListItem Value="Cuarto">4°</asp:ListItem>
                                <asp:ListItem Value="Quinto">5°</asp:ListItem>
                                <asp:ListItem Value="Sexto">6°</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblHoras" runat="server" Text="Horas: "></asp:Label>
                            <asp:TextBox ID="txtHoras" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: "></asp:Label>
                            <asp:TextBox ID="txtDescripcion" class="form-control" placeholder="Descripcion del taller" runat="server" MaxLength="8"></asp:TextBox>                    
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblTipoClases" runat="server" Text="Las clases incluyen: "></asp:Label>
                            <asp:RadioButton ID="rbLaboratorio" class="form-control" runat="server" Text="Laboratorio Digital" />
                            <asp:RadioButton ID="rbPostprocesado" class="form-control" runat="server" Text="Taller de Postprocesado" />
                        </div>
                        
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                </div>
            </div>
</asp:Content>

