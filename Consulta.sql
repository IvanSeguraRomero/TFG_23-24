CREATE DATABASE flashgaminghub;

USE flashgaminghub;

CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    Contrasenya NVARCHAR(20),
    Edad INT,
    Email NVARCHAR(100),
    FechaRegistro DATETIME,
    Activo BIT
);

CREATE TABLE Studios (
    StudioID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Fundacion DATETIME,
    Pais NVARCHAR(50),
    EmailContacto NVARCHAR(100),
    Website NVARCHAR(100),
    Activo BIT
);

CREATE TABLE Juegos (
    JuegoID INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(1000),
    Precio DECIMAL(10,2),
    FechaLanzamiento DATETIME,
    Disponible BIT,
    StudioID INT,
    FOREIGN KEY (StudioID) REFERENCES Studios(StudioID)
);

CREATE TABLE BibliotecaJuegosUsuarios (
    UsuarioID INT,
    JuegoID INT,
    FechaAgregado DATETIME,
    Calificacion INT,
    HorasJugadas INT,
    UltimaVezJugado DATETIME,
    PRIMARY KEY (UsuarioID,JuegoID),
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (JuegoID) REFERENCES Juegos(JuegoID)
);

CREATE TABLE TiendaJuegos (
    TiendaID INT PRIMARY KEY,
    JuegoID INT,
    Precio DECIMAL(10,2),
    Descuento DECIMAL(5,2),
    Stock INT,
    VentasAnuales INT,
    FechaUltimaActualizacion DATETIME,
    Categorias NVARCHAR(100),
    Origen NVARCHAR(80),
    FOREIGN KEY (JuegoID) REFERENCES Juegos(JuegoID)
);

CREATE TABLE Comunidad (
    MensajeID INT PRIMARY KEY,
    UsuarioID INT,
    Mensaje NVARCHAR(1000),
    FechaPublicacion DATETIME,
    MiembroActivo BIT,
    CantidadLikes INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

-- Inserción de prueba para la tabla Usuarios
INSERT INTO Usuarios (UsuarioID, Nombre, Apellido, Contrasenya, Edad, Email, FechaRegistro, Activo)
VALUES 
    (1, 'Juan', 'Pérez', 'contraseña123', 25, 'juan@example.com', GETDATE(), 1),
    (2, 'María', 'González', 'maria456', 30, 'maria@example.com', GETDATE(), 1),
    (3, 'Carlos', 'López', 'clave123', 28, 'carlos@example.com', GETDATE(), 1);

-- Inserción de prueba para la tabla Studios
INSERT INTO Studios (StudioID, Nombre, Fundacion, Pais, EmailContacto, Website, Activo)
VALUES 
    (1, 'Studio A', '2000-01-01', 'Estados Unidos', 'studioa@example.com', 'http://www.studioa.com', 1),
    (2, 'Studio B', '1995-05-15', 'Reino Unido', 'studiob@example.com', 'http://www.studiob.com', 1),
    (3, 'Studio C', '2010-12-20', 'España', 'studioc@example.com', 'http://www.studioc.com', 1);

-- Inserción de prueba para la tabla Juegos
INSERT INTO Juegos (JuegoID, Nombre, Descripcion, Precio, FechaLanzamiento, Disponible, StudioID)
VALUES 
    (1, 'Juego 1', 'Descripción del juego 1', 29.99, '2023-07-01', 1, 1),
    (2, 'Juego 2', 'Descripción del juego 2', 19.99, '2022-05-15', 1, 2),
    (3, 'Juego 3', 'Descripción del juego 3', 39.99, '2024-02-10', 1, 3);

-- Inserción de prueba para la tabla BibliotecaJuegosUsuarios
INSERT INTO BibliotecaJuegosUsuarios (UsuarioID, JuegoID, FechaAgregado, Calificacion, HorasJugadas, UltimaVezJugado)
VALUES 
    (1, 1, GETDATE(), 4, 20, GETDATE()),
    (2, 2, GETDATE(), 5, 30, GETDATE()),
    (3, 3, GETDATE(), 3, 15, GETDATE());

-- Inserción de prueba para la tabla TiendaJuegos
INSERT INTO TiendaJuegos (TiendaID, JuegoID, Precio, Descuento, Stock, VentasAnuales, FechaUltimaActualizacion, Categorias, Origen)
VALUES 
    (1, 1, 29.99, 0, 100, 500, GETDATE(), 'Acción, Aventura', 'Francia'),
    (2, 2, 19.99, 0.1, 50, 200, GETDATE(), 'Estrategia, Simulación', 'Iran'),
    (3, 3, 39.99, 0.05, 80, 300, GETDATE(), 'Rol, Multijugador', 'Rusia');

-- Inserción de prueba para la tabla Comunidad
INSERT INTO Comunidad (MensajeID, UsuarioID, Mensaje, FechaPublicacion, MiembroActivo, CantidadLikes)
VALUES 
    (1, 1, '¡Hola a todos!', GETDATE(), 1, 10),
    (2, 2, '¿Alguien ha probado el nuevo juego?', GETDATE(), 1, 15),
    (3, 3, '¡Felicitaciones al equipo de desarrollo!', GETDATE(), 1, 20);


SELECT * FROM Usuarios;

SELECT * FROM Studios;

SELECT * FROM Juegos;

SELECT * FROM BibliotecaJuegosUsuarios;

SELECT * FROM TiendaJuegos;

SELECT * FROM Comunidad;

-- Eliminar la base de datos
USE master

DROP DATABASE flashgaminghub;
