CREATE DATABASE db_videojuegos
GO
USE db_videojuegos
GO
CREATE TABLE Paises(
	Id INT CONSTRAINT id_paises PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(85) UNIQUE NOT NULL
);
GO
CREATE TABLE Categorias (
	Id int CONSTRAINT id_categorias PRIMARY KEY IDENTITY(1,1), 
	Nombre NVARCHAR(50) NOT  NULL,
	Descripcion NVARCHAR(300)
);
GO
CREATE TABLE Plataformas (
	Id INT CONSTRAINT id_plataformas PRIMARY KEY IDENTITY(1,1), 
	Nombre NVARCHAR(30) NOT NULL,
);
GO
CREATE TABLE Roles (
	Id INT CONSTRAINT id_roles PRIMARY KEY IDENTITY (1,1),
	Nombre NVARCHAR(80) NOT NULL,
	Activo bit not null,
	Fecha_creacion DATETIME DEFAULT GETDATE()
);
GO
CREATE TABLE Clasificaciones (
	Id INT  CONSTRAINT id_clasificaiones PRIMARY KEY IDENTITY (1,1),
	Nombre NVARCHAR (30) NOT NULL,
	Edad INT NOT NULL,
);
GO
CREATE TABLE Desarrolladores ( 
	Id INT CONSTRAINT id_desarrolladores PRIMARY KEY IDENTITY(1,1), 
	NombreEstudio NVARCHAR(50) not null,
	Pais int not null, 
	Web NVARCHAR(80),
	CONSTRAINT desarrallo_paises FOREIGN KEY (Pais) REFERENCES Paises(Id),
);
GO
CREATE TABLE Usuarios (
	Id INT CONSTRAINT id_usuarios PRIMARY KEY IDENTITY (1,1),
	Nombre NVARCHAR(80) NOT NULL,
	Correo NVARCHAR (100) NOT NULL,
	Contrasena NVARCHAR (20) NOT NULL,
	Fecha_nacimiento DATE NOT NULL,
	Pais INT CONSTRAINT usuarios_paises FOREIGN KEY REFERENCES Paises (Id) NOT NULL
);
GO
CREATE TABLE Perfiles (
	Id INT IDENTITY (1,1) CONSTRAINT id_perfiles PRIMARY KEY,
	Nickname NVARCHAR (80) NOT NULL,
	Biografia VARCHAR (500),
	Usuario INT CONSTRAINT perfiles_usuarios FOREIGN KEY REFERENCES Usuarios (Id) NOT NULL
);
GO
CREATE TABLE Videojuegos (
	Id INT IDENTITY (1,1) constraint id_videojuegos PRIMARY KEY,
	Nombre NVARCHAR (80) NOT NULL,
	Descripcion NVARCHAR (1000) NOT NULL,
	Valor DECIMAL (10,2) NOT NULL,
	FechaLanzamiento DATETIME NOT NULL,
	clasificacion INT CONSTRAINT videojuegos_clasificaion FOREIGN KEY REFERENCES Clasificaciones(Id) NOT NULL,
	Desarrollador INT FOREIGN KEY REFERENCES Desarrolladores(Id) NOT NULL
);
GO
CREATE TABLE Usuarios_roles (
	Id INT CONSTRAINT id_usuarios_roles PRIMARY KEY IDENTITY (1,1),
	Usuario INT constraint usuarios_rol FOREIGN KEY REFERENCES Usuarios (Id)  NOT NULL,
	Rol INT constraint roles_usuario FOREIGN KEY REFERENCES Roles (Id)  NOT NULL,
	Activo BIT NOT NULL,
);
GO
create table Videojuegos_categorias (
	Id INT CONSTRAINT id_juegos_categorias PRIMARY KEY IDENTITY (1,1),
	VideoJuego INT CONSTRAINT juegos_categorias FOREIGN KEY REFERENCES Videojuegos(Id)  NOT NULL, 
	Categoria INT CONSTRAINT categorias_juego FOREIGN KEY REFERENCES Categorias(Id)  NOT NULL, 
);
GO
create table Videojuegos_plataformas (
	Id INT CONSTRAINT id_juegos_plataformas PRIMARY KEY IDENTITY (1,1),
	VideoJuego INT CONSTRAINT juegos_plataforma FOREIGN KEY REFERENCES Videojuegos(Id)  NOT NULL, 
	Plataforma INT CONSTRAINT plataformas_juego FOREIGN KEY REFERENCES Plataformas(Id)  NOT NULL,
);
GO
CREATE TABLE Bibliotecas(
	Id INT CONSTRAINT id_biblioteca PRIMARY KEY IDENTITY (1,1),
	Usuario INT CONSTRAINT usuario_biblioteca FOREIGN KEY REFERENCES Usuarios(Id)  NOT NULL ,
	VideoJuego INT CONSTRAINT juego_biblioteca FOREIGN KEY REFERENCES Videojuegos(Id) NOT NULL,
	FechaAdquisicion DATETIME NOT NULL DEFAULT GETDATE()
);	
GO
CREATE TABLE Resenas(
	Id INT CONSTRAINT id_resenas PRIMARY KEY IDENTITY (1,1),
	Usuario INT CONSTRAINT usuario_resenas FOREIGN KEY REFERENCES Usuarios(Id) NOT NULL,
	VideoJuego INT CONSTRAINT juego_resena REFERENCES Videojuegos(Id) NOT NULL,
	Calificacion DECIMAL(2,1) CONSTRAINT check_calificacion CHECK (Calificacion>= 1 AND Calificacion <= 5) NOT NULL,
	Comentario VARCHAR(5000) NOT NULL,
	Fecha DATETIME NOT NULL DEFAULT GETDATE()
);
GO
CREATE TABLE CarritoCompras(
	Id INT CONSTRAINT id_carrito PRIMARY KEY IDENTITY (1,1),
	Usuario INT CONSTRAINT usuario_carrito FOREIGN KEY REFERENCES Usuarios(Id) NOT NULL,
	FechaModificacIon DATETIME NOT NULL DEFAULT GETDATE(),
	Estado BIT NOT NULL,
);
GO
CREATE TABLE CarritoDetalles(
	Id INT  PRIMARY KEY IDENTITY (1,1),
	Carrito INT CONSTRAINT carrito_detalle_compras FOREIGN KEY REFERENCES CarritoCompras(Id) NOT NULL,
	VideoJuego INT CONSTRAINT juegos_detalles FOREIGN KEY REFERENCES Videojuegos(Id) NOT NULL,
	Cantidad INT NOT NULL CONSTRAINT check_cantidad CHECK (Cantidad > 0),
	Precio DECIMAL(12,2) NOT NULL CONSTRAINT check_precio CHECK (Precio>=0),
);
GO
CREATE TABLE Pagos(
	Id INT CONSTRAINT id_pagos PRIMARY KEY IDENTITY (1,1),
	Usuario INT CONSTRAINT pago_usuario FOREIGN KEY REFERENCES Usuarios(Id) NOT NULL,
	Monto DECIMAL(12,2) NOT NULL CONSTRAINT check_monto CHECK(Monto >= 0),
	MetodoPago NVARCHAR(100) NOT NULL,
	Fecha DATETIME NOT NULL DEFAULT GETDATE()
);

-- ==========================================
-- 1. PAISES
-- ==========================================
INSERT INTO Paises (Nombre) VALUES
('Estados Unidos'),
('Japón'),
('Canadá'),
('España'),
('Colombia');

-- ==========================================
-- 2. CATEGORIAS
-- ==========================================
INSERT INTO Categorias (Nombre, Descripcion) VALUES
('Acción', 'Juegos con mucha adrenalina y combate'),
('Aventura', 'Explora mundos abiertos y resuelve misiones'),
('Deportes', 'Simulaciones de deportes reales o ficticios'),
('Estrategia', 'Planeación táctica y toma de decisiones'),
('RPG', 'Juegos de rol con progresión de personaje');

-- ==========================================
-- 3. PLATAFORMAS
-- ==========================================
INSERT INTO Plataformas (Nombre) VALUES
('PC'),
('PlayStation 5'),
('Xbox Series X'),
('Nintendo Switch'),
('Steam Deck');

-- ==========================================
-- 4. ROLES
-- ==========================================
INSERT INTO Roles (Nombre, Activo) VALUES
('Administrador', 1),
('Moderador', 1),
('Desarrollador', 1),
('Jugador Premium', 1),
('Jugador', 1);

-- ==========================================
-- 5. CLASIFICACIONES
-- ==========================================
INSERT INTO Clasificaciones (Nombre, Edad) VALUES
('E', 6),
('T', 13),
('M', 17),
('AO', 18),
('RP', 0);

-- ==========================================
-- 6. DESARROLLADORES
-- ==========================================
INSERT INTO Desarrolladores (NombreEstudio, Pais, Web) VALUES
('Nintendo', 2, 'https://www.nintendo.com'),
('Rockstar Games', 1, 'https://www.rockstargames.com'),
('CD Projekt Red', 3, 'https://www.cdprojekt.com'),
('FromSoftware', 2, 'https://www.fromsoftware.jp'),
('Ubisoft', 4, 'https://www.ubisoft.com');

-- ==========================================
-- 7. USUARIOS
-- ==========================================
INSERT INTO Usuarios (Nombre, Correo, Contrasena, Fecha_nacimiento, Pais) VALUES
('Juan Perez', 'juanperez@mail.com', '12345', '1995-06-12', 5),
('Maria Lopez', 'marialopez@mail.com', 'abcde', '2000-01-25', 4),
('Carlos Gomez', 'carlosg@mail.com', 'pass123', '1988-10-05', 1),
('Ana Torres', 'ana_t@mail.com', 'qwerty', '1999-03-15', 2),
('Luis Rodriguez', 'luisr@mail.com', 'secure1', '1992-12-20', 3);

-- ==========================================
-- 8. PERFILES
-- ==========================================
INSERT INTO Perfiles (Nickname, Biografia, Usuario) VALUES
('JuanPlay', 'Amante de los RPG y aventuras', 1),
('MaryGamer', 'Fanática de juegos de plataformas', 2),
('Carlitos88', 'Jugador competitivo de shooters', 3),
('AnaT', 'Me encanta explorar mundos abiertos', 4),
('LRod', 'Amante de los juegos de estrategia', 5);

-- ==========================================
-- 9. VIDEOJUEGOS
-- ==========================================
INSERT INTO Videojuegos (Nombre, Descripcion, Valor, FechaLanzamiento, clasificacion, Desarrollador) VALUES
('The Legend of Zelda: TOTK', 'Explora Hyrule en una nueva aventura', 69.99, '2023-05-12', 2, 1),
('Grand Theft Auto V', 'Acción y mundo abierto en Los Santos', 29.99, '2013-09-17', 3, 2),
('The Witcher 3', 'Caza monstruos en un mundo abierto lleno de historia', 39.99, '2015-05-19', 3, 3),
('Elden Ring', 'Explora las Tierras Intermedias y derrota a jefes épicos', 59.99, '2022-02-25', 3, 4),
('Assassin''s Creed Valhalla', 'Conviértete en un vikingo en Inglaterra', 49.99, '2020-11-10', 3, 5);

-- ==========================================
-- 10. USUARIOS_ROLES
-- ==========================================
INSERT INTO Usuarios_roles (Usuario, Rol, Activo) VALUES
(1, 5, 1),
(2, 4, 1),
(3, 2, 1),
(4, 3, 1),
(5, 1, 1);

-- ==========================================
-- 11. VIDEOJUEGOS_CATEGORIAS
-- ==========================================
INSERT INTO Videojuegos_categorias (VideoJuego, Categoria) VALUES
(1, 2),
(2, 1),
(3, 5),
(4, 5),
(5, 2);

-- ==========================================
-- 12. VIDEOJUEGOS_PLATAFORMAS
-- ==========================================
INSERT INTO Videojuegos_plataformas (VideoJuego, Plataforma) VALUES
(1, 4),
(2, 2),
(3, 1),
(4, 1),
(5, 3);

-- ==========================================
-- 13. BIBLIOTECAS
-- ==========================================
INSERT INTO Bibliotecas (Usuario, VideoJuego) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);

-- ==========================================
-- 14. RESENAS
-- ==========================================
INSERT INTO Resenas (Usuario, VideoJuego, Calificacion, Comentario) VALUES
(1, 1, 4.5, 'Increíble juego de aventura'),
(2, 2, 5.0, 'Clásico imperdible'),
(3, 3, 4.0, 'Excelente historia'),
(4, 4, 4.8, 'Desafiante y emocionante'),
(5, 5, 4.3, 'Gran juego de mundo abierto');

-- ==========================================
-- 15. CARRITOCOMPRAS
-- ==========================================
INSERT INTO CarritoCompras (Usuario, Estado) VALUES
(1, 1),
(2, 0),
(3, 1),
(4, 0),
(5, 1);

-- ==========================================
-- 16. CARRITODETALLES
-- ==========================================
INSERT INTO CarritoDetalles (Carrito, VideoJuego, Cantidad, Precio) VALUES
(1, 2, 1, 29.99),
(3, 4, 1, 59.99),
(3, 5, 2, 49.99),
(5, 3, 1, 39.99),
(5, 1, 1, 69.99);

-- ==========================================
-- 17. PAGOS
-- ==========================================
INSERT INTO Pagos (Usuario, Monto, MetodoPago) VALUES
(1, 29.99, 'Tarjeta de Crédito'),
(2, 0.00, 'Saldo en cuenta'),
(3, 149.97, 'PayPal'),
(4, 0.00, 'Efectivo'),
(5, 109.98, 'Tarjeta de Débito');
