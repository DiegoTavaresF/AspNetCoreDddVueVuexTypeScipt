using Ddd.Domain.Entities.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Ddd.Infra.Data.EntityConfig
{
    public class UsuarioConfig
    {
        public void DefinirConfiguracoesDaEntidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuario");

                e.HasKey(w => w.Id);
            });
        }
    }
}