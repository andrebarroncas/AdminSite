namespace AdminSite.Application.UseCases.Conexao.Remover;
public interface IRemoverConexaoUseCase
{
    Task Executar(long idUsuarioConectadoParaRemover);
}
