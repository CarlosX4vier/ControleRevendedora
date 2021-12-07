using ControleRevendedora.Modelos;
using MySql.Data.EntityFramework;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ControleRevendedora.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class RevendedoraContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Kit> Kits { get; set; }
        public RevendedoraContext() : base(ConfigurationManager.ConnectionStrings["server"].ConnectionString)
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>()//.HasKey(a => new { a.Id, a.ProdutoID })
                                            .HasRequired<ProdutoBase>(s => s.Produto)
                                            .WithMany(g => g.Transacoes)
                                            .HasForeignKey(a => a.ProdutoID);

            modelBuilder.Entity<Kit>().HasMany<Produto>(x => x.KitProdutos)
                                      .WithMany(x => x.Kits);

            modelBuilder.Entity<ProdutoBase>().ToTable("Produtoes");

            base.OnModelCreating(modelBuilder);
        }

    }

    public static class DbSetExtensions
    {
        public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : class, new()
        {
            var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
            return !exists ? dbSet.Add(entity) : null;
        }
    }
}
