using AdminSite.Comunicacao.Requisicoes;

namespace AdminSite.Application.UseCases.Receita.Atualizar;
public interface IAtualizarReceitaUseCase
{
    Task Executar(long id, RequisicaoReceitaJson requisicao);
}
