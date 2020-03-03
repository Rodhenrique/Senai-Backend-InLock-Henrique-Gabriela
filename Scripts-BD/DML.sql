USE T_InLock_Games_Tarde;

INSERT INTO TipoUsuario(Titulo)
VALUES('Administrador'),
('Cliente');

INSERT INTO Usuarios(Nome,Email,Senha,IdTipoUsuario)
VALUES('Administrador','admin@admin.com','admin',1),
('cliente','cliente@cliente.com','cliente',2);

INSERT INTO Estudios(NomeEstudio)
VALUES('Blizzard'),
('Rockstar Studios'),
('Square Enix');

INSERT INTO Jogos(NomeJogo,DataLancamento,Descricao,IdEstudio,Valor)
VALUES('Diablo 3','15/05/2012','É um jogo que contém bastante ação e é viciante,seja um novato ou um fã',1,120.00),
('Read Dead Redemption 2','26/10/2018','jogo eletrônico de ação-Aventura Western',2,99.00);