using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApi.Domain.Entities;

namespace UsuariosApi.Infra.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(a => a.UsuarioId);

            builder.Property(a=>a.UsuarioId).HasColumnName("USUARIOID");

            builder.Property(a => a.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(a => a.Email).HasColumnName("EMAIL").HasMaxLength(150).IsRequired();
            builder.HasIndex(a => a.Email);
            builder.Property(a => a.Senha).HasColumnName("SENHA").HasMaxLength(40).IsRequired();
            builder.Property(a => a.DataHoraCriacao).HasColumnName("DATAHORACRIACAO").IsRequired();
            builder.Property(a => a.DataHoraUltimaAlteracao).HasColumnName("DATAHORAULTIMAALTERACAO");
        }
    }
}
