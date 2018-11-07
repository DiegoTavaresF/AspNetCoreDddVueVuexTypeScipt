using Ddd.Domain.Entities.Tarefas;
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
        private readonly bool _isTest = false;

        public ContextBase()
        {
        }

        public ContextBase(DbContextOptions<ContextBase> options)
       : base(options)
        {
            _isTest = true;
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_isTest)
            {
                base.OnConfiguring(optionsBuilder);
                return;
            }

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
            new TarefaConfig().DefinirConfiguracoesDaEntidade(modelBuilder);
            new UsuarioConfig().DefinirConfiguracoesDaEntidade(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<Tarefa>().HasQueryFilter(p => !p.Excluido);

            base.OnModelCreating(modelBuilder);
        }
    }
}