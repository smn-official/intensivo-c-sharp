IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_InsUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_InsUsuario]
GO

CREATE PROCEDURE [dbo].[GKSSP_InsUsuario]
	@Email	varchar(25),
	@Senha	nvarchar(6)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Inserir um usuário
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_InsUsuario] 'lucas.felix@hotmail.com', '654321'

	*/

	BEGIN
	
		INSERT INTO [dbo].[Usuario] (Email, Senha, FG_Ativo)
			VALUES (@Email, CONVERT(NVARCHAR(6), HashBytes('MD5', @Senha), 2), 1);

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelUsuarios]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelUsuarios]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelUsuarios]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Selecionar todos os usuários
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelUsuarios]

	*/

	BEGIN
	
		SELECT	Email,	
				FG_Ativo
			FROM [dbo].[Usuario];

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelUsuario]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelUsuario]
	@IdUsuario int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Selecionar usuário em específico
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelUsuario] 1

	*/

	BEGIN
	
		SELECT	Email,	
				FG_Ativo
			FROM [dbo].[Usuario]
			WHERE IdUsuario = @IdUsuario;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_UpdUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_UpdUsuario]
GO

CREATE PROCEDURE [dbo].[GKSSP_UpdUsuario]
	@IdUsuario	int,
	@Email		varchar(25),
	@Senha		nvarchar(6)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Atualizar uma ação
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_UpdUsuario] 1, 'lucas.felix@smn.com.br', '123456'

	*/

	BEGIN
	
		UPDATE [dbo].[Usuario]
			SET Email = @Email,
				Senha = CONVERT(VARCHAR(6), HashBytes('MD5', @Senha), 2)
			WHERE IdUsuario = @IdUsuario;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_DelUsuario]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_DelUsuario]
GO

CREATE PROCEDURE [dbo].[GKSSP_DelUsuario]
	@IdUsuario	int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Usuario.sql
	Objetivo..........: Deletar (inativar) um usuário
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_DelUsuario] 1

	*/

	BEGIN
	
		UPDATE [dbo].[Usuario]
			SET FG_Ativo = 0
			WHERE IdUsuario = @IdUsuario;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSFNC_LogonUsuario]') AND objectproperty(id, N'IsScalarFunction')=1)
	DROP FUNCTION [dbo].[GKSFNC_LogonUsuario]
GO 

CREATE FUNCTION [dbo].[GKSFNC_LogonUsuario]
	(@Email varchar(100), @Senha nvarchar(6))

	RETURNS varchar(1) -- C (Correto), I (Incorreto)

	AS

	/*
	Documentação
	Arquivo Fonte.......: Usuario.sql
	Objetivo............: Verifica se o email e senha informados estão corretos para o usuário realizar o logon no site
	Autor...............: SMN - Lucas Felix Carvalho
 	Data................: 11/07/2017
	EX..................: SELECT [dbo].[GKSFNC_LogonUsuario]('lucas.felix@smn.com.br', '123456')
	*/
	BEGIN
		
		DECLARE @SenhaBD varchar(6) = '',
				@Retorno varchar(1) = 'I';

		SELECT @SenhaBD = Senha
			FROM [dbo].[Usuario]
			WHERE Email = @Email;

		IF @SenhaBD = CONVERT(VARCHAR(6), HashBytes('MD5', @Senha), 2)
			SET @Retorno = 'C'
		ELSE
			SET @Retorno = 'I'
		
		RETURN @Retorno;
	END
GO