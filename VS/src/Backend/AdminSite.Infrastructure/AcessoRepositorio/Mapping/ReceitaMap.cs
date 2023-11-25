using AdminSite.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSite.Infrastructure.AcessoRepositorio.Mapping;

public class ReceitaMap : IEntityTypeConfiguration<Receita>
{
    public void Configure(EntityTypeBuilder<Receita> builder)
    {
        builder.ToTable("tb_receita");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
             .HasColumnName("id_receita")
             .HasColumnType("int")
             .IsRequired();

        builder.Property(e => e.Titulo)
            .HasColumnName("dsc_Titulo")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.CategoriaId)
            .HasColumnName("id_categoriaId")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(e => e.ModoPreparo)
            .HasColumnName("dsc_modopreparo")
            .HasColumnType("varchar(500)")
            .IsRequired();

        builder.Property(e => e.TempoPreparo)
          .HasColumnName("num_tempopreparo")
          .HasColumnType("int")
          .IsRequired();

        builder.Property(e => e.UsuarioId)
              .HasColumnName("id_usuario")
              .HasColumnType("int")
              .IsRequired();

    }
}
