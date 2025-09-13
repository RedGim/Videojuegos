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

--use master