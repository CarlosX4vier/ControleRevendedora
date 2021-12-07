using ControleRevendedora.Extensoes;
using ControleRevendedora.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ControleRevendedora.Contexto
{
    public class RevendedoraContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Kit> Kits { get; set; }

        public RevendedoraContext() : base()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conexao = this.GetConnectionString("server");
            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>()//.HasKey(a => new { a.Id, a.ProdutoID })
                                            .HasOne<ProdutoBase>(s => s.Produto)
                                            .WithMany(g => g.Transacoes)
                                            .HasForeignKey(a => a.ProdutoID)
                                            .IsRequired();

            modelBuilder.Entity<Kit>().HasMany<Produto>(x => x.KitProdutos)
                                      .WithMany(x => x.Kits);

            modelBuilder.Entity<ProdutoBase>().ToTable("Produtoes");

            base.OnModelCreating(modelBuilder);
        }

    }

    public static class DbSetExtensions
    {
        public static EntityEntry<T> AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return !exists ? dbSet.Add(entity) : null;
        }
    }
}
