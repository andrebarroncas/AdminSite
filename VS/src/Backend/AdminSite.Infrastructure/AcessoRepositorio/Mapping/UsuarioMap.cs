using AdminSite.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminSite.Infrastructure.AcessoRepositorio.Mapping;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("tb_usuario");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
             .HasColumnName("id_usuario")
             .HasColumnType("int")
             .IsRequired();

        builder.Property(e => e.Nome)
            .HasColumnName("nom_usuario")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.Senha)
            .HasColumnName("psw_usuario")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.Email)
            .HasColumnName("mail_usuario")
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(e => e.Telefone)
            .HasColumnName("tel_usuario")
            .HasColumnType("varchar(15)")
            .IsRequired(false);


        builder.Property(e => e.DataCriacao)
            .HasColumnName("din_DataCriacao")
            .HasColumnType("datetime")
            .IsRequired();

       
    }
}
