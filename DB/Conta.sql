IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_InsConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_InsConta]
GO

CREATE PROCEDURE [dbo].[GKSSP_InsConta]
	@Nome		varchar(50),
	@IdUsuario	int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Inserir uma conta
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_InsConta] 'Itaú', 1

	*/

	BEGIN
	
		INSERT INTO [dbo].[Conta] (Nome, DataCadastro, IdUsuario)
			VALUES (@Nome, GETDATE(), @IdUsuario);

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelContas]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelContas]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelContas]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Selecionar todas as contas
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelContas]

	*/

	BEGIN
	
		SELECT IdConta, Nome, DataCadastro, u.Email
			FROM [dbo].[Conta] c
				INNER JOIN [dbo].[Usuario] u
					ON u.IdUsuario = c.IdUsuario;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelConta]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelConta]
	@IdConta int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Selecionar conta em específico
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelConta] 1

	*/

	BEGIN
	
		SELECT IdConta, Nome, DataCadastro, u.Email
			FROM [dbo].[Conta] c
				INNER JOIN [dbo].[Usuario] u
					ON u.IdUsuario = c.IdUsuario
			WHERE c.IdConta = @IdConta;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_UpdConta]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_UpdConta]
GO

CREATE PROCEDURE [dbo].[GKSSP_UpdConta]
	@IdConta	int,
	@Nome		varchar(50)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Conta.sql
	Objetivo..........: Atualizar uma conta
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_UpdConta] 1, 'Bradesco'

	*/

	BEGIN
	
		UPDATE [dbo].[Conta]
			SET Nome = @Nome
			WHERE IdConta = @IdConta;

	END
GO
