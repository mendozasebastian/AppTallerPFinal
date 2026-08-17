<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestablecerClave.aspx.cs" Inherits="LOGIN.Capavistas.RestablecerClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Taller | Restablecer contraseña</title>
    <link rel="stylesheet" type="text/css" href="~/css/Login.css" />
</head>
<body class="loginBody">
    <form id="form1" runat="server">
        <div class="loginCapsulador">
            <div class="loginCarta">
                <div class="loginCaja">
                    <span class="login-icon">🔑</span>
                    <h1>Restablecer contraseña</h1>
                    <p>Indica tu correo y la nueva contraseña</p>
                </div>

                <asp:Label ID="lblError" runat="server" CssClass="loginError" Visible="false"></asp:Label>
                <asp:Label ID="lblExito" runat="server" CssClass="loginValido" Text="Contraseña actualizada correctamente. Ya puedes iniciar sesión." Visible="false"></asp:Label>

                <div class="loginMuro">
                    <label for="txtCorreo">Correo electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" placeholder="correo@ejemplo.com"></asp:TextBox>
                </div>

                <div class="loginMuro">
                    <label for="txtNuevaClave">Nueva contraseña</label>
                    <asp:TextBox ID="txtNuevaClave" runat="server" TextMode="Password" placeholder="Nueva contraseña"></asp:TextBox>
                </div>

                <div class="loginMuro">
                    <label for="txtConfirmarClave">Confirmar contraseña</label>
                    <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password" placeholder="Repite la nueva contraseña"></asp:TextBox>
                </div>

                <asp:Button ID="btnRestablecer" runat="server" Text="Restablecer contraseña" CssClass="EnvioLogin" OnClick="btnRestablecer_Click" />

                <a href="Login.aspx" class="loginRegreso">&larr; Volver a iniciar sesión</a>
            </div>
        </div>
    </form>
</body>
</html>
