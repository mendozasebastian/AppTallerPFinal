<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppTaller.CapaVistas.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="~/css/Estilo.css" />
    <link rel="stylesheet" type="text/css" href="~/css/Landing.css" />
    <title>Taller | Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-container">
            <ul>
                <li><a class="active" href="/CapaVistas/Default.aspx">Home</a></li>
                <li><a href="/CapaVistas/Equipos.aspx">Equipos</a></li>
                <li><a href="/CapaVistas/Usuarios.aspx">Usuarios</a></li>
                <li><a href="/CapaVistas/Tecnicos.aspx">Tecnicos</a></li>
                <li><a href="/CapaVistas/Reparaciones.aspx">Reparaciones</a></li>
                <li><a href="/CapaVistas/Asignaciones.aspx">Asignaciones</a></li>
                <li><a href="/CapaVistas/DetallesReparacion.aspx">Detalles de Reparación</a></li>
                <li><a href="/CapaVistas/MiCuenta.aspx">Mi Cuenta</a></li>
            </ul>
        </div>

        <section class="hero">
            <div class="hero-content">
                <span class="eyebrow">Sistema de Gestion</span>
                <h1>Taller de Reparaciones</h1>
                <p>Administra equipos, usuarios, tecnicos y reparaciones.</p>
                <div class="hero-actions">
                    <a href="/CapaVistas/Equipos.aspx" class="btn btn-primary">Ver equipos registrados</a>
                    <a href="/CapaVistas/Reparaciones.aspx" class="btn btn-secondary">Ver reparaciones</a>
                </div>
            </div>
        </section>

        <section class="features">
            <div class="feature-card">
                <div class="feature-icon">🖥️</div>
                <h3>Equipos</h3>
                <p>Registra, consulta, actualiza y elimina los equipos ingresados al taller.</p>
                <a href="/CapaVistas/Equipos.aspx">Gestionar equipos &rarr;</a>
            </div>
            <div class="feature-card">
                <div class="feature-icon">👤</div>
                <h3>Usuarios</h3>
                <p>Lleva el control de los usuarios que traen sus equipos al taller.</p>
                <a href="/CapaVistas/Usuarios.aspx">Gestionar usuarios &rarr;</a>
            </div>
            <div class="feature-card">
                <div class="feature-icon">🛠️</div>
                <h3>Técnicos</h3>
                <p>Administra el equipo técnico y sus especialidades.</p>
                <a href="/CapaVistas/Tecnicos.aspx">Gestionar técnicos &rarr;</a>
            </div>
            <div class="feature-card">
                <div class="feature-icon">🧾</div>
                <h3>Reparaciones</h3>
                <p>Da seguimiento al estado de cada solicitud de reparación.</p>
                <a href="/CapaVistas/Reparaciones.aspx">Ver reparaciones &rarr;</a>
            </div>
            <div class="feature-card">
                <div class="feature-icon">📌</div>
                <h3>Asignaciones</h3>
                <p>Asigna técnicos a cada reparación y controla las fechas.</p>
                <a href="/CapaVistas/Asignaciones.aspx">Ver asignaciones &rarr;</a>
            </div>
            <div class="feature-card">
                <div class="feature-icon">📋</div>
                <h3>Detalles de Reparación</h3>
                <p>Consulta la bitácora detallada de cada trabajo realizado.</p>
                <a href="/CapaVistas/DetallesReparacion.aspx">Ver detalles &rarr;</a>
            </div>
        </section>

    </form>
</body>
</html>
