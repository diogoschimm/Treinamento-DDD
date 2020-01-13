# Treinamento-DDD
Treinamento de DDD (Domain Driven Design)

## Modelo de dados

Sistema para gerenciamento de pedidos de venda.

![image](https://user-images.githubusercontent.com/30643035/69024335-aec44a00-0998-11ea-9c77-b648ea8f288c.png)

## Script do Banco de Dados

```sql

  CREATE TABLE [dbo].[Clientes](
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Apelido] [varchar](20) NOT NULL,
    [Nome] [varchar](100) NOT NULL,
    [cpfCnpj] [varchar](14) NULL,
    [email] [varchar](100) NULL,
    [cep] [varchar](9) NULL,
    [endereco] [varchar](100) NULL,
    [numeroEndereco] [varchar](20) NULL,
    [bairro] [varchar](60) NULL,
    [cidade] [varchar](100) NULL,
    [uf] [varchar](2) NULL,
    [complemento] [varchar](100) NULL 
  )  
  GO 
  CREATE TABLE [dbo].[Fornecedores](
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Apelido] [varchar](20) NULL,
    [Nome] [varchar](100) NOT NULL,
    [cpfCnpj] [varchar](14) NULL,
    [email] [varchar](100) NULL,
    [cep] [varchar](9) NULL,
    [endereco] [varchar](100) NULL,
    [numeroEndereco] [varchar](20) NULL,
    [bairro] [varchar](60) NULL,
    [cidade] [varchar](100) NULL,
    [uf] [varchar](2) NULL,
    [complemento] [varchar](100) NULL
  ) 
  GO
  CREATE TABLE [dbo].[ItensPedido](
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [qtd] [int] NOT NULL,
    [idPedido] [int] NOT NULL,
    [idProduto] [int] NOT NULL
  )
  GO 
  CREATE TABLE [dbo].[Pedidos](
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [dataPedido] [datetime] NOT NULL,
    [dataEntrega] [datetime] NULL,
    [idCliente] [int] NOT NULL,
    [observacao] [varchar](500) NULL
  )
  GO
  CREATE TABLE [dbo].[Produtos](
    [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [apelido] [varchar](100) NOT NULL,
    [nomeProduto] [varchar](100) NOT NULL,
    [valor] [decimal](18, 2) NOT NULL,
    [unidade] [varchar](2) NOT NULL,
    [IdFornecedor] [int] NOT NULL
  )
  GO
  ALTER TABLE [dbo].[ItensPedido] 
  ADD CONSTRAINT [FK_ItensPedido_Pedidos_idPedido] FOREIGN KEY([idPedido]) REFERENCES [dbo].[Pedidos] ([Id])
  ON DELETE CASCADE
  GO
  ALTER TABLE [dbo].[ItensPedido] 
  ADD CONSTRAINT [FK_ItensPedido_Produtos_idProduto] FOREIGN KEY([idProduto]) REFERENCES [dbo].[Produtos] ([Id])
  ON DELETE CASCADE
  GO
  ALTER TABLE [dbo].[Pedidos] 
  ADD CONSTRAINT [FK_Pedidos_Clientes_idCliente] FOREIGN KEY([idCliente]) REFERENCES [dbo].[Clientes] ([Id])
  ON DELETE CASCADE
  GO
  ALTER TABLE [dbo].[Produtos] 
  ADD CONSTRAINT [FK_Produtos_Fornecedores_IdFornecedor] FOREIGN KEY([IdFornecedor]) REFERENCES [dbo].[Fornecedores] ([Id]) 
  ON DELETE CASCADE

```

 

