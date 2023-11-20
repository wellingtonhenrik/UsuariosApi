﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsuariosApi.Infra.Data.Contexts;

#nullable disable

namespace UsuariosApi.Infra.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231110194013_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UsuariosApi.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid?>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("USUARIOID");

                    b.Property<DateTime?>("DataHoraCriacao")
                        .IsRequired()
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORACRIACAO");

                    b.Property<DateTime?>("DataHoraUltimaAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAHORAULTIMAALTERACAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("SENHA");

                    b.HasKey("UsuarioId");

                    b.HasIndex("Email");

                    b.ToTable("USUARIO", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
