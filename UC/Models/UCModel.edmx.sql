
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2022 20:02:01
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

IF OBJECT_ID(N'[dbo].[FK_Aluno_Turma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aluno] DROP CONSTRAINT [FK_Aluno_Turma];
GO
IF OBJECT_ID(N'[dbo].[FK_AlunoSet_PessoaSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aluno] DROP CONSTRAINT [FK_AlunoSet_PessoaSet];
GO
IF OBJECT_ID(N'[dbo].[FK_AtividadeAula_Aula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AtividadeAula] DROP CONSTRAINT [FK_AtividadeAula_Aula];
GO
IF OBJECT_ID(N'[dbo].[FK_Aula_Turma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Aula] DROP CONSTRAINT [FK_Aula_Turma];
GO
IF OBJECT_ID(N'[dbo].[FK_Autonomo_Pessoa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Autonomo] DROP CONSTRAINT [FK_Autonomo_Pessoa];
GO
IF OBJECT_ID(N'[dbo].[FK_Bolsista_Pessoa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bolsista] DROP CONSTRAINT [FK_Bolsista_Pessoa];
GO
IF OBJECT_ID(N'[dbo].[FK_Chamada_Aluno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Chamada] DROP CONSTRAINT [FK_Chamada_Aluno];
GO
IF OBJECT_ID(N'[dbo].[FK_Chamada_Aula]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Chamada] DROP CONSTRAINT [FK_Chamada_Aula];
GO
IF OBJECT_ID(N'[dbo].[FK_Coordenador_Pessoa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Coordenador] DROP CONSTRAINT [FK_Coordenador_Pessoa];
GO
IF OBJECT_ID(N'[dbo].[FK_DiaSemanaTurma_Turma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DiaSemanaTurma] DROP CONSTRAINT [FK_DiaSemanaTurma_Turma];
GO
IF OBJECT_ID(N'[dbo].[FK_JustificativaAula_Chamada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JustificativaAula] DROP CONSTRAINT [FK_JustificativaAula_Chamada];
GO
IF OBJECT_ID(N'[dbo].[FK_LoginSet_PessoaSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_LoginSet_PessoaSet];
GO
IF OBJECT_ID(N'[dbo].[FK_Permissao_Pessoa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissao] DROP CONSTRAINT [FK_Permissao_Pessoa];
GO
IF OBJECT_ID(N'[dbo].[FK_Professor_Pessoa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Professor] DROP CONSTRAINT [FK_Professor_Pessoa];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfessorTurma_Professor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessorTurma] DROP CONSTRAINT [FK_ProfessorTurma_Professor];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfessorTurma_Turma]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfessorTurma] DROP CONSTRAINT [FK_ProfessorTurma_Turma];
GO
IF OBJECT_ID(N'[dbo].[FK_Turma_Modalidade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Turma] DROP CONSTRAINT [FK_Turma_Modalidade];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aluno]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aluno];
GO
IF OBJECT_ID(N'[dbo].[AtividadeAula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AtividadeAula];
GO
IF OBJECT_ID(N'[dbo].[Aula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aula];
GO
IF OBJECT_ID(N'[dbo].[Autonomo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Autonomo];
GO
IF OBJECT_ID(N'[dbo].[Bolsista]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bolsista];
GO
IF OBJECT_ID(N'[dbo].[Chamada]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Chamada];
GO
IF OBJECT_ID(N'[dbo].[Coordenador]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Coordenador];
GO
IF OBJECT_ID(N'[dbo].[DiaSemanaTurma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DiaSemanaTurma];
GO
IF OBJECT_ID(N'[dbo].[JustificativaAula]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JustificativaAula];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[Modalidade]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modalidade];
GO
IF OBJECT_ID(N'[dbo].[Permissao]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissao];
GO
IF OBJECT_ID(N'[dbo].[Pessoa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pessoa];
GO
IF OBJECT_ID(N'[dbo].[Professor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Professor];
GO
IF OBJECT_ID(N'[dbo].[ProfessorTurma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfessorTurma];
GO
IF OBJECT_ID(N'[dbo].[Turma]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Turma];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alunoes'
CREATE TABLE [dbo].[Alunoes] (
    [alunoUID] bigint IDENTITY(1,1) NOT NULL,
    [turmaUID] bigint  NOT NULL,
    [pessoaUID] bigint  NOT NULL,
    [ativo] bit  NOT NULL,
    [dataCriacao] datetime  NOT NULL
);
GO

-- Creating table 'AtividadeAulas'
CREATE TABLE [dbo].[AtividadeAulas] (
    [atividadeaulaUID] bigint IDENTITY(1,1) NOT NULL,
    [ativa] bit  NOT NULL,
    [aulaUID] bigint  NOT NULL,
    [titulo] varchar(max)  NOT NULL,
    [descricao] varchar(max)  NOT NULL,
    [duracaoMin] int  NOT NULL,
    [aprovado] bit  NOT NULL,
    [ordem] int  NOT NULL
);
GO

-- Creating table 'Autonomoes'
CREATE TABLE [dbo].[Autonomoes] (
    [autonomoUID] bigint IDENTITY(1,1) NOT NULL,
    [pessoaUID] bigint  NOT NULL,
    [ativo] bit  NOT NULL,
    [validade] datetime  NOT NULL
);
GO

-- Creating table 'Coordenadors'
CREATE TABLE [dbo].[Coordenadors] (
    [coordenadorUID] bigint IDENTITY(1,1) NOT NULL,
    [ativo] bit  NOT NULL,
    [pessoaUID] bigint  NOT NULL
);
GO

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [loginUID] int IDENTITY(1,1) NOT NULL,
    [senha] nvarchar(max)  NOT NULL,
    [validade] datetime  NOT NULL,
    [pessoaUID] bigint  NOT NULL,
    [usuario] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Modalidades'
CREATE TABLE [dbo].[Modalidades] (
    [modalidadeUID] bigint IDENTITY(1,1) NOT NULL,
    [tipoModalidade] int  NOT NULL,
    [nome] varchar(max)  NOT NULL,
    [Descricao] varchar(max)  NOT NULL,
    [ValorInscrição] float  NOT NULL,
    [ValorMensalidade] float  NOT NULL,
    [ativa] bit  NOT NULL,
    [disponivel] bit  NOT NULL
);
GO

-- Creating table 'Permissaos'
CREATE TABLE [dbo].[Permissaos] (
    [permissaoUID] bigint IDENTITY(1,1) NOT NULL,
    [pessoaUID] bigint  NOT NULL,
    [tipoLogin] int  NOT NULL,
    [dataCriacao] datetime  NOT NULL,
    [validade] datetime  NOT NULL
);
GO

-- Creating table 'Pessoas'
CREATE TABLE [dbo].[Pessoas] (
    [pessoaUID] bigint IDENTITY(1,1) NOT NULL,
    [nome] nvarchar(max)  NOT NULL,
    [cpf] nvarchar(max)  NOT NULL,
    [nascimento] datetime  NOT NULL,
    [endereco] nvarchar(max)  NOT NULL,
    [telefone] nvarchar(max)  NOT NULL,
    [nivelAcesso] int  NOT NULL
);
GO

-- Creating table 'Turmas'
CREATE TABLE [dbo].[Turmas] (
    [turmaUID] bigint IDENTITY(1,1) NOT NULL,
    [modalidadeUID] bigint  NOT NULL,
    [ativa] bit  NOT NULL,
    [HorarioInicio] datetime  NOT NULL,
    [DuracaoAula] float  NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Vagas] int  NOT NULL,
    [disponivel] bit  NOT NULL
);
GO

-- Creating table 'Chamadas'
CREATE TABLE [dbo].[Chamadas] (
    [chamadaUID] bigint IDENTITY(1,1) NOT NULL,
    [aulaUID] bigint  NOT NULL,
    [alunoUID] bigint  NOT NULL,
    [presente] bit  NOT NULL,
    [ativa] bit  NOT NULL
);
GO

-- Creating table 'JustificativaAulas'
CREATE TABLE [dbo].[JustificativaAulas] (
    [justificativaaulaUID] bigint IDENTITY(1,1) NOT NULL,
    [chamadaUID] bigint  NOT NULL,
    [ativa] bit  NOT NULL,
    [justificativa] varchar(max)  NOT NULL,
    [aprovadaCoordenador] bit  NOT NULL
);
GO

-- Creating table 'DiaSemanaTurmas'
CREATE TABLE [dbo].[DiaSemanaTurmas] (
    [diasemanaturmaUID] bigint  NOT NULL,
    [ativo] bit  NOT NULL,
    [turmaUID] bigint  NOT NULL,
    [diaSemanal] int  NOT NULL
);
GO

-- Creating table 'Bolsistas'
CREATE TABLE [dbo].[Bolsistas] (
    [bolsistaUID] bigint IDENTITY(1,1) NOT NULL,
    [pessoaUID] bigint  NOT NULL,
    [dataCriacao] datetime  NOT NULL,
    [validade] datetime  NOT NULL,
    [ativo] bit  NOT NULL
);
GO

-- Creating table 'Aulas'
CREATE TABLE [dbo].[Aulas] (
    [aulaUID] bigint IDENTITY(1,1) NOT NULL,
    [dataRealizacao] datetime  NOT NULL,
    [turmaUID] bigint  NOT NULL,
    [ativa] bit  NOT NULL,
    [aulaExtra] bit  NOT NULL,
    [duracaoMin] int  NOT NULL
);
GO

-- Creating table 'Professors'
CREATE TABLE [dbo].[Professors] (
    [professorUID] bigint IDENTITY(1,1) NOT NULL,
    [ativo] bit  NOT NULL,
    [pessoaUID] bigint  NOT NULL,
    [dataCriacao] datetime  NOT NULL,
    [validade] datetime  NOT NULL
);
GO

-- Creating table 'ProfessorTurmas'
CREATE TABLE [dbo].[ProfessorTurmas] (
    [professorturmaUID] bigint IDENTITY(1,1) NOT NULL,
    [turmaUID] bigint  NOT NULL,
    [professorUID] bigint  NOT NULL,
    [ativo] bit  NOT NULL,
    [dataCriacao] datetime  NOT NULL,
    [validade] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [alunoUID] in table 'Alunoes'
ALTER TABLE [dbo].[Alunoes]
ADD CONSTRAINT [PK_Alunoes]
    PRIMARY KEY CLUSTERED ([alunoUID] ASC);
GO

-- Creating primary key on [atividadeaulaUID] in table 'AtividadeAulas'
ALTER TABLE [dbo].[AtividadeAulas]
ADD CONSTRAINT [PK_AtividadeAulas]
    PRIMARY KEY CLUSTERED ([atividadeaulaUID] ASC);
GO

-- Creating primary key on [autonomoUID] in table 'Autonomoes'
ALTER TABLE [dbo].[Autonomoes]
ADD CONSTRAINT [PK_Autonomoes]
    PRIMARY KEY CLUSTERED ([autonomoUID] ASC);
GO

-- Creating primary key on [coordenadorUID] in table 'Coordenadors'
ALTER TABLE [dbo].[Coordenadors]
ADD CONSTRAINT [PK_Coordenadors]
    PRIMARY KEY CLUSTERED ([coordenadorUID] ASC);
GO

-- Creating primary key on [loginUID] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([loginUID] ASC);
GO

-- Creating primary key on [modalidadeUID] in table 'Modalidades'
ALTER TABLE [dbo].[Modalidades]
ADD CONSTRAINT [PK_Modalidades]
    PRIMARY KEY CLUSTERED ([modalidadeUID] ASC);
GO

-- Creating primary key on [permissaoUID] in table 'Permissaos'
ALTER TABLE [dbo].[Permissaos]
ADD CONSTRAINT [PK_Permissaos]
    PRIMARY KEY CLUSTERED ([permissaoUID] ASC);
GO

-- Creating primary key on [pessoaUID] in table 'Pessoas'
ALTER TABLE [dbo].[Pessoas]
ADD CONSTRAINT [PK_Pessoas]
    PRIMARY KEY CLUSTERED ([pessoaUID] ASC);
GO

-- Creating primary key on [turmaUID] in table 'Turmas'
ALTER TABLE [dbo].[Turmas]
ADD CONSTRAINT [PK_Turmas]
    PRIMARY KEY CLUSTERED ([turmaUID] ASC);
GO

-- Creating primary key on [chamadaUID] in table 'Chamadas'
ALTER TABLE [dbo].[Chamadas]
ADD CONSTRAINT [PK_Chamadas]
    PRIMARY KEY CLUSTERED ([chamadaUID] ASC);
GO

-- Creating primary key on [justificativaaulaUID] in table 'JustificativaAulas'
ALTER TABLE [dbo].[JustificativaAulas]
ADD CONSTRAINT [PK_JustificativaAulas]
    PRIMARY KEY CLUSTERED ([justificativaaulaUID] ASC);
GO

-- Creating primary key on [diasemanaturmaUID] in table 'DiaSemanaTurmas'
ALTER TABLE [dbo].[DiaSemanaTurmas]
ADD CONSTRAINT [PK_DiaSemanaTurmas]
    PRIMARY KEY CLUSTERED ([diasemanaturmaUID] ASC);
GO

-- Creating primary key on [bolsistaUID] in table 'Bolsistas'
ALTER TABLE [dbo].[Bolsistas]
ADD CONSTRAINT [PK_Bolsistas]
    PRIMARY KEY CLUSTERED ([bolsistaUID] ASC);
GO

-- Creating primary key on [aulaUID] in table 'Aulas'
ALTER TABLE [dbo].[Aulas]
ADD CONSTRAINT [PK_Aulas]
    PRIMARY KEY CLUSTERED ([aulaUID] ASC);
GO

-- Creating primary key on [professorUID] in table 'Professors'
ALTER TABLE [dbo].[Professors]
ADD CONSTRAINT [PK_Professors]
    PRIMARY KEY CLUSTERED ([professorUID] ASC);
GO

-- Creating primary key on [professorturmaUID] in table 'ProfessorTurmas'
ALTER TABLE [dbo].[ProfessorTurmas]
ADD CONSTRAINT [PK_ProfessorTurmas]
    PRIMARY KEY CLUSTERED ([professorturmaUID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [turmaUID] in table 'Alunoes'
ALTER TABLE [dbo].[Alunoes]
ADD CONSTRAINT [FK_Aluno_Turma]
    FOREIGN KEY ([turmaUID])
    REFERENCES [dbo].[Turmas]
        ([turmaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Aluno_Turma'
CREATE INDEX [IX_FK_Aluno_Turma]
ON [dbo].[Alunoes]
    ([turmaUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Alunoes'
ALTER TABLE [dbo].[Alunoes]
ADD CONSTRAINT [FK_AlunoSet_PessoaSet]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlunoSet_PessoaSet'
CREATE INDEX [IX_FK_AlunoSet_PessoaSet]
ON [dbo].[Alunoes]
    ([pessoaUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Autonomoes'
ALTER TABLE [dbo].[Autonomoes]
ADD CONSTRAINT [FK_Autonomo_Pessoa]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Autonomo_Pessoa'
CREATE INDEX [IX_FK_Autonomo_Pessoa]
ON [dbo].[Autonomoes]
    ([pessoaUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Coordenadors'
ALTER TABLE [dbo].[Coordenadors]
ADD CONSTRAINT [FK_Coordenador_Pessoa]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Coordenador_Pessoa'
CREATE INDEX [IX_FK_Coordenador_Pessoa]
ON [dbo].[Coordenadors]
    ([pessoaUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [FK_LoginSet_PessoaSet]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoginSet_PessoaSet'
CREATE INDEX [IX_FK_LoginSet_PessoaSet]
ON [dbo].[Logins]
    ([pessoaUID]);
GO

-- Creating foreign key on [modalidadeUID] in table 'Turmas'
ALTER TABLE [dbo].[Turmas]
ADD CONSTRAINT [FK_Turma_Modalidade]
    FOREIGN KEY ([modalidadeUID])
    REFERENCES [dbo].[Modalidades]
        ([modalidadeUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Turma_Modalidade'
CREATE INDEX [IX_FK_Turma_Modalidade]
ON [dbo].[Turmas]
    ([modalidadeUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Permissaos'
ALTER TABLE [dbo].[Permissaos]
ADD CONSTRAINT [FK_Permissao_Pessoa]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Permissao_Pessoa'
CREATE INDEX [IX_FK_Permissao_Pessoa]
ON [dbo].[Permissaos]
    ([pessoaUID]);
GO

-- Creating foreign key on [alunoUID] in table 'Chamadas'
ALTER TABLE [dbo].[Chamadas]
ADD CONSTRAINT [FK_Chamada_Aluno]
    FOREIGN KEY ([alunoUID])
    REFERENCES [dbo].[Alunoes]
        ([alunoUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Chamada_Aluno'
CREATE INDEX [IX_FK_Chamada_Aluno]
ON [dbo].[Chamadas]
    ([alunoUID]);
GO

-- Creating foreign key on [chamadaUID] in table 'JustificativaAulas'
ALTER TABLE [dbo].[JustificativaAulas]
ADD CONSTRAINT [FK_JustificativaAula_Chamada]
    FOREIGN KEY ([chamadaUID])
    REFERENCES [dbo].[Chamadas]
        ([chamadaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JustificativaAula_Chamada'
CREATE INDEX [IX_FK_JustificativaAula_Chamada]
ON [dbo].[JustificativaAulas]
    ([chamadaUID]);
GO

-- Creating foreign key on [turmaUID] in table 'DiaSemanaTurmas'
ALTER TABLE [dbo].[DiaSemanaTurmas]
ADD CONSTRAINT [FK_DiaSemanaTurma_Turma]
    FOREIGN KEY ([turmaUID])
    REFERENCES [dbo].[Turmas]
        ([turmaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DiaSemanaTurma_Turma'
CREATE INDEX [IX_FK_DiaSemanaTurma_Turma]
ON [dbo].[DiaSemanaTurmas]
    ([turmaUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Bolsistas'
ALTER TABLE [dbo].[Bolsistas]
ADD CONSTRAINT [FK_Bolsista_Pessoa]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Bolsista_Pessoa'
CREATE INDEX [IX_FK_Bolsista_Pessoa]
ON [dbo].[Bolsistas]
    ([pessoaUID]);
GO

-- Creating foreign key on [aulaUID] in table 'AtividadeAulas'
ALTER TABLE [dbo].[AtividadeAulas]
ADD CONSTRAINT [FK_AtividadeAula_Aula]
    FOREIGN KEY ([aulaUID])
    REFERENCES [dbo].[Aulas]
        ([aulaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AtividadeAula_Aula'
CREATE INDEX [IX_FK_AtividadeAula_Aula]
ON [dbo].[AtividadeAulas]
    ([aulaUID]);
GO

-- Creating foreign key on [turmaUID] in table 'Aulas'
ALTER TABLE [dbo].[Aulas]
ADD CONSTRAINT [FK_Aula_Turma]
    FOREIGN KEY ([turmaUID])
    REFERENCES [dbo].[Turmas]
        ([turmaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Aula_Turma'
CREATE INDEX [IX_FK_Aula_Turma]
ON [dbo].[Aulas]
    ([turmaUID]);
GO

-- Creating foreign key on [aulaUID] in table 'Chamadas'
ALTER TABLE [dbo].[Chamadas]
ADD CONSTRAINT [FK_Chamada_Aula]
    FOREIGN KEY ([aulaUID])
    REFERENCES [dbo].[Aulas]
        ([aulaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Chamada_Aula'
CREATE INDEX [IX_FK_Chamada_Aula]
ON [dbo].[Chamadas]
    ([aulaUID]);
GO

-- Creating foreign key on [pessoaUID] in table 'Professors'
ALTER TABLE [dbo].[Professors]
ADD CONSTRAINT [FK_Professor_Pessoa]
    FOREIGN KEY ([pessoaUID])
    REFERENCES [dbo].[Pessoas]
        ([pessoaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Professor_Pessoa'
CREATE INDEX [IX_FK_Professor_Pessoa]
ON [dbo].[Professors]
    ([pessoaUID]);
GO

-- Creating foreign key on [professorUID] in table 'ProfessorTurmas'
ALTER TABLE [dbo].[ProfessorTurmas]
ADD CONSTRAINT [FK_ProfessorTurma_Professor]
    FOREIGN KEY ([professorUID])
    REFERENCES [dbo].[Professors]
        ([professorUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorTurma_Professor'
CREATE INDEX [IX_FK_ProfessorTurma_Professor]
ON [dbo].[ProfessorTurmas]
    ([professorUID]);
GO

-- Creating foreign key on [turmaUID] in table 'ProfessorTurmas'
ALTER TABLE [dbo].[ProfessorTurmas]
ADD CONSTRAINT [FK_ProfessorTurma_Turma]
    FOREIGN KEY ([turmaUID])
    REFERENCES [dbo].[Turmas]
        ([turmaUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfessorTurma_Turma'
CREATE INDEX [IX_FK_ProfessorTurma_Turma]
ON [dbo].[ProfessorTurmas]
    ([turmaUID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------