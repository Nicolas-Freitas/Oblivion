CREATE DATABASE Emprego;
Go

USE Emprego;
GO 

CREATE TABLE TipoUsuario(
		idTipoUsuario INT PRIMARY KEY,
		tituloTipoUsuario VARCHAR(200)
);

GO
CREATE TABLE Usuario(
		idUsuario INT PRIMARY KEY,
		idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
		nomeUsuario VARCHAR(200) NOT NULL,
		senhaUsuario VARCHAR(200) NOT NULL,
		email VARCHAR(200)
);
GO

CREATE TABLE Aluno(
		idAluno INT PRIMARY KEY,
		idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
		numeroMatricula VARCHAR(200),
		curso VARCHAR(200),
		CPF VARCHAR(200) NOT NULL,
		dataNascimento DATE,
		curriculo VARBINARY(MAX)
);
GO

CREATE TABLE Empresa(
		idEmpresa INT PRIMARY KEY,
		idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
		CNPJ  VARCHAR(200),
		CEP VARCHAR(200),
		contato VARCHAR(200),
		descricao VARCHAR(200),
		logo VARBINARY(MAX)
);
GO

CREATE TABLE FuncionarioEmpresa(
		idFuncionarioEmpresa INT PRIMARY KEY,
		idEmpresa INT FOREIGN KEY REFERENCES Empresa(idEmpresa),
		idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
		NumeroFuncionario INT
);
GO

CREATE TABLE Vaga(
		idVaga INT PRIMARY KEY,
		idEmpresa INT FOREIGN KEY REFERENCES Empresa(idEmpresa),
		idFuncionarioEmpresa INT FOREIGN KEY REFERENCES FuncionarioEmpresa(idFuncionarioEmpresa),
		nomeVaga VARCHAR(200),
		descricaoVaga VARCHAR(500),
		disponibilidadeVaga DATE,
		candidatosVaga INT
);
GO

CREATE TABLE Skill(
		idSkill INT PRIMARY KEY,
		idVaga INT FOREIGN KEY REFERENCES Vaga(idVaga),
		idAluno INT FOREIGN KEY REFERENCES Aluno(idAluno),
		nomeSkill VARCHAR(200)
);
GO

CREATE TABLE VagaSkill(
		idVagaSkill INT PRIMARY KEY,
		idVaga INT FOREIGN KEY REFERENCES Vaga(idVaga),
		idSkill INT FOREIGN KEY REFERENCES Skill(idSkill)
);
GO

CREATE TABLE AlunoSkill(
		idAlunoSkill INT PRIMARY KEY,
		idAluno INT FOREIGN KEY REFERENCES Aluno(idAluno),
		idSkill INT FOREIGN KEY REFERENCES Skill(idSkill)
);
GO

CREATE TABLE Inscricao(
		idInscricao INT PRIMARY KEY,
		idAluno INT FOREIGN KEY REFERENCES Aluno(idAluno),
		admicao BIT,
		descricao VARCHAR(500)
);
GO

CREATE TABLE Administrador(
	idAdministrador INT PRIMARY KEY,
	idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario)
); 



SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;
SELECT * FROM Aluno;
SELECT * FROM Empresa;
SELECT * FROM FuncionarioEmpresa;
SELECT * FROM AlunoSkill;
SELECT * FROM Inscricao;
SELECT * FROM Vaga;
SELECT * FROM VagaSkill;
