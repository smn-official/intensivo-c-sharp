IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_InsAcao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_InsAcao]
GO

CREATE PROCEDURE [dbo].[GKSSP_InsAcao]
	@Nome	varchar(25)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Inserir uma ação
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_InsAcao] 'Aberto'

	*/

	BEGIN
	
		INSERT INTO [dbo].[Acao] (Nome)
			VALUES (@Nome);

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelAcoes]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelAcoes]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelAcoes]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Selecionar todas as ações
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelAcoes]

	*/

	BEGIN
	
		SELECT IdAcao, Nome
			FROM [dbo].[Acao];

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelAcao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelAcao]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelAcao]
	@IdAcao int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Selecionar uma ação em específico
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelAcao] 1

	*/

	BEGIN
	
		SELECT IdAcao, Nome
			FROM [dbo].[Acao]
			WHERE IdAcao = @IdAcao

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_UpdAcao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_UpdAcao]
GO

CREATE PROCEDURE [dbo].[GKSSP_UpdAcao]
	@IdAcao	int,
	@Nome	varchar(25)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Atualizar uma ação
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_UpdAcao] 1, 'Pago'

	*/

	BEGIN
	
		UPDATE [dbo].[Acao]
			SET Nome = @Nome
			WHERE IdAcao = @IdAcao;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_DelAcao]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_DelAcao]
GO

CREATE PROCEDURE [dbo].[GKSSP_DelAcao]
	@IdAcao	int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Deletar uma ação
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_DelAcao] 1

	*/

	BEGIN
	
		UPDATE [dbo].[Lancamentos]
			SET IdAcao = NULL
			WHERE IdAcao = @IdAcao;

		DELETE FROM [dbo].[Acao]
			WHERE IdAcao = @IdAcao;
	END
GO