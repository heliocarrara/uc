
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/15/2021 09:46:28
-- Generated from EDMX file: C:\Users\helio\source\repos\uc\UC\Models\UCModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LoginSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoginSet];
GO
IF OBJECT_ID(N'[dbo].[PessoaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PessoaSet];
GO
IF OBJECT_ID(N'[dbo].[AlunoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AlunoSet];
GO
IF OBJECT_ID(N'[dbo].[CursoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CursoSet];
GO
IF OBJECT_ID(N'[dbo].[MinistranteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MinistranteSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LoginSet'
CREATE TABLE [dbo].[LoginSet] (
    [loginUID] int IDENTITY(1,1) NOT NULL,
    [login] nvarchar(max)  NOT NULL,
    [senha] nvarchar(max)  NOT NULL,
    [validade] datetime  NOT NULL,
    [pessoaUID] bigint  NOT NULL
);
GO

-- Creating table 'PessoaSet'
CREATE TABLE [dbo].[PessoaSet] (
    [pessoaUID] bigint IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [cpf] nvarchar(max)  NOT NULL,
    [nascimento] nvarchar(max)  NOT NULL,
    [endereco] nvarchar(max)  NOT NULL,
    [telefone] nvarchar(max)  NOT NULL,
    [nivelAcesso] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlunoSet'
CREATE TABLE [dbo].[AlunoSet] (
    [alunoUID] int IDENTITY(1,1) NOT NULL,
    [cursoUID] nvarchar(max)  NOT NULL,
    [pessoaUID] nvarchar(max)  NOT NULL,
    [ativo] bit  NOT NULL
);
GO

-- Creating table 'CursoSet'
CREATE TABLE [dbo].[CursoSet] (
    [cursoUID] int IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [cargaHoraria] bigint  NOT NULL,
    [turma] int  NOT NULL,
    [ativo] bit  NOT NULL
);
GO

-- Creating table 'MinistranteSet'
CREATE TABLE [dbo].[MinistranteSet] (
    [ministranteUID] int IDENTITY(1,1) NOT NULL,
    [cursoUID] nvarchar(max)  NOT NULL,
    [pessoaUID] nvarchar(max)  NOT NULL,
    [ativo] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [loginUID] in table 'LoginSet'
ALTER TABLE [dbo].[LoginSet]
ADD CONSTRAINT [PK_LoginSet]
    PRIMARY KEY CLUSTERED ([loginUID] ASC);
GO

-- Creating primary key on [pessoaUID] in table 'PessoaSet'
ALTER TABLE [dbo].[PessoaSet]
ADD CONSTRAINT [PK_PessoaSet]
    PRIMARY KEY CLUSTERED ([pessoaUID] ASC);
GO

-- Creating primary key on [alunoUID] in table 'AlunoSet'
ALTER TABLE [dbo].[AlunoSet]
ADD CONSTRAINT [PK_AlunoSet]
    PRIMARY KEY CLUSTERED ([alunoUID] ASC);
GO

-- Creating primary key on [cursoUID] in table 'CursoSet'
ALTER TABLE [dbo].[CursoSet]
ADD CONSTRAINT [PK_CursoSet]
    PRIMARY KEY CLUSTERED ([cursoUID] ASC);
GO

-- Creating primary key on [ministranteUID] in table 'MinistranteSet'
ALTER TABLE [dbo].[MinistranteSet]
ADD CONSTRAINT [PK_MinistranteSet]
    PRIMARY KEY CLUSTERED ([ministranteUID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------