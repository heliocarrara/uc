﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UCDBContext : DbContext
    {
        public UCDBContext()
            : base("name=UCDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Aluno> Alunoes { get; set; }
        public DbSet<AtividadeAula> AtividadeAulas { get; set; }
        public DbSet<Aula> Aulas { get; set; }
        public DbSet<Autonomo> Autonomoes { get; set; }
        public DbSet<Bolsista> Bolsistas { get; set; }
        public DbSet<Chamada> Chamadas { get; set; }
        public DbSet<Coordenador> Coordenadors { get; set; }
        public DbSet<DiaSemanaTurma> DiaSemanaTurmas { get; set; }
        public DbSet<JustificativaAula> JustificativaAulas { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Permissao> Permissaos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ProfessorTurma> ProfessorTurmas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}
