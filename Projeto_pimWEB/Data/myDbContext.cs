using Microsoft.EntityFrameworkCore;
using Projeto_pimWEB.Models.Classes;

namespace Projeto_pimWEB.Data
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> op): base(op) 
        {
        }
        public DbSet<Funcionario> funcionarios { get; set; }
        public DbSet<Folha_Pagamento> folha_pagamento { get; set; }
        public DbSet<Desconto> descontos { get; set; }
        public DbSet<Beneficio> beneficios { get; set; }
        public DbSet<Dependente> dependentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Folha_Pagamento>()
                .HasOne(f => f.Funcionario)
                .WithMany(f => f.Folhas)
                .HasForeignKey(f => f.id_cod_func)
                .IsRequired();

            modelBuilder.Entity<Dependente>()
                .HasOne(x => x.funcionario);

            base.OnModelCreating(modelBuilder);
        }
    }   
}
