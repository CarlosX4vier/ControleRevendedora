using ControleRevendedora.Modelos;
using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControleRevendedora.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class RevendedoraContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        public RevendedoraContext() : base(ConfigurationManager.ConnectionStrings["server"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>()//.HasKey(a => new { a.Id, a.ProdutoID })
                                            .HasRequired<Produto>(s => s.Produto)
                                            .WithMany(g => g.Transacoes)
                                            .HasForeignKey(a => a.ProdutoID);

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
