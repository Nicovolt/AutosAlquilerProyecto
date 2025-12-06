USE master;
GO

-- Eliminar la base de datos si existe
IF EXISTS(SELECT name FROM sys.databases WHERE name = 'Autos')
BEGIN
    ALTER DATABASE Autos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE Autos;
END
GO

CREATE DATABASE Autos;
GO

USE Autos;
GO
CREATE TABLE Marca (
    idMarca INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(90) NOT NULL
);

CREATE TABLE Categoria (
    idCategoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(90) NOT NULL
);

create table Autos(
IdAuto int identity(1,1) primary key,
IdMarca int not null FOREIGN key references Marca(idMarca),
IdCategoria int not null FOREIGN key references Categoria(idCategoria),
NumPatente varchar(10) not null,
Modelo varchar(30) not null,
Anio int NOT NULL ,
Color varchar(15) not null,
Precio decimal(10,2) not null,
Activo TINYINT NOT NULL DEFAULT 0
)

CREATE TABLE Imagen (
    Id int IDENTITY(1,1) PRIMARY KEY,
    IdAuto int FOREIGN KEY REFERENCES Autos(idAuto),
    ImagenUrl varchar(1000) COLLATE Modern_Spanish_CI_AS NOT NULL,
    Activo TINYINT NOT NULL DEFAULT 0
);

SELECT * FROM Autos
insert into Categoria(nombre) values('Auto')
insert into Marca( nombre ) values('Fiat'),
insert into Autos(Modelo, Precio, IdMarca, IdCategoria, Anio, Color, NumPatente) values('gol',777,1,1,2008,'rojo','aa 111 aa')