using AdminSite.Application.Servicos.Criptografia;
using AdminSite.Application.Servicos.Token;
using AdminSite.Application.Servicos.UsuarioLogado;
using AdminSite.Application.UseCases.Conexao.AceitarConexao;
using AdminSite.Application.UseCases.Conexao.GerarQRCode;
using AdminSite.Application.UseCases.Conexao.QRCodeLido;
using AdminSite.Application.UseCases.Conexao.Recuperar;
using AdminSite.Application.UseCases.Conexao.RecusarConexao;
using AdminSite.Application.UseCases.Conexao.Remover;
using AdminSite.Application.UseCases.Dashboard;
using AdminSite.Application.UseCases.Login.FazerLogin;
using AdminSite.Application.UseCases.Receita.Atualizar;
using AdminSite.Application.UseCases.Receita.Deletar;
using AdminSite.Application.UseCases.Receita.RecuperarPorId;
using AdminSite.Application.UseCases.Receita.Registrar;
using AdminSite.Application.UseCases.Usuario.AlterarSenha;
using AdminSite.Application.UseCases.Usuario.RecuperarPerfil;
using AdminSite.Application.UseCases.Usuario.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdminSite.Application;

public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AdicionarChaveAdicionalSenha(services, configuration);
        AdicionarHashIds(services, configuration);
        AdicionarTokenJWT(services, configuration);
        AdicionarUseCases(services);
        AdicionarUsuarioLogado(services);
    }

    private static void AdicionarUsuarioLogado(IServiceCollection services)
    {
        services.AddScoped<IUsuarioLogado, UsuarioLogado>();
    }

    private static void AdicionarChaveAdicionalSenha(IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetRequiredSection("Configuracoes:Senha:ChaveAdicionalSenha");

        services.AddScoped(option => new EncriptadorDeSenha(section.Value));
    }

    private static void AdicionarTokenJWT(IServiceCollection services, IConfiguration configuration)
    {
        var sectionTempoDeVida = configuration.GetRequiredSection("Configuracoes:Jwt:TempoVidaTokenMinutos");
        var sectionKey = configuration.GetRequiredSection("Configuracoes:Jwt:ChaveToken");
        
        services.AddScoped(option => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }

    private static void AdicionarHashIds(IServiceCollection services, IConfiguration configuration)
    {
        var salt = configuration.GetRequiredSection("Configuracoes:HashIds:Salt");

        services.AddHashids(setup =>
        {
            setup.Salt = salt.Value;
            setup.MinHashLength = 3;
        });
    }

    private static void AdicionarUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>()
            .AddScoped<ILoginUseCase, LoginUseCase>()
            .AddScoped<IAlterarSenhaUseCase, AlterarSenhaUseCase>()
            .AddScoped<IRegistrarReceitaUseCase, RegistrarReceitaUseCase>()
            .AddScoped<IDashboardUseCase, DashboardUseCase>()
            .AddScoped<IRecuperarReceitaPorIdUseCase, RecuperarReceitaPorIdUseCase>()
            .AddScoped<IAtualizarReceitaUseCase, AtualizarReceitaUseCase>()
            .AddScoped<IDeletarReceitaUseCase, DeletarReceitaUseCase>()
            .AddScoped<IRecuperarPerfilUseCase, RecuperarPerfilUseCase>()
            .AddScoped<IGerarQRCodeUseCase, GerarQRCodeUseCase>()
            .AddScoped<IQRCodeLidoUseCase, QRCodeLidoUseCase>()
            .AddScoped<IRecusarConexaoUseCase, RecusarConexaoUseCase>()
            .AddScoped<IAceitarConexaoUseCase, AceitarConexaoUseCase>()
            .AddScoped<IRecuperarTodasConexoesUseCase, RecuperarTodasConexoesUseCase>()
            .AddScoped<IRemoverConexaoUseCase, RemoverConexaoUseCase>();
    }
}
