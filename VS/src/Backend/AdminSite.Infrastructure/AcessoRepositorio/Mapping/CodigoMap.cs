using AdminSite.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSite.Infrastructure.AcessoRepositorio.Mapping;
public class CodigoMap : IEntityTypeConfiguration<Codigos>
{
    public void Configure(EntityTypeBuilder<Codigos> builder)
    {

        builder.ToTable("tb_codigo");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
             .HasColumnName("id_codigo")
             .HasColumnType("int")
             .IsRequired();

        builder.Property(e => e.Codigo)
            .HasColumnName("num_codigo")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.UsuarioId)
            .HasColumnName("id_usuario")
            .HasColumnType("int")
            .IsRequired();

    }
}
