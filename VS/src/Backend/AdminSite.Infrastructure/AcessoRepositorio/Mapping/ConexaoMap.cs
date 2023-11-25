using AdminSite.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminSite.Infrastructure.AcessoRepositorio.Mapping;

public class ConexaoMap : IEntityTypeConfiguration<Conexao>
{
    public void Configure(EntityTypeBuilder<Conexao> builder)
    {
        builder.ToTable("tb_conexao");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
             .HasColumnName("id_conexao")
             .HasColumnType("int")
             .IsRequired();

        builder.Property(e => e.ConectadoComUsuarioId)
            .HasColumnName("num_conectadocomusuarioId")
            .HasColumnType("int")
            .IsRequired();


        builder.Property(e => e.UsuarioId)
              .HasColumnName("id_usuario")
              .HasColumnType("int")
              .IsRequired();

    }
}
