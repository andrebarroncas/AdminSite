using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Conexao.Recuperar;
public interface IRecuperarTodasConexoesUseCase
{
    Task<RespostaConexoesDoUsuarioJson> Executar();
}
