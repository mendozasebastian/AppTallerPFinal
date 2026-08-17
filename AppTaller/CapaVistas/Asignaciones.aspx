<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asignaciones.aspx.cs" Inherits="AppTaller.CapaVistas.Asignaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" type="text/css" href="~/css/Estilo.css" />
    <title>Taller | Registro de Asignaciones</title>
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
                <li><a class="active" href="/CapaVistas/Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="/CapaVistas/DetallesReparacion.aspx">Detalles de Reparación</a></li>
                <li><a href="/CapaVistas/MiCuenta.aspx">Mi Cuenta</a></li>
            </ul>
        </div>
        <div class="page-container">
            <h1>Registro de Asignaciones</h1>
        </div>

    <div class="page-container reference-section">
        <div class="reference-grids">
            <div class="reference-card">
                <h3>Reparaciones disponibles (para ID Reparación)</h3>
                <asp:GridView ID="GridViewReparacionesRef" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
            <div class="reference-card">
                <h3>Técnicos disponibles (para ID Técnico)</h3>
                <asp:GridView ID="GridViewTecnicosRef" runat="server" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>
    </div>

    <div class="page-container">
        <div class="form-card">
            <h2>Datos del registro</h2>
            <div class="form-grid">
        <div class="form-field">
            <asp:Label ID="lasignacionID" runat="server" Text="ID Asignación" AssociatedControlID="txtAsignacionID"></asp:Label>
            <asp:TextBox ID="txtAsignacionID" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lreparacionID" runat="server" Text="ID Reparación" AssociatedControlID="txtReparacionID"></asp:Label>
            <asp:TextBox ID="txtReparacionID" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="ltecnicoID" runat="server" Text="ID Técnico" AssociatedControlID="txtTecnicoID"></asp:Label>
            <asp:TextBox ID="txtTecnicoID" runat="server" CssClass="txt-input"></asp:TextBox>
        </div>
        <div class="form-field">
            <asp:Label ID="lfechaAsignacion" runat="server" Text="Fecha de Asignación" AssociatedControlID="txtFechaAsignacion"></asp:Label>
            <asp:TextBox ID="txtFechaAsignacion" runat="server" TextMode="Date"></asp:TextBox>
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
                <h3> Historial de Asignaciones</h3>
                <asp:GridView ID="GridView1" runat="server" cssClass="tabla-datos" AutoGenerateColumns="true"></asp:GridView>
            </div>
        </div>
    </div>
      
    </form>
</body>
</html>
