using FluentMigrator.Runner;
using AdminSite.Domain.Extension;
using AdminSite.Domain.Repositorios;
using AdminSite.Infrastructure.AcessoRepositorio;
using AdminSite.Infrastructure.AcessoRepositorio.Repositorio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using AdminSite.Domain.Repositorios.Usuario;
using AdminSite.Domain.Repositorios.Receita;
using AdminSite.Domain.Repositorios.Codigo;
using AdminSite.Domain.Repositorios.Conexao;

namespace AdminSite.Infrastructure;

public static class Bootstrapper
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddFluentMigrator(services, configurationManager);

        AddContexto(services, configurationManager);
        AddUnidadeDeTrabalho(services);
        AddRepositorios(services);
    }

    private static void AddContexto(IServiceCollection services, IConfiguration configurationManager)
    {
        //_ = bool.TryParse(configurationManager.GetSection("Configuracoes:BancoDeDadosInMemory").Value, out bool bancoDeDadosInMemory);

        //if (!bancoDeDadosInMemory)
        //{
        //    var versaoServidor = new MySqlServerVersion(new Version(8, 0, 26));
        //    var connextionString = configurationManager.GetConexaoCompleta();

        //    services.AddDbContext<AdminSiteContext>(dbConextoOpcoes =>
        //    {
        //        dbConextoOpcoes.UseMySql(connextionString, versaoServidor);
        //    });
        //}

        var connectionString = configurationManager.GetConnectionString("AdminSiteConnection");

        services.AddDbContext<AdminSiteContext>(options => options.UseSqlServer(connectionString)
                 .EnableSensitiveDataLogging()
                 .UseLazyLoadingProxies());
    }

    private static void AddUnidadeDeTrabalho(IServiceCollection services)
    {
        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }

    private static void AddRepositorios(IServiceCollection services)
    {
        services.AddScoped<IUsuarioWriteOnlyRepositorio, UsuarioRepositorio>()
            .AddScoped<IUsuarioReadOnlyRepositorio, UsuarioRepositorio>()
            .AddScoped<IUsuarioUpdateOnlyRepositorio, UsuarioRepositorio>()
            .AddScoped<IReceitaWriteOnlyRepositorio, ReceitaRepositorio>()
            .AddScoped<IReceitaReadOnlyRepositorio, ReceitaRepositorio>()
            .AddScoped<IReceitaUpdateOnlyRepositorio, ReceitaRepositorio>()
            .AddScoped<ICodigoWriteOnlyRepositorio, CodigoRepositorio>()
            .AddScoped<ICodigoReadOnlyRepositorio, CodigoRepositorio>()
            .AddScoped<IConexaoReadOnlyRepositorio, ConexaoRepositorio>()
            .AddScoped<IConexaoWriteOnlyRepositorio, ConexaoRepositorio>();
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {
        _ = bool.TryParse(configurationManager.GetSection("Configuracoes:BancoDeDadosInMemory").Value, out bool bancoDeDadosInMemory);

        if (!bancoDeDadosInMemory)
        {
            services.AddFluentMigratorCore().ConfigureRunner(c =>
            c.AddMySql5()
            .WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("AdminSite.Infrastructure")).For.All()
            );
        }
    }
}
