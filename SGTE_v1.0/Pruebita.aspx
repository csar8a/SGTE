<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pruebita.aspx.cs" Inherits="SGTE_v1._0.Pruebita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="Codigo Taller Aperturado" runat="server" />
        <asp:TextBox runat="server" ID="codTalleAper"/>
        <asp:Label Text="Codigo Colegio" runat="server" />
        <asp:TextBox runat="server" ID="codCol"/>
        <asp:Button Text="Asignar profo :V" runat="server" OnClick="Unnamed_Click" />
    </div>
    </form>
</body>
</html>
