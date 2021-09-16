Create Database Senai_Hroads_Tarde;
Go

Use Senai_Hroads_Tarde;
Go

Create Table Classe (
classeId Tinyint Primary Key Identity,
Nome Varchar (20) Not Null
); 
Go

Create Table TipoHabilidade (
TipoHabilidadeId Tinyint Primary Key Identity,
Nome Varchar (20) Not Null
);
Go

Create Table Habilidade (
HabilidadeId Tinyint Primary Key Identity,
TipoHabilidadeId Tinyint Foreign Key References TipoHabilidade(TipoHabilidadeId),
Nome Varchar (20) Not Null
);
Go

Create Table ClasseHabilidade (
ClasseHabilidadeId Tinyint Primary Key Identity,
classeId Tinyint Foreign Key References Classe(classeId),
HabilidadeId Tinyint Foreign Key References Habilidade(HabilidadeId)
);
Go

Create Table Personagem (
PersonagemId Tinyint Primary Key Identity,
classeId Tinyint Foreign Key References Classe(ClasseId),
Nome Varchar (20) Not Null,
CapacidadeMaximaVida Tinyint Not Null,
CapacidadeMaximaMana Tinyint Not Null,
DataDeAtualização Datetime Not Null,
DataDeCriacao Datetime Not Null
);
go

create table TipoUsuario (
TipoUsuarioId tinyint primary key identity(1,1),
TituloTipoUsuario varchar(100) not null unique
);
go

create table Usuario (
UsuarioId int primary key identity(1,1),
TipoUsuarioId tinyint foreign key references TipoUsuario(TipoUsuarioId),
Email varchar(256) not null unique,
Senha varchar(150) not null
);
go

create table Player (
PlayerId int primary key identity(1,1),
PersonagemId Tinyint foreign key references Personagem(PersonagemId),
UsuarioId int foreign key references Usuario(UsuarioId)
);
go

