<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiCuenta.aspx.cs" Inherits="AppTaller.CapaVistas.MiCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="~/css/Estilo.css" />
    <title>Taller | Mi Cuenta</title>
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
                <li><a href="/CapaVistas/DetallesReparacion.aspx">Detalles de Reparación</a></li>
                <li><a class="active" href="/CapaVistas/MiCuenta.aspx">Mi Cuenta</a></li>
            </ul>
        </div>
        <div class="page-container">
            <h1>Mi Cuenta</h1>
        </div>

        <div class="page-container">
            <asp:Label ID="lblSinSesion" runat="server" CssClass="alert-error" Text="No hay una sesión activa. Por favor inicia sesión de nuevo." Visible="false"></asp:Label>

            <asp:Panel ID="panelCuenta" runat="server">
                <div class="form-card">
                    <h2>Datos de la cuenta</h2>
                    <div class="form-grid">
                        <div class="form-field">
                            <label>Nombre</label>
                            <asp:Label ID="lblNombre" runat="server"></asp:Label>
                        </div>
                        <div class="form-field">
                            <label>Correo</label>
                            <asp:Label ID="lblCorreo" runat="server"></asp:Label>
                        </div>
                    </div>

                    <div class="button-row">
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar mi cuenta" OnClick="btnEliminarCuenta_Click"
                            OnClientClick="return confirm('¿Seguro que deseas eliminar tu cuenta? Esta acción no se puede deshacer.');" />
                    </div>
                </div>
            </asp:Panel>
        </div>

    </form>
</body>
</html>
