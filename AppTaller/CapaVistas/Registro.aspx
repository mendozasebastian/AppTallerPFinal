<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="LOGIN.Capavistas.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Taller | Crear cuenta</title>
    <link rel="stylesheet" type="text/css" href="~/css/Login.css" />
</head>
<body class="loginBody">
    <form id="form1" runat="server">
        <div class="loginCapsulador">
            <div class="loginCarta">
                <div class="loginCaja">
                    <h1>Crear cuenta</h1>
                    <p>Regístrate para acceder al sistema</p>
                </div>

                <asp:Label ID="lblError" runat="server" CssClass="loginError" Visible="false"></asp:Label>
                <asp:Label ID="lblExito" runat="server" CssClass="loginValido" Text="Cuenta creada correctamente. Ya puede iniciar sesión" Visible="false"></asp:Label>

                <div class="loginMuro">
                    <label for="txtNombre">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Tu nombre"></asp:TextBox>
                </div>

                <div class="loginMuro">
                    <label for="txtCorreo">Correo electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" placeholder="correo@ejemplo.com"></asp:TextBox>
                </div>

                <div class="loginMuro">
                    <label for="txtClave">Contraseña</label>
                    <asp:TextBox ID="txtClave" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                </div>

                <div class="loginMuro">
                    <label for="txtConfirmarClave">Confirmar contraseña</label>
                    <asp:TextBox ID="txtConfirmarClave" runat="server" TextMode="Password" placeholder="Repite la contraseña"></asp:TextBox>
                </div>

                <asp:Button ID="btnRegistrar" runat="server" Text="Crear cuenta" CssClass="EnvioLogin" OnClick="btnRegistrar_Click" />

                <a href="Login.aspx" class="loginRegreso">&larr; Volver a iniciar sesión</a>
            </div>
        </div>
    </form>
</body>
</html>
