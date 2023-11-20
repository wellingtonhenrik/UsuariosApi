using Microsoft.EntityFrameworkCore;
using UsuariosApi.Domain.Entities;
using UsuariosApi.Infra.Data.Configurations;

namespace UsuariosApi.Infra.Data.Contexts
{
    public class Context : DbContext
    {
        /// <summary>
        /// Método para mapear a conexão com o banco de dados
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SQL8006.site4now.net;Initial Catalog=db_aa1512_bdusuariosapi;User Id=db_aa1512_bdusuariosapi_admin;Password=Www*161616");
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento (ORM) cradas no projeto
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        /// <summary>
        /// Entidade atravez do qual será criado um repositorio
        /// </summary>
        public DbSet<Usuario>? Usuario { get; set; }
    }
}
