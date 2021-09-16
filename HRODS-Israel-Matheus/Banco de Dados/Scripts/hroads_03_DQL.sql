Use Senai_Hroads_Tarde;
Go

--Selecionar todos os personagens;
Select * From Personagem;
Go

--Selecionar todos as classes;
Select * From Classe;
Go

--Selecionar somente o nome das classes;
select Nome From Classe;
Go

--Selecionar todas as habilidades;
Select * From Habilidade;
Go

--Realizar a contagem de quantas habilidades estão cadastradas;
Select Count(Nome) From Habilidade;
Go

--Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
Select HabilidadeId From Habilidade Order By Habilidade.HabilidadeId ASC; 
Go

--Selecionar todos os tipos de habilidades;
Select * From TipoHabilidade;
Go

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;
Select Habilidade.Nome, TipoHabilidade.Nome From Habilidade Inner Join TipoHabilidade On Habilidade.TipoHabilidadeId = TipoHabilidade.TipoHabilidadeId;
Go

--Selecionar todos os personagens e suas respectivas classes;
Select Classe.Nome NomeDaClasse, Personagem.Nome NomePersonagem, CapacidadeMaximaVida, CapacidadeMaximaMana From Personagem Left Join Classe On Personagem.classeId = Classe.classeId;
Go

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);
Select Classe.Nome NomeDaClasse, Personagem.Nome NomePersonagem, CapacidadeMaximaVida, CapacidadeMaximaMana From Personagem Right Join Classe On Personagem.classeId = Classe.classeId;
Go

--Selecionar todas as classes e suas respectivas habilidades;
Select  Classe.Nome NomeClasse, Habilidade.Nome NomeHabilidade From ClasseHabilidade Right Join Classe On ClasseHabilidade.classeId = Classe.classeId Left Join Habilidade On ClasseHabilidade.HabilidadeId = Habilidade.HabilidadeId;
Go

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
Select Habilidade.Nome NomeHabilidade, Classe.Nome NomeClasse From ClasseHabilidade Inner Join Classe On ClasseHabilidade.classeId = Classe.classeId Inner Join Habilidade On ClasseHabilidade.HabilidadeId = Habilidade.HabilidadeId;
Go

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
Select Habilidade.Nome NomeHabilidade, Classe.Nome NomeClasse From ClasseHabilidade Right Join Classe On ClasseHabilidade.classeId = Classe.classeId Left Join Habilidade On ClasseHabilidade.HabilidadeId = Habilidade.HabilidadeId;
Go


