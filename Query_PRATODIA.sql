CREATE DATABASE PRATODIA;

USE PRATODIA;

CREATE TABLE Cliente(
	idCliente INT IDENTITY PRIMARY KEY NOT NULL,
	nomeCliente VARCHAR(100) NOT NULL,
	telefone VARCHAR(100) NOT NULL,
	endereco VARCHAR (100) NOT NULL
);

CREATE TABLE Prato(
	idPrato INT IDENTITY PRIMARY KEY NOT NULL,
	nomePrato VARCHAR(100) NOT NULL,
	diaPrato VARCHAR(100) NOT NULL,
	preco VARCHAR(100) NOT NULL,
	descricao VARCHAR (500) NOT NULL
);

CREATE TABLE Venda(
	idVenda INT IDENTITY PRIMARY KEY NOT NULL,
	idCliente INT FOREIGN KEY REFERENCES Cliente(idCliente),
	idPrato INT FOREIGN KEY REFERENCES Prato(idPrato)
);