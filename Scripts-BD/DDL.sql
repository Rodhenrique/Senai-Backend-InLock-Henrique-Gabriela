CREATE DATABASE T_InLock_Games_Tarde;

USE T_InLock_Games_Tarde;

CREATE TABLE Estudios(
	IdEstudio INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR(255) NOT NULL,
);

CREATE TABLE Jogos(
	IdJogo INT PRIMARY KEY IDENTITY,
	NomeJogo VARCHAR(255) NOT NULL,
	Descricao TEXT NOT NULL,
	DataLancamento DATE NOT NULL,
	Valor DECIMAL NOT NULL,
	IdEstudio INT FOREIGN KEY REFERENCES Estudios(IdEstudio)
);

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(255) NOT NULL
);

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Senha VARCHAR(255) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario)
);


