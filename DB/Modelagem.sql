CREATE TABLE Usuario(
	IdUsuario	INT IDENTITY,
	Email		VARCHAR(100) UNIQUE,
	Senha		NVARCHAR(6),
	FG_Ativo	BIT DEFAULT(1),
	CONSTRAINT pk_Usuario PRIMARY KEY(IdUsuario)
)

CREATE TABLE Categoria(
	IdCategoria	INT IDENTITY,
	Nome		VARCHAR(50),
	CONSTRAINT pk_Categoria PRIMARY KEY(IdCategoria)
)

CREATE TABLE Acao(
	IdAcao	INT IDENTITY,
	Nome	VARCHAR(25),
	CONSTRAINT pk_Acao PRIMARY KEY(IdAcao)
)

CREATE TABLE Conta(
	IdConta			INT IDENTITY,
	Nome			VARCHAR(50),
	DataCadastro	DATETIME,
	CONSTRAINT pk_Conta PRIMARY KEY(IdConta)
)

ALTER TABLE Conta
ADD IdUsuario INT

ALTER TABLE Conta
ADD CONSTRAINT fk_Conta_Usuario FOREIGN KEY(IdUsuario)
REFERENCES Usuario (IdUsuario)

ALTER TABLE Lancamentos
ADD FG_Pago BIT DEFAULT(0)

CREATE TABLE Lancamentos(
	IdLancamento	INT IDENTITY,
	DataEvento		DATETIME,
	DataCadastro	DATETIME,
	Descricao		VARCHAR(150),
	Valor		DECIMAL(8,2),
	IdCategoria		INT,
	IdAcao			INT, 
	IdConta			INT,
	CONSTRAINT pk_Lancamentos PRIMARY KEY(IdLancamento),
	CONSTRAINT fk_Lancamentos_Categoria FOREIGN KEY(IdCategoria)
	REFERENCES Categoria(IdCategoria),
	CONSTRAINT fk_Lancamentos_Acao FOREIGN KEY(IdAcao)
	REFERENCES Acao(IdAcao),
	CONSTRAINT fk_Lancamentos_Conta FOREIGN KEY(IdConta)
	REFERENCES Conta(IdConta)
)


