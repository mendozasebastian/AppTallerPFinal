<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallesReparacion.aspx.cs" Inherits="AppTaller.CapaVistas.DetallesReparacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="~/css/Estilo.css" />
    <title>Taller | Detalles de Reparación</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <ul>
                <li><a href="/CapaVistas/Default.aspx">Home</a></li>
                <li><a href="/CapaVistas/Equipos.aspx">Equipos</a></li>
                <li><a href="/CapaVistas/Usuarios.aspx">Usuarios</a></li>
                <li><a href="/CapaVistas/Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="/CapaVistas/Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="/CapaVistas/Asignaciones.aspx">Asignaciones</a></li>
                <li><a class="active" href="/CapaVistas/DetallesReparacion.aspx">Detalles de Reparación</a></li>
                <li><a href="/CapaVistas/MiCuenta.aspx">Mi Cuenta</a></li>
            </ul>
        </div>
        <div class="page-container">
            <h1>Detalles de Reparación</h1>
        </div>

    <div class="page-container reference-section">
        <div class="reference-grids">
            <div class="reference-card">
                <h3>Reparaciones disponibles (para ID Reparación)</h3>
                <asp:GridView ID="GridViewReparacionesRef" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>
    </div>

    <div class="page-container">
        <div class="form-card">
            <h2>Datos del registro</h2>
            <div class="form-grid">
        <div class="form-field">
            <asp:Label ID="ldetalleID" runat="server" Text="ID Detalle" AssociatedControlID="txtDetalleID"></asp:Label>
            <asp:TextBox ID="txtDetalleID" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lreparacionID" runat="server" Text="ID Reparación" AssociatedControlID="txtReparacionID"></asp:Label>
            <asp:TextBox ID="txtReparacionID" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="ldescripcion" runat="server" Text="Descripción" AssociatedControlID="txtDescripcion"></asp:Label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lfechaInicio" runat="server" Text="Fecha de Inicio" AssociatedControlID="txtFechaInicio"></asp:Label>
            <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lfechaFinal" runat="server" Text="Fecha de Finalización" AssociatedControlID="txtFechaFinal"></asp:Label>
            <asp:TextBox ID="txtFechaFinal" runat="server" TextMode="Date"></asp:TextBox>
        </div>
            </div>
            <div class="button-row">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
            </div>
        </div>
    </div>

    <div class="page-container reference-section">
        <div class="reference-grids">
            <div class="reference-card">
                <h3> Historial de Reparaciones</h3>
                <asp:GridView ID="GridView1" runat="server" cssClass="tabla-datos" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
