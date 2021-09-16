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