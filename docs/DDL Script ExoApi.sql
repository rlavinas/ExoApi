CREATE DATABASE ExoApi
GO

USE ExoApi
GO

CREATE TABLE Projetos (
    Id INT PRIMARY KEY IDENTITY,
    Nome VARCHAR(50) NOT NULL UNIQUE,
    Descricao VARCHAR(100) NOT NULL,
    Status INT NOT NULL,
	Dt_Inicio DATETIME NOT NULL,
	Dt_Fim DATETIME
)
GO

CREATE TABLE Atividades (
    Id INT PRIMARY KEY IDENTITY,
	IdProjeto INT FOREIGN KEY REFERENCES Projetos(Id),
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(100) NOT NULL,
	Dt_Inicio DATETIME NOT NULL,
	Dt_Fim DATETIME
)
GO

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Senha VARCHAR(20) NOT NULL
)
GO
