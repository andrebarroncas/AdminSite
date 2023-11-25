using AdminSite.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AdminSite.Infrastructure.AcessoRepositorio;

public class AdminSiteContext : DbContext
{
    public AdminSiteContext(DbContextOptions<AdminSiteContext> options) : base(options) {}

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Receita> Receitas { get; set; }
    public DbSet<Codigos> Codigos { get; set; }
    public DbSet<Conexao> Conexoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminSiteContext).Assembly);
    }
}