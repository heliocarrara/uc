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
    
        public DbSet<Meta> Metas { get; set; }
        public DbSet<SubTipoMeta> SubTipoMetas { get; set; }
        public DbSet<AnotacaoExecucaoMeta> AnotacaoExecucaoMetas { get; set; }
        public DbSet<RegistroSituacaoExecucaoMeta> RegistroSituacaoExecucaoMetas { get; set; }
        public DbSet<ChaveAtivacao> ChaveAtivacaos { get; set; }
        public DbSet<Permissao> Permissaos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AtividadeFixa> AtividadeFixas { get; set; }
        public DbSet<ExecucaoMeta> ExecucaoMetas { get; set; }
    }
}
