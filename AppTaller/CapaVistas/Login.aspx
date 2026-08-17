<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LOGIN.Capavistas.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Taller | Iniciar sesión</title>
    <link rel="stylesheet" type="text/css" href="~/css/Login.css" />
</head>
<body class="loginBody">
    <form id="form1" runat="server">
        <div class="loginCapsulador">
            <div class="loginCarta">
                <div class="loginCaja">
                    <h1>Taller de Reparaciones</h1>
                    <p>Inicia sesión para continuar</p>
                </div>

                <asp:Label ID="lblError" runat="server" CssClass="loginError" Text="Usuario o contraseña incorrectos" Visible="false"></asp:Label>

                <div class="loginMuro">
                    <label for="txtusuario">Usuario</label>
                    <asp:TextBox ID="txtusuario" runat="server" CssClass="" placeholder="Correo electrónico"></asp:TextBox>
                </div>

                <div class="loginMuro">
                    <label for="txtclave">Contraseña</label>
                    <asp:TextBox ID="txtclave" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                </div>

                <asp:Button ID="btnlogin" runat="server" Text="Ingresar" CssClass="EnvioLogin" OnClick="btnlogin_Click" />

                <div class="loginLink">
                    <a href="RestablecerClave.aspx">¿Olvidaste tu contraseña?</a>
                    <a href="Registro.aspx">Crear cuenta</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
