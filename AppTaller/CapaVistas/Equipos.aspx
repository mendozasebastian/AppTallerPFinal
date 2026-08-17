<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="AppTaller.CapaVistas.Equipos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="~/css/Estilo.css" />
    <title>Taller | Registro de Equipos</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <ul>
                <li><a href="/CapaVistas/Default.aspx">Home</a></li>
                <li><a class="active" href="/CapaVistas/Equipos.aspx">Equipos</a></li>
                <li><a href="/CapaVistas/Usuarios.aspx">Usuarios</a></li>
                <li><a href="/CapaVistas/Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="/CapaVistas/Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="/CapaVistas/Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="/CapaVistas/DetallesReparacion.aspx">Detalles de Reparación</a></li>
                <li><a href="/CapaVistas/MiCuenta.aspx">Mi Cuenta</a></li>
            </ul>
        </div>
        <div class="page-container">
            <h1>Registro de Equipos</h1>
        </div>

    <div class="page-container reference-section">
        <div class="reference-grids">
            <div class="reference-card">
                <h3>Usuarios disponibles (para ID Usuario)</h3>
                <asp:GridView ID="GridViewUsuariosRef" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>
    </div>

    <div class="page-container">
        <div class="form-card">
            <h2>Datos del registro</h2>
            <div class="form-grid">
        <div class="form-field">
            <asp:Label ID="lequipo" runat="server" Text="ID Equipo" AssociatedControlID="txtEquipoID"></asp:Label>
            <asp:TextBox ID="txtEquipoID" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="ltipoEquipo" runat="server" Text="Tipo de Equipo" AssociatedControlID="txtTipoEquipo"></asp:Label>
            <asp:TextBox ID="txtTipoEquipo" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lModelo" runat="server" Text="Modelo" AssociatedControlID="txtModelo"></asp:Label>
            <asp:TextBox ID="txtModelo" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lUsuarioID" runat="server" Text="ID Usuario" AssociatedControlID="txtUsuarioID"></asp:Label>
            <asp:TextBox ID="txtUsuarioID" runat="server" CssClass="txt-input"></asp:TextBox>
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
                <h3> Historial de Equipo</h3>
                <asp:GridView ID="GridView1" runat="server" cssClass="tabla-datos" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>
    </div>

    </form>
</body>
</html>
