using Ddd.Domain.Entities.Produtos;
using Ddd.Domain.Entities.Usuarios;
using Ddd.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Ddd.Infra.Data.Contexts
{
    public class ContextBase : DbContext, IContextBase
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProdutoConfig().DefinirConfiguracoesDaEntidade(modelBuilder);
            new UsuarioConfig().DefinirConfiguracoesDaEntidade(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Produto>().HasQueryFilter(p => !p.Excluido);

            base.OnModelCreating(modelBuilder);
        }
    }
}