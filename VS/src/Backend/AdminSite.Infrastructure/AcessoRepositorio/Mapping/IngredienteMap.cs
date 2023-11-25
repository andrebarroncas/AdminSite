using AdminSite.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminSite.Infrastructure.AcessoRepositorio.Mapping;

public class IngredienteMap : IEntityTypeConfiguration<Ingrediente>
{
    public void Configure(EntityTypeBuilder<Ingrediente> builder)
    {
        builder.ToTable("tb_ingrediente");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
             .HasColumnName("id_ingrediente")
             .HasColumnType("int")
             .IsRequired();

        builder.Property(e => e.Produto)
            .HasColumnName("nom_produto")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.Quantidade)
            .HasColumnName("num_quantidade")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(e => e.ReceitaId)
          .HasColumnName("id_ReceitaId")
          .HasColumnType("int")
          .IsRequired();

    }
}
