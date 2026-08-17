/* ============================================================
   Base de datos: sistemaReparaciones
   Sistema de Gestión - Taller de Reparaciones
   Solicite a ChatGPT que genere este script para crear la base de datos y sus tablas con ejemplos******
   ============================================================ */

USE master;
GO

IF DB_ID('sistemaReparaciones') IS NOT NULL
BEGIN
    ALTER DATABASE sistemaReparaciones SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE sistemaReparaciones;
END
GO

CREATE DATABASE sistemaReparaciones;
GO

USE sistemaReparaciones;
GO

/* ============================================================
   Tabla: usuario
   Usada por el LOGIN (capalogica/usuario.cs -> validausuario)
   ============================================================ */
CREATE TABLE usuario
(
    UsuarioLoginID  INT IDENTITY(1,1) PRIMARY KEY,
    email           VARCHAR(100) NOT NULL UNIQUE,
    clave           VARCHAR(100) NOT NULL,
    nombre          VARCHAR(100) NOT NULL
);
GO

/* ============================================================
   Tabla: Usuarios
   Clientes que traen sus equipos al taller (Usuarios.aspx)
   ============================================================ */
CREATE TABLE Usuarios
(
    UsuarioID           INT IDENTITY(1,1) PRIMARY KEY,
    Nombre              VARCHAR(100) NOT NULL,
    CorreoElectronico   VARCHAR(100) NOT NULL,
    Telefono            VARCHAR(20)  NOT NULL
);
GO

/* ============================================================
   Tabla: Tecnicos (Tecnicos.aspx)
   ============================================================ */
CREATE TABLE Tecnicos
(
    TecnicoID     INT IDENTITY(1,1) PRIMARY KEY,
    Nombre        VARCHAR(50) NOT NULL,
    Especialidad  VARCHAR(50) NOT NULL
);
GO

/* ============================================================
   Tabla: Equipos (Equipos.aspx)
   ============================================================ */
CREATE TABLE Equipos
(
    EquipoID    INT IDENTITY(1,1) PRIMARY KEY,
    TipoEquipo  VARCHAR(50) NOT NULL,
    Modelo      VARCHAR(50) NOT NULL,
    UsuarioID   INT NOT NULL,
    CONSTRAINT FK_Equipos_Usuarios FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);
GO

/* ============================================================
   Tabla: Reparaciones (Reparaciones.aspx)
   ============================================================ */
CREATE TABLE Reparaciones
(
    ReparacionID    INT IDENTITY(1,1) PRIMARY KEY,
    EquipoID        INT NOT NULL,
    FechaSolicitud  DATETIME NOT NULL DEFAULT GETDATE(),
    Estado          VARCHAR(30) NOT NULL,
    CONSTRAINT FK_Reparaciones_Equipos FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID)
);
GO

/* ============================================================
   Tabla: Asignaciones (Asignaciones.aspx)
   ============================================================ */
CREATE TABLE Asignaciones
(
    AsignacionID     INT IDENTITY(1,1) PRIMARY KEY,
    ReparacionID     INT NOT NULL,
    TecnicoID        INT NOT NULL,
    FechaAsignacion  DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Asignaciones_Reparaciones FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID),
    CONSTRAINT FK_Asignaciones_Tecnicos FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID)
);
GO

/* ============================================================
   Tabla: DetallesReparacion (DetallesReparacion.aspx)
   ============================================================ */
CREATE TABLE DetallesReparacion
(
    DetalleID     INT IDENTITY(1,1) PRIMARY KEY,
    ReparacionID  INT NOT NULL,
    Descripcion   VARCHAR(255) NOT NULL,
    FechaInicio   DATETIME NOT NULL,
    FechaFin      DATETIME NULL,
    CONSTRAINT FK_Detalles_Reparaciones FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID)
);
GO

/* ============================================================
   Datos de ejemplo (opcional)
   ============================================================ */

-- Usuario para iniciar sesión (login)
INSERT INTO usuario (email, clave, nombre) VALUES
('admin@taller.com', '1234', 'Administrador');

-- Clientes del taller
INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono) VALUES
('Juan Pérez', 'juan.perez@correo.com', '8888-1111'),
('María Rojas', 'maria.rojas@correo.com', '8888-2222');

-- Técnicos
INSERT INTO Tecnicos (Nombre, Especialidad) VALUES
('Carlos Vindas', 'Hardware'),
('Ana Solano', 'Software');

-- Equipos ingresados
INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioID) VALUES
('Laptop', 'Dell Inspiron 15', 1),
('PC de escritorio', 'HP Pavilion', 2);

-- Reparaciones
INSERT INTO Reparaciones (EquipoID, FechaSolicitud, Estado) VALUES
(1, GETDATE(), 'Pendiente'),
(2, GETDATE(), 'En proceso');

-- Asignaciones de técnicos a reparaciones
INSERT INTO Asignaciones (ReparacionID, TecnicoID, FechaAsignacion) VALUES
(1, 1, GETDATE()),
(2, 2, GETDATE());

-- Detalles / bitácora de reparaciones
INSERT INTO DetallesReparacion (ReparacionID, Descripcion, FechaInicio, FechaFin) VALUES
(1, 'Revisión inicial del equipo, se detecta falla en disco duro.', GETDATE(), NULL),
(2, 'Reinstalación de sistema operativo y controladores.', GETDATE(), NULL);

GO
