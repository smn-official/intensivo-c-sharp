IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_InsLancamento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_InsLancamento]
GO

CREATE PROCEDURE [dbo].[GKSSP_InsLancamento]
	@DataEvento		datetime,
	@Descricao		varchar(150),
	@IdCategoria	int,
	@IdAcao			int,
	@IdConta		int,
	@Valor			decimal(8,2)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Inserir um lançamento
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_InsLancamento] '2017-07-11', 'Cinema - Thor Ragnarok', 2, 2, 1, 50

	*/

	BEGIN
	
		INSERT INTO [dbo].[Lancamentos] (DataEvento, DataCadastro, Descricao, Valor, IdCategoria, IdAcao, IdConta)
			VALUES (@DataEvento, GETDATE(), @Descricao, @Valor, @IdCategoria, @IdAcao, @IdConta);

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelLancamentos]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelLancamentos]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelLancamentos]

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Selecionar todos lançamentos
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelLancamentos]

	*/

	BEGIN
	
		SELECT l.IdLancamento, l.DataEvento, l.DataCadastro, l.Valor, l.Descricao, c.Nome AS 'Categoria', co.Nome AS 'Conta', u.Email AS 'Usuário'
			FROM [dbo].[Lancamentos] l
				LEFT OUTER JOIN [dbo].[Categoria] c
					ON c.IdCategoria = l.IdCategoria
				LEFT OUTER JOIN [dbo].[Acao] a
					ON a.IdAcao = l.IdAcao
				LEFT OUTER JOIN [dbo].[Conta] co
					ON co.IdConta = l.IdConta
				LEFT OUTER JOIN [dbo].[Usuario] u
					ON u.IdUsuario = co.IdUsuario

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelLancamento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelLancamento]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelLancamento]
	@IdLancamento int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Selecionar lançamento em específico
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelLancamento] 1

	*/

	BEGIN
	
		SELECT l.IdLancamento, l.DataEvento, l.DataCadastro, l.Valor, l.Descricao, c.Nome AS 'Categoria', co.Nome AS 'Conta', u.Email AS 'Usuário'
			FROM [dbo].[Lancamentos] l
				LEFT OUTER JOIN [dbo].[Categoria] c
					ON c.IdCategoria = l.IdCategoria
				LEFT OUTER JOIN [dbo].[Acao] a
					ON a.IdAcao = l.IdAcao
				LEFT OUTER JOIN [dbo].[Conta] co
					ON co.IdConta = l.IdConta
				LEFT OUTER JOIN [dbo].[Usuario] u
					ON u.IdUsuario = co.IdUsuario
			WHERE l.IdLancamento = @IdLancamento;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_UpdLancamento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_UpdLancamento]
GO

CREATE PROCEDURE [dbo].[GKSSP_UpdLancamento]
	@IdLancamento	int,
	@DataEvento		datetime,
	@Descricao		varchar(150),
	@IdCategoria	int,
	@IdAcao			int,
	@IdConta		int,
	@Valor			decimal(8,2)

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Atualizar uma ação
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_UpdLancamento] 3, '2017-06-10', 'Cinema - Homem Aranha De Volta Ao Lar', 2, 2, 1, 35

	*/

	BEGIN
	
		UPDATE [dbo].[Lancamentos]
			SET DataEvento	= @DataEvento,
				Descricao	= @Descricao,
				IdCategoria	= @IdCategoria,
				IdAcao		= @IdAcao,
				IdConta		= @IdConta,
				Valor		= @Valor
			WHERE IdLancamento = @IdLancamento;

	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_DelLancamento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_DelLancamento]
GO

CREATE PROCEDURE [dbo].[GKSSP_DelLancamento]
	@IdLancamento	int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Deletar um lançamento
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_DelLancamento] 3

	*/

	BEGIN
	
		DELETE FROM [dbo].[Lancamentos]
			WHERE IdLancamento = @IdLancamento;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelSaldos]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelSaldos]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelSaldos]
	@DataInicial	datetime,
	@DataFinal		datetime,
	@IdConta		int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Selecionar os saldos (recebido, pago, lançamento futuro, aberto) da conta e no prazo informado
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelSaldos] '2017-07-11', '2017-07-12', 1

	*/

	BEGIN
	
		SELECT	SUM(l.Valor) AS 'Soma',
				a.Nome AS 'Ação'
			FROM [dbo].[Lancamentos] l 
				LEFT OUTER JOIN [dbo].[Acao] a
					ON a.IdAcao = l.IdAcao
			WHERE l.DataEvento BETWEEN @DataInicial AND @DataFinal
				AND l.IdConta = @IdConta
			GROUP BY a.Nome;
	END
GO

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[GKSSP_SelSaldoEspecifico]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[GKSSP_SelSaldoEspecifico]
GO

CREATE PROCEDURE [dbo].[GKSSP_SelSaldoEspecifico]
	@DataInicial	datetime,
	@DataFinal		datetime,
	@IdConta		int,
	@IdAcao			int

	AS

	/*
	Documentação
	Arquivo Fonte.....: Lancamentos.sql
	Objetivo..........: Selecionar a soma de lançamentos recebidos da conta, ação e no prazo informado
	Autor.............: SMN - Lucas Felix Carvalho
 	Data..............: 11/07/2017
	Ex................: EXEC [dbo].[GKSSP_SelSaldoEspecifico] '2017-07-11', '2017-07-12', 1, 1

	*/

	BEGIN
	
		SELECT	SUM(l.Valor) AS 'Soma',
				a.Nome
			FROM [dbo].[Lancamentos] l 
				INNER JOIN [dbo].[Acao] a
					ON a.IdAcao = l.IdAcao
			WHERE l.DataEvento BETWEEN @DataInicial AND @DataFinal
				AND l.IdConta = @IdConta
				AND l.IdAcao = @IdAcao
			GROUP BY a.Nome;
	END
GO
