using AdminSite.Comunicacao.Respostas;

namespace AdminSite.Application.UseCases.Receita.RecuperarPorId;
public interface IRecuperarReceitaPorIdUseCase
{
    Task<RespostaReceitaJson> Executar(long id);
}
