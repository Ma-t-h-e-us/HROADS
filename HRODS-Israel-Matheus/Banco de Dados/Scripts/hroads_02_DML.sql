use Senai_Hroads_Tarde
go

insert into TipoHabilidade (Nome)
values ('Ataque'),('Defesa'),('Cura'),('Magia')
go

insert into Habilidade (TipoHabilidadeId, Nome)
values (1, 'Lança Mortal'), (2, 'Escudo Supremo'), (3, 'Recuperar Vida')
go

insert into Classe (Nome)
values ('Bárbaro'),('Cruzado'),('Caçadora de Demônios'),('Monge'),('Necromante'),('Feiticeiro'),('Arcanista')
go

insert into ClasseHabilidade (classeId, HabilidadeId)
values (1, 1), (1, 2), (2, 2), (3, 1), (4, 3), (4, 2), (6, 3)
go

insert into Personagem (classeId, Nome, CapacidadeMaximaVida, CapacidadeMaximaMana,  DataDeAtualização, DataDeCriacao) 
values (1, 'DeuBug', 100, 80, GETDATE(), '18/01/2019'),(4, 'BitBug', 70, 100, GETDATE(), '17/03/2016'),(7, 'Fer8', 75, 60, GETDATE(), '18/03/2018')
go

--Tarefas

Update Personagem 
Set Nome = 'Fer7' 
where PersonagemId = 3;
go

Update Classe 
Set Nome = 'Necromancer' 
where classeId = 5;

--Adição de Usuario, tipoUsuario e player
insert into TipoUsuario (TituloTipoUsuario)
values ('Administrador'), ('Jogador')
go

insert into Usuario (TipoUsuarioId, Email, Senha)
values (1, 'adm@gmail.com', 'adm123'), (2, 'jogador@gmail.com', 'jogador123')
go

insert into Player (PersonagemId, UsuarioId)
values (1, 2)
go