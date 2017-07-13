INSERT INTO [dbo].[Acao] (Nome)
	VALUES ('Despesa'), ('Receita');

INSERT INTO [dbo].[Categoria] (Nome)
	VALUES ('Lazer'), ('Serviços'), ('Eletrônicos'), ('Outros');

INSERT INTO [dbo].[Usuario] (Email, Senha, FG_Ativo)
	VALUES ('lucas.felix@smn.com.br', '123456', 1), ('zezinho@gmail.com', '24445', 1), ('maria@hotmail.com', '998776', 0);

INSERT INTO [dbo].[Conta] (Nome, DataCadastro, IdUsuario)
	VALUES ('Itaú', GETDATE(), 1), ('Conta 00', GETDATE(), 2), ('Minhas Finanças', GETDATE(), 3);
	
-- Não queremos senhas descriptografadas no banco!
EXEC [dbo].[GKSSP_UpdUsuario] 1, 'lucas.felix@smn.com.br', '123456';
EXEC [dbo].[GKSSP_UpdUsuario] 2, 'zezinho@gmail.com', '24445';
EXEC [dbo].[GKSSP_UpdUsuario] 3, 'maria@hotmail.com', '998776';
