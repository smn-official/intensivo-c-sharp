IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_InsCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_InsCategoria]
GO

CREATE PROCEDURE [dbo].[GKSSP_InsCategoria]
	@Nome	varchar(25)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Categoria.sql
	Objetivo..........: Inserir uma Categoria
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_InsCategoria] 'Lazer'

	*/

	BEGIN
	
		INSERT INTO [dbo].[Categoria] (Nome)
			VALUES (@Nome);

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelCategorias]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelCategorias]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelCategorias]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Selecionar todas as categorias
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelCategorias]

	*/

	BEGIN
	
		SELECT IdCategoria, Nome
			FROM [dbo].[Categoria];

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelCategoria]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelCategoria]
	@IdCategoria int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Selecionar categoria em específico
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelCategoria] 1

	*/

	BEGIN
	
		SELECT IdCategoria, Nome
			FROM [dbo].[Categoria]
			WHERE IdCategoria = @IdCategoria;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_UpdCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_UpdCategoria]
GO

CREATE PROCEDURE [dbo].[GKSSP_UpdCategoria]
	@IdCategoria	int,
	@Nome	varchar(25)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Atualizar uma categoria
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_UpdCategoria] 1, 'Comida'

	*/

	BEGIN
	
		UPDATE [dbo].[Categoria]
			SET Nome = @Nome
			WHERE IdCategoria = @IdCategoria;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_DelCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_DelCategoria]
GO

CREATE PROCEDURE [dbo].[GKSSP_DelCategoria]
	@IdCategoria		int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Acao.sql
	Objetivo..........: Deletar uma categoria
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_DelCategoria] 1, 2

	*/

	BEGIN
	
		DELETE FROM [dbo].[Lancamentos]
			WHERE IdCategoria = @IdCategoria;

		DELETE FROM [dbo].[Categoria]
			WHERE IdCategoria = @IdCategoria;
	END
GO