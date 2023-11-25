using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Usuario.RecuperarPerfil;
public interface IRecuperarPerfilUseCase
{
    Task<RespostaPerfilUsuarioJson> Executar();
}
