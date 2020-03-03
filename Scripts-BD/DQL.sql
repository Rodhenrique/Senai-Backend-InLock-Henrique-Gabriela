USE T_InLock_Games_Tarde;

--LISTAR TODOS OS USUARIOS
SELECT * FROM Usuarios;

--LISTAR TODOS OS ESTUDIOS
SELECT * FROM Estudios;

--LISTAR TODOS OS JOGOS
SELECT * FROM Jogos;

 --LISTAR TODOS JOGOS COM SEUS ESTUDIOS RELACIONANDO
SELECT Jogos.IdEstudio,NomeJogo,Estudios.NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio;

--LISTAR TODOS OS ESTUDIOS E JOGOS RELACIONADOS A AO ESTUDIO MESMO OS QUE NÃO TEM JOGOS 
SELECT  Estudios.NomeEstudio,IdJogo,NomeJogo,Descricao,DataLancamento,Valor FROM Jogos RIGHT OUTER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio;

SELECT IdJogo,NomeJogo,Descricao,DataLancamento,Valor,Jogos.IdEstudio,Estudios.IdEstudio,NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio;
 
 --BUSCAR UM USUARIO PELO EMAIL E SENHA
SELECT Usuarios.IdTipoUsuario,Nome,Email,Senha,TipoUsuario.Titulo FROM Usuarios INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuarios.IdTipoUsuario WHERE Email = 'admin@admin.com' AND Senha = 'admin';

--BUSCAR UM JOGO PELO ID
SELECT * FROM Jogos WHERE IdJogo = 1;

--BUSCAR UM ESTUDIO PELO ID
SELECT * FROM Estudios WHERE IdEstudio = 1;

INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio) VALUES(@Nome,@descricao,@dataLancamento,@valor,@idEstudio)

SELECT Estudios.NomeEstudio,NomeJogo FROM Jogos RIGHT OUTER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio


